using SpreadsheetUtilities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace SS
{
    public class Spreadsheet : AbstractSpreadsheet
    {
        // Private dicionary to hold the cells indexed by their name.
        private Dictionary<string, Cell> cells;

        // Dependency graph for all the defined cells.
        private DependencyGraph depGraph;

        override public bool Changed { get; protected set; }

        public Spreadsheet() : base(s => true, s => s, "default")
        {
            cells = new Dictionary<string, Cell>();
            depGraph = new DependencyGraph();
            Changed = false;
        }

        public Spreadsheet(Func<string, bool> isValid, Func<string, string> normalize, string version) : base(isValid, normalize, version)
        {
            cells = new Dictionary<string, Cell>();
            depGraph = new DependencyGraph();
            Changed = false;
        }

        public Spreadsheet(string filename, Func<string, bool> isValid, Func<string, string> normalize, string version) : base(isValid, normalize, version)
        {
            cells = new Dictionary<string, Cell>();
            depGraph = new DependencyGraph();
            Changed = false;
            try
            {
                using (XmlReader reader = XmlReader.Create(filename))
                {
                    string name = null;
                    string contents = null;

                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "spreadsheet":
                                    Version = reader["version"];
                                    if (version != Version)
                                        throw new SpreadsheetReadWriteException("Versions are not the same");
                                    break;

                                case "cell":
                                    break;

                                case "name":
                                    reader.Read();
                                    name = reader.Value;
                                    break;

                                case "contents":
                                    reader.Read();
                                    contents = reader.Value;
                                    break;
                            }
                        }
                        else
                        {
                            switch (reader.Name)
                            {
                                case "cell":
                                    SetContentsOfCell(name, contents);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }
        }

        public override string GetSavedVersion(string name)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(name))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "spreadsheet":
                                    return reader["version"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }
            throw new SpreadsheetReadWriteException("No version information present");
        }

        public override void Save(string filename)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("spreadsheet");
                    writer.WriteAttributeString("version", Version);
                    foreach (Cell c in cells.Values)
                        c.WriteXml(writer);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }
        }


        override public IEnumerable<String> GetNamesOfAllNonemptyCells()
        {
            return new HashSet<string>(cells.Keys);
        }

        override public object GetCellContents(String name)
        {
            name = IsValidName(name);

            return (cells.ContainsKey(name)) ? cells[name].Contents : "";
        }

        override public IList<String> SetContentsOfCell(String name, String content)
        {
            name = IsValidName(name);

            IList<string> return_IList = null;

            if (content.Length > 0 && content[0] == '=')
                return_IList = SetCellContents(name, new Formula(content.Substring(1), Normalize, IsValid));

            else if (double.TryParse(content, out double content_double))
                return_IList = SetCellContents(name, content_double);

            else
                return_IList = SetCellContents(name, content);

            Changed = true;

            RecalculateAllChangedValues(return_IList);

            return return_IList;
        }


        override protected IList<String> SetCellContents(String name, double number)
        {
            // Modify the old cell, or create new cell, to contain the new Formula.
            AddOrModifyContentsOfKey(name, number);

            // Replace dependents with new dependents found in the formula.
            depGraph.ReplaceDependees(name, new List<string>());

            return new List<string>(GetCellsToRecalculate(name));
        }

        override protected IList<String> SetCellContents(String name, String text)
        {
            if (text != "")
                AddOrModifyContentsOfKey(name, text);
            else
                cells.Remove(name);

            depGraph.ReplaceDependees(name, new List<string>());

            return new List<string>(GetCellsToRecalculate(name));
        }

        override protected IList<String> SetCellContents(String name, Formula formula)
        {
            Cell oldCell = null;
            IEnumerable<string> oldDees = new List<string>();
            if (cells.ContainsKey(name))
            {
                // Save old dependees in case new formula throws circular exception
                oldDees = depGraph.GetDependees(name);
                //Save the old cell in case the new one throws a CircularException  
                oldCell = cells[name];
            }

            // Modify the old cell, or create new cell, to contain the new Formula.
            AddOrModifyContentsOfKey(name, formula);
            // Replace dependents with new dependents found in the formula.
            depGraph.ReplaceDependees(name, formula.GetVariables());

            try
            {
                return new List<string>(GetCellsToRecalculate(name));
            }
            catch (CircularException)
            {
                depGraph.ReplaceDependees(name, oldDees);
                if (oldCell is null)
                    cells.Remove(name);
                else
                    cells[name] = oldCell;
                throw new CircularException();
            }
        }

        override protected IEnumerable<String> GetDirectDependents(String name)
        {
            return new List<string>(depGraph.GetDependents(name));
        }

        private string IsValidName(string s)
        {
            if (s == null)
                throw new ArgumentNullException();
            s = Normalize(s);
            if (s == null || !Regex.IsMatch(s, @"^[a-zA-z]+[0-9]+$") || !IsValid(s))
                throw new InvalidNameException();
            return s;
        }

        private void AddOrModifyContentsOfKey(string key, object contents)
        {
            if (contents is null)
                throw new ArgumentNullException();
            cells[key] = new Cell(key, contents);
        }

        private void RecalculateAllChangedValues(IList<string> list)
        {
            foreach (string key in list)
            {
                if (cells.ContainsKey(key)) // This should NEVER fail, because the names are already checked in a previous function.
                {
                    if (cells[key].Contents is Formula)
                        cells[key].Value = ((Formula)cells[key].Contents).Evaluate(SpreadsheetLookup);
                    else
                        cells[key].Value = cells[key].Contents;
                }
            }
        }

        private double SpreadsheetLookup(string name)
        {
            object ret = this.GetCellValue(name);
            if (ret is double) return (double)ret;
            else throw new ArgumentException("Invalid variable value.");
        }

        public override object GetCellValue(string name)
        {
            if (name == null) throw new InvalidNameException();
            name = Normalize(name);
            IsValid(name);

            return (cells.ContainsKey(name)) ? cells[name].Value : "";
        }

        private class Cell
        {
            private string Name;
            public object Contents { get; private set; }
            public object Value { get; set; }

            public Cell(string name, object contents)
            {
                Name = name;
                Contents = contents;
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("cell");
                writer.WriteElementString("name", Name);

                if (Contents is Formula)
                    writer.WriteElementString("contents", "=" + ((Formula)Contents).ToString());
                else
                    writer.WriteElementString("contents", Contents.ToString());

                writer.WriteEndElement();
            }
        }
    }
}

