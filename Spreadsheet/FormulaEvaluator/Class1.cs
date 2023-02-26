using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FormulaEvaluator
    
{
    
   //public delegate int Lookup(String v);
    //public static int Evaluate(String exp, Lookup variableEvaluator)
    //{

    //}
   // public int checkabc(String v);
   //Lookup Checkaval = checkabc;
   // Checkval();
    
    public static class Evaluator
    {
        public static int Opperationtype(int num1, int num2, String opp)
        {
            if (opp == "+")
                return num1 + num2;
            if (opp == "-")
                return num2 - num1;
            if (opp == "/")
                return num1 / num2;
            if (opp == "*")
                return num1 * num2;
            else
            {
                return 0;
            }
        }



        public static int EvaluatorFormula(String s) {
            Stack val = new Stack();
            Stack opp = new Stack();

            List<String> trimmed_strings = new List<String>();
                String r = "(9 * 3)/ 4";
                String[] substrings = Regex.Split(r, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");
                foreach (String i in substrings)
                    trimmed_strings.Add(i.Trim());


                foreach (String i in trimmed_strings)
                    Console.WriteLine(i);

                foreach (String t in trimmed_strings)
                {
                    //int left_num; 
                    //int right_num = Int32.Parse(t);

                    Console.WriteLine("getting token" + t);
                    //Console.WriteLine("taimur");
                    if (int.TryParse(t, out int number))
                    {
                        if (opp.Count > 0)
                        {

                            if (opp.Peek().ToString() == "*" || opp.Peek().ToString() == "/")
                            {
                                int pop_val_st_1 = Convert.ToInt32(val.Pop());
                                String opp_to_apply = Convert.ToString(opp.Pop());
                                int pop_val_2 = Convert.ToInt32(t);
                                int result = Opperationtype(pop_val_st_1, pop_val_2, opp_to_apply);
                                val.Push(result);
                                Console.WriteLine("the result for division/multiplications is " + result);
                            return result;

                            }
                            else if (opp.Peek().ToString() != "+" || opp.Peek().ToString() != "-")
                            {
                                val.Push(Convert.ToInt32(t));
                                Console.WriteLine("value " + t + " pushed in second if");

                            }
                        }
                        else
                        {
                            val.Push(Convert.ToInt32(t));
                            Console.WriteLine("value " + t + " pushed");
                        }
                    }

                    if (t == "+" || t == "-")
                    {

                        if (opp.Count > 0 && (opp.Peek().ToString() == "+" || opp.Peek().ToString() == "-"))
                        {
                            Object temp2 = val.Pop();
                            int num_1 = Convert.ToInt32(temp2);
                            Object temp3 = val.Pop();
                            int num_2 = Convert.ToInt32(temp3);
                            Object tem4 = opp.Pop();
                            String opp_1 = tem4.ToString();
                            int result = Opperationtype(num_1, num_2, opp_1);
                            Console.WriteLine(result);
                            val.Push(result);
                            opp.Push(t);
                        return result;
                        }
                        else
                        {
                            opp.Push(t);
                            Console.WriteLine("pushed opp");
                        }

                    }
                    if (t == "*" || t == "/")
                    {
                        opp.Push(t);
                        Console.WriteLine("divide / multiply is on the stack");
                    }
                    if (t == "(")
                    {
                        opp.Push(t);
                    }
                    if (t == ")")
                    {
                        if (opp.Count > 0 && (opp.Peek().ToString() == "+" || opp.Peek().ToString() == "-"))
                        {
                            Object temp1 = val.Pop();
                            int num_1 = Convert.ToInt32(temp1);
                            Object temp2 = val.Pop();
                            int num_2 = Convert.ToInt32(temp2);

                            Object temp3 = opp.Pop();
                            String temp_res = temp3.ToString();
                            int result = Opperationtype(num_1, num_2, temp_res);
                            Console.WriteLine("the result is " + result);
                            val.Push(result);
                            Object lef6_brac = opp.Pop();
                        return result;

                        }
                        else if (opp.Count > 0 && (opp.Peek().ToString() == "*" || opp.Peek().ToString() == "/"))
                        {
                            Object pop_1 = val.Pop();
                            int val_1 = Convert.ToInt32(pop_1);
                            Console.WriteLine(val_1);


                            Object pop_2 = val.Pop();

                            int val_2 = Convert.ToInt32(pop_2);
                            Object pop_3 = opp.Pop();
                            string opp_temp = pop_3.ToString();
                            int result = Opperationtype(val_1, val_2, opp_temp);
                            val.Push(result);

                        return result;
                        }


                    }

                }

                if (opp.Count == 0)
                {
                    if (val.Count == 1)
                    {
                        Object temp3 = val.Pop();
                        int val_1 = Convert.ToInt32(temp3);
                        val.Push(val_1);
                    return val_1;

                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else
                {
                    if (opp.Count == 1)
                    {
                        Console.WriteLine("it will divide/multiply");
                        if (opp.Peek().ToString() == "+" || opp.Peek().ToString() == "-")
                        {
                            String opp_1 = opp.Pop().ToString();
                            if (val.Count == 2)
                            {
                                int val1 = Convert.ToInt32(val.Pop());
                                int val2 = Convert.ToInt32(val.Pop());
                                int result = Opperationtype(val1, val2, opp_1);
                                val.Push(result);
                                Console.WriteLine(result);
                            return result;
                            }
                            else
                            {
                                throw new InvalidOperationException();

                            }
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }

                    int final_answer = Convert.ToInt32(val.Pop());
                return final_answer;
                }










            }

        }
}
