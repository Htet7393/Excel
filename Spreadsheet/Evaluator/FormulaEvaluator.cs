using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/// <summary>
/// Delegate keyword used to create a type which represents a function signature
/// "x1+(x2+(x3+(x4+(x5+x6))))"

namespace FormulaEvaluator
{
   

    //"x1+(x2+(x3+(x4+(x5+x6))))"
    public delegate int Lookup(string v);
    public class Evaluator
    {
        public static int DoOperation(int num1, int num2, string o)
        {
            if (o == "+")
                return num1 + num2;
            if (o == "-")
                return num2 - num1;
            if (o == "/")
            {
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    throw new ArgumentException("Division by 0");
                }
            }
            if (o == "*")
                return num1 * num2;
            throw new ArgumentException("Invalid operation type");
        }
        public static void PrintStack(Stack tokens)
        {
            foreach (object i in tokens)
            {
                Console.Write(i.ToString() + ",");
            }
            Console.WriteLine("");
        }
        public static bool ValidVar(string s)
        {
            if (s.Length < 2)
                return false;


            int left = 0;
            int right = s.Length - 1;

            if (char.IsDigit(s[left]) || char.IsLetter(s[right]))
            {
                return false;
            }
            while (left < right && char.IsLetter(s[left]))
            {
                left += 1;
            }
            while (left < right && char.IsDigit(s[right]))
            {
                right -= 1;
            }
            if (left == right)
                return true;

            return false;

        }
        public static int Evaluate(String exp, Lookup variableEvaluator)
        {
            List<String> trimmed_strings = new List<String>();
            Stack val = new Stack();
            Stack opp = new Stack();
            String[] substrings = Regex.Split(exp, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");
            foreach (string i in substrings)
                trimmed_strings.Add(i.Trim());

            foreach (string t in trimmed_strings)
            {
                if (Int32.TryParse(t, out int result))
                {
                    if (opp.Count > 0 && (opp.Peek().ToString() == "*" || opp.Peek().ToString() == "/"))
                    {
                        if (val.Count == 0)
                        {
                            throw new ArgumentNullException("value stack is empty");
                        }
                        else
                        {
                            int val_pop = Int32.Parse(val.Pop().ToString());
                            string opp_pop = opp.Pop().ToString();
                            int result_of = DoOperation(val_pop, Int32.Parse(t), opp_pop);
                            Console.WriteLine("The result is " + result_of);
                            val.Push(result_of);




                        }
                    }
                    else
                    {
                        val.Push(t);
                        Console.WriteLine("Value " + t + " has been pushed");

                    }
                }
                if (ValidVar(t))
                {
                    int var_value = variableEvaluator(t);
                    if (opp.Count > 0 && (opp.Peek().ToString() == "*" || opp.Peek().ToString() == "/"))
                    {
                        if (val.Count == 0)
                        {
                            throw new ArgumentNullException("value stack is empty");
                        }
                        else
                        {
                            int val_var_pop = Int32.Parse(val.Pop().ToString());
                            string opp_var_val = opp.Pop().ToString();
                            int result_for_var = DoOperation(val_var_pop, var_value, opp_var_val);
                            val.Push(result);

                        }
                    }
                    else
                    {
                        val.Push(var_value);
                        Console.WriteLine("variable " + t + " with value " + var_value + " has been pushed");
                    }
                }
                if (t == "+" || t == "-")
                {
                    if (opp.Count > 0 && (opp.Peek().ToString() == "+" || opp.Peek().ToString() == "-"))
                    {
                        if (val.Count < 2)
                        {
                            throw new ArgumentException("less than 2 values on value stack");
                        }
                        else
                        {
                            int val_pop = Int32.Parse(val.Pop().ToString());
                            int val_pop_2 = Int32.Parse(val.Pop().ToString());
                            string opp_con = opp.Pop().ToString();
                            int result_2 = DoOperation(val_pop, val_pop_2, opp_con);
                            val.Push(result_2);
                            Console.WriteLine("result of plus/minus " + result_2);
                        }
                    }
                    opp.Push(t);

                }
                if (t == "*" || t == "/")
                {
                    opp.Push(t);
                }
                if (t == "(")
                {
                    Console.WriteLine("( parenthesis has been pushed");
                    opp.Push(t);
                }
                if (t == ")")
                {
                    if (opp.Count > 0 && (opp.Peek().ToString() == "+" || opp.Peek().ToString() == "-"))
                    {
                        if (val.Count < 2)
                        {
                            throw new ArgumentException("less than 2 values on the value stack");
                        }
                        else
                        {
                            int pop_val_1 = Int32.Parse(val.Pop().ToString());
                            int pop_val_2 = Int32.Parse(val.Pop().ToString());
                            string opp_pop = opp.Pop().ToString();
                            int result_right_par = DoOperation(pop_val_1, pop_val_2, opp_pop);
                            val.Push(result_right_par);
                            Console.WriteLine("result of right par " + result_right_par);
                        }
                    }
                    opp.Pop();

                    if (opp.Count > 0 && (opp.Peek().ToString() == "*" || opp.Peek().ToString() == "/"))
                    {
                        if (val.Count >= 2)
                        {
                            int pop_val_3 = Int32.Parse(val.Pop().ToString());
                            int pop_val_4 = Int32.Parse(val.Pop().ToString());
                            string opp_pop_2 = opp.Pop().ToString();
                            int result_4 = DoOperation(pop_val_3, pop_val_4, opp_pop_2);
                            val.Push(result_4);
                        }
                    }



                }
                PrintStack(val);
                PrintStack(opp);

            }
            if (opp.Count == 0)
            {
                if (val.Count == 1)
                    return Int32.Parse(val.Pop().ToString());
            }
            else if (opp.Count == 1 && val.Count == 2)
            {

                int pop_val_3 = Int32.Parse(val.Pop().ToString());
                int pop_val_4 = Int32.Parse(val.Pop().ToString());
                string opp_pop_2 = opp.Pop().ToString();
                int result_4 = DoOperation(pop_val_3, pop_val_4, opp_pop_2);
                return result_4;
            }

            return Int32.Parse(val.Pop().ToString());
        }

    }
}

