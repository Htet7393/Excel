using SpreadsheetUtilities;
using SS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace SpreadsheetGUI
{
    public partial class Form1 : Form
    {
        private AbstractSpreadsheet sheet;// declaring the spreadsheet
        private bool isCollapsed = true;// boolean to keep tracks of the File button status.
        private bool saved;
        private string savedName = "";



        public Form1()
        {
            InitializeComponent();
            AcceptButton = Enter;
            // Keys.Up = UpButton;
            sheet = new Spreadsheet();
            saved = false;

            //This code displays the name of the cell when the sheet is first loaded. 
            spreadsheetPanel1.GetSelection(out int col, out int row);
            row++;
            string name = GetCellName(col) + row;
            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell

            //CellContent.Clear();
            CellContent.Focus();

            spreadsheetPanel1.SelectionChanged += OnSelectionChanged;
        }
        /// <summary>
        /// -spreadhsheet replicates the functions of a spreadshee in Microsoft Excel.
        /// -To write in the cells,pleae tyoe in the cell content textbox.
        /// -Cell value will be displayed in the cell value text box. 
        /// -Content will be in the cell content box and the cells themselves.
        /// -Use the save as button to savena new spreadhseet
        /// -Use the save button to save contents a pre-existing spereadsheet.
        /// 
        /// </summary>
        /// <param name="panel"></param>

        /// <summary>
        /// Method that records whenever a cell on spreadsheet is selected. 
        /// And updates the cell name, cell content and cell value.
        /// </summary>
        /// <param name="panel"></param>
        private void OnSelectionChanged(SpreadsheetPanel panel)
        {
            panel.GetSelection(out int col, out int row);
            row++;
            string name = GetCellName(col) + row;
            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell

            CellContent.Focus();

        }

        /// <summary>
        /// Funcions of enter key. To enter values into cell centent textbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_Click(object sender, EventArgs e)
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            spreadsheetPanel1.SetValue(col, row, CellValue.Text);

            row++;
            string name = GetCellName(col) + row;
            CellName.Text = name;

            Console.WriteLine("hello");

            try
            {
                sheet.SetContentsOfCell(CellName.Text, CellContent.Text);//Setting the content of the cell by typing in in the Cell Content text box. 
            }
            catch (FormulaFormatException f)
            {
                MessageBox.Show("Invalid Formula!");
            }
            CellValue.Text = sheet.GetCellValue(name).ToString();
            spreadsheetPanel1.GetSelection(out int col1, out int row1);
            spreadsheetPanel1.SetValue(col1, row1, sheet.GetCellValue(name).ToString());
            List<string> list = sheet.GetNamesOfAllNonemptyCells().ToList();
            foreach (string content in list)
            {
                string A = content.Substring(0, 1);
                string B = content.Substring(1);
                int j = Int32.Parse(B);
                j--;
                int i = GetCellIndex(A);
                spreadsheetPanel1.SetValue(i, j, sheet.GetCellValue(content).ToString());

            }

        }


        /// <summary>
        /// Method to move one cell up. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpButton_Click(object sender, EventArgs e)
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            spreadsheetPanel1.SetSelection(col, row - 1);


            string name;
            if (row == 0)
            {
                row++;
                name = GetCellName(col) + row;
            }
            else
                name = GetCellName(col) + row;
            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell                          
            CellContent.Focus();
        }

        /// <summary>
        /// Method to move one cell down. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownButton_Click(object sender, EventArgs e)
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            spreadsheetPanel1.SetSelection(col, row + 1);

            row += 2;
            string name;
            if (row == 100)
            {
                row--;
                name = GetCellName(col) + row;
            }
            else
                name = GetCellName(col) + row;

            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell                          
            CellContent.Focus();
        }


        /// <summary>
        /// Method to move one cell left. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_Click(object sender, EventArgs e)
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            spreadsheetPanel1.SetSelection(col - 1, row);

            row++;
            string name;
            if (col == 0)
            {

                name = GetCellName(col) + row;
            }
            else
                name = GetCellName(col - 1) + row;
            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell                          
            CellContent.Focus();
        }


        /// <summary>
        /// Method to move one cell right. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Click(object sender, EventArgs e)
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            spreadsheetPanel1.SetSelection(col + 1, row);

            row++;
            string name;
            if (col == 25)
            {
                name = GetCellName(col) + row;
            }
            else
                name = GetCellName(col + 1) + row;
            CellName.Text = name;
            CellContent.Text = sheet.GetCellContents(name).ToString();//Display the chosen cell's content in the Cell Content text box. 
            CellValue.Text = sheet.GetCellValue(name).ToString();//Display the value of the cell                          
            CellContent.Focus();
        }


        /// <summary>
        /// Method to map arrow keys form keyboard to the buttons on the spreadsheet that perform navigating cells. 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                UpButton.PerformClick();
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                DownButton.PerformClick();
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                LeftButton.PerformClick();
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                RightButton.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }





        /// <summary>
        /// Method that converts numerical values into vaild spreadsheet names. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetCellName(int value)
        {
            char[] c = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Dictionary<int, string> input = new Dictionary<int, string>();
            int i = 0;
            foreach (char key in c)
            {
                input.Add(i, key.ToString());
                i++;
            }
            input.TryGetValue(value, out string name);
            return name;
        }

        /// <summary>
        /// Recording file opening. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Click(object sender, EventArgs e)
        {
            timer1.Start();
            File.Focus();
        }


        /// <summary>
        /// Method that gets the index of the cell based on the cell name which is a string. 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int GetCellIndex(string s)
        {
            int str_val;


            char[] c = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Dictionary<string, int> input = new Dictionary<string, int>();
            int i = 0;
            foreach (char key in c)
            {
                input.Add(key.ToString(), i);
                i++;
            }
            if (input.ContainsKey((s[0]).ToString()))
            {
                str_val = input[s[0].ToString()];
                return str_val;
            }

            return 0;

        }



        /// <summary>
        /// Timer that enables the drop down menu for File. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (isCollapsed)
            {
                FileMenu.Height += 10;
                if (FileMenu.Size == FileMenu.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }

            }
            else
            {
                FileMenu.Height -= 10;
                if (FileMenu.Size == FileMenu.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }


        /// <summary>
        /// Creating a new spread sheet when new button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Click(object sender, EventArgs e)
        {
            DemoApplicationContext.getAppContext().RunForm(new Form1());
        }



        /// <summary>
        /// Load an existing spreadsheet. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            //string filecontent = "";
            string filename = "";
            using (OpenFileDialog open_file = new OpenFileDialog())
            // open_file.ShowDialog();
            {
                open_file.InitialDirectory = "C:\\";
                open_file.Filter = "sprd files (*.sprd)|*.sprd|All files (*.*)|*.*";
                open_file.FilterIndex = 2;
                open_file.RestoreDirectory = true;


                if (open_file.ShowDialog() == DialogResult.OK)
                {
                    filename = open_file.FileName;
                    var filestream = open_file.OpenFile();


                    //StreamReader read = new StreamReader(filestream);
                    sheet = new Spreadsheet(filename, isValid, normalize, "default");
                    List<string> list = sheet.GetNamesOfAllNonemptyCells().ToList();
                    foreach (string name in list)
                    {
                        string A = name.Substring(0, 1);
                        string B = name.Substring(1);
                        int row = Int32.Parse(B);
                        row--;
                        int col = GetCellIndex(A);

                        spreadsheetPanel1.SetValue(col, row, sheet.GetCellValue(name).ToString());

                    }
                }
            }
        }

        /// <summary>
        /// Delegate for checking name. 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private bool isValid(string a)
        {
            return true;
        }

        /// <summary>
        /// Delegate that normalizes the name of cells. 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private string normalize(string a)
        {
            return a;
        }


        /// <summary>
        /// Save the current spreadsheet to the saved file.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            if (saved == true)
                sheet.Save(savedName);
            else
                SaveAs_Click(sender, e);
        }

        /// <summary>
        /// Save the existing spreadsheet ot a new save file. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\";
            saveFileDialog1.Filter = "sprd files (*.sprd)|*.sprd|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                sheet.Save(filename);
            }
            saved = true; //set saved to true
            savedName = filename;//set savedName to filename. 
        }

        private void Help_Click(object sender, EventArgs e)
        {
            string msg = "Spreadsheet replicates the functions of Microsoft Excel. To write in the cell, please type in the cell content textbox. Cell value will be displayed in the cell value text box and the cell. Content will be in the cell content text box. Use the Save As button to save a new spreadsheet. Use the Save button to save contents of a pre-existing spreadsheet.";
            MessageBox.Show(msg);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (sheet.Changed)
            {

                var result = MessageBox.Show("Spreadsheet has been modified.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Save_Click(sender, e);
                }
                else
                    Close();
            }
            else
                Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sheet.Changed)
            {

                var result = MessageBox.Show("Spreadsheet has been modified.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Save_Click(sender, e);
                }
            }
        }




    }
}
