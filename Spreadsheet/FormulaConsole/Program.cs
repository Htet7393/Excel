using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FormulaEvaluator;
using SpreadsheetUtilities;
using FormulaConsole;
using System.Security.Cryptography.X509Certificates;

namespace FormulaConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {   
           // Console.WriteLine(Evaluator.Evaluate("(9*4)/4",s=>0));
            //Console.WriteLine(Evaluator.Evaluate("5-2",s=>0));
           // Console.WriteLine(Evaluator.Evaluate(("2+3*5+(3+4*8)*5+2"),s=>0));
            Console.WriteLine("Hello World!");
            Dictionary<string, HashSet<string>> Dep_Graph = new Dictionary<string, HashSet<string>>();
            HashSet<string> a = new HashSet<string>();
            a.Add("b");
            a.Add("c");
            a.Add("d");
            Dep_Graph.Add("1", a);
            foreach (KeyValuePair<string, HashSet<string>> kvp in Dep_Graph)  
            {
                Console.WriteLine(kvp.Key);
                foreach (string   i in kvp.Value)
                {
                    Console.WriteLine(i);
                }
    
            }
            DependencyGraph new_grp = new DependencyGraph();
            new_grp.AddDependency("a", "b");
            new_grp.RemoveDependency("a", "b");
            Evaluator.Evaluate("x1 + (x2 + (x3 + (x4 + (x5 + x6))))", s => 1);
            //Formula t = new Formula("((X_2)+(X_3))");
            List<string> c = new List<string>();
            c.Add(("1"));
            c.Add(("2"));
            c.Add(("3"));
            Console.WriteLine(c.IndexOf("3"));
           
            foreach(string i in c)
            
                Console.WriteLine(c[c.Count-1]);
            }
        

        }
    }

