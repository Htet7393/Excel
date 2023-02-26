// Skeleton written by Joe Zachary for CS 3500, September 2013
// Read the entire skeleton carefully and completely before you
// do anything else!

// Version 1.1 (9/22/13 11:45 a.m.)

// Change log:
//  (Version 1.1) Repaired mistake in GetTokens
//  (Version 1.1) Changed specification of second constructor to
//                clarify description of how validation works

// (Daniel Kopta) 
// Version 1.2 (9/10/17) 

// Change log:
//  (Version 1.2) Changed the definition of equality with regards
//                to numeric tokens
//
// (Gavin Gray)
// Version 2.0 (9/13/19) Implemented all methods, added private helper methods. 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpreadsheetUtilities
{
    /// <summary>
    /// Represents formulas written in standard infix notation using standard precedence
    /// rules.  The allowed symbols are non-negative numbers written using double-precision 
    /// floating-point syntax (without unary preceeding '-' or '+'); 
    /// variables that consist of a letter or underscore followed by 
    /// zero or more letters, underscores, or digits; parentheses; and the four operator 
    /// symbols +, -, *, and /.  
    /// 
    /// Spaces are significant only insofar that they delimit tokens.  For example, "xy" is
    /// a single variable, "x y" consists of two variables "x" and y; "x23" is a single variable; 
    /// and "x 23" consists of a variable "x" and a number "23".
    /// 
    /// Associated with every formula are two delegates:  a normalizer and a validator.  The
    /// normalizer is used to convert variables into a canonical form, and the validator is used
    /// to add extra restrictions on the validity of a variable (beyond the standard requirement 
    /// that it consist of a letter or underscore followed by zero or more letters, underscores,
    /// or digits.)  Their use is described in detail in the constructor and method comments.
    /// </summary>
    public class Formula
    {

        //Private variable for holding the IEnumerable<string>
        private IEnumerable<string> _tokens;

        /// <summary>
        /// Creates a Formula from a string that consists of an infix expression written as
        /// described in the class comment.  If the expression is syntactically invalid,
        /// throws a FormulaFormatException with an explanatory Message.
        /// 
        /// The associated normalizer is the identity function, and the associated validator
        /// maps every string to true.  
        /// </summary>
        public Formula(String formula) :
            this(formula, s => s, s => true)
        { }

        /// <summary>
        /// Creates a Formula from a string that consists of an infix expression written as
        /// described in the class comment.  If the expression is syntactically incorrect,
        /// throws a FormulaFormatException with an explanatory Message.
        /// 
        /// The associated normalizer and validator are the second and third parameters,
        /// respectively.  
        /// 
        /// If the formula contains a variable v such that normalize(v) is not a legal variable, 
        /// throws a FormulaFormatException with an explanatory message. 
        /// 
        /// If the formula contains a variable v such that isValid(normalize(v)) is false,
        /// throws a FormulaFormatException with an explanatory message.
        /// 
        /// Suppose that N is a method that converts all the letters in a string to upper case, and
        /// that V is a method that returns true only if a string consists of one letter followed
        /// by one digit.  Then:
        /// 
        /// new Formula("x2+y3", N, V) should succeed
        /// new Formula("x+y3", N, V) should throw an exception, since V(N("x")) is false
        /// new Formula("2x+y3", N, V) should throw an exception, since "2x+y3" is syntactically incorrect.
        /// </summary>
        public Formula(String formula, Func<string, string> normalize, Func<string, bool> isValid)
        {
            this._tokens = CheckGeneralValidity(formula, normalize, isValid);
        }

        /// <summary>
        /// Evaluates this Formula, using the lookup delegate to determine the values of
        /// variables.  When a variable symbol v needs to be determined, it should be looked up
        /// via lookup(normalize(v)). (Here, normalize is the normalizer that was passed to 
        /// the constructor.)
        /// 
        /// For example, if L("x") is 2, L("X") is 4, and N is a method that converts all the letters 
        /// in a string to upper case:
        /// 
        /// new Formula("x+7", N, s => true).Evaluate(L) is 11
        /// new Formula("x+7").Evaluate(L) is 9
        /// 
        /// Given a variable symbol as its parameter, lookup returns the variable's value 
        /// (if it has one) or throws an ArgumentException (otherwise).
        /// 
        /// If no undefined variables or divisions by zero are encountered when evaluating 
        /// this Formula, the value is returned.  Otherwise, a FormulaError is returned.  
        /// The Reason property of the FormulaError should have a meaningful explanation.
        ///
        /// This method should never throw an exception.
        /// 
        /// Note** that because we have already done syntax checking this method does not look for syntax but
        ///     rather assumes that the syntax is perfect. 
        /// </summary>
        public object Evaluate(Func<string, double> lookup)
        {
            //Int for the answer.
            double result;

            // Stacks to hold the expression terms.
            Stack<double> values = new Stack<double>();
            Stack<string> operators = new Stack<string>();

            foreach (string ts in this._tokens)
            {
                try
                {
                    //In the case that it's an integer lets save it as an int.
                    bool is_dbl = Double.TryParse(ts, out Double ts_i);

                    //If + or - pop the value stack twice, the operator stack once. 
                    //Apply operator to values then push output onto value stack.
                    //Push the new operator (+, -) onto the operator stack
                    if (ts == "+" || ts == "-")
                    {
                        if (operators.OnTop("+", "-"))
                        {
                            values.Push(PopTwoEvaluation(values, operators));
                            operators.Push(ts);
                        }
                        else
                        {
                            operators.Push(ts);
                        }
                    }
                    //If ts is *, /, or ( just push onto the operator stack
                    else if (ts == "*" || ts == "/" || ts == "(")
                    {
                        operators.Push(ts);
                    }
                    // If ), first see if there is a (+, -) left on the operator stack.
                    //
                    //After evaluation of the matching parenthesis, see if there is a (*,/) that came before the parenthesis.
                    else if (ts == ")")
                    {
                        if (operators.OnTop("+", "-"))
                        {
                            values.Push(PopTwoEvaluation(values, operators));
                        }
                        if (operators.OnTop("("))
                        {
                            operators.Pop();
                            if (operators.OnTop("*", "/"))
                            {
                                values.Push(PopTwoEvaluation(values, operators));
                            }
                        }
                    }
                    //Check to see if it's a variable or an int. 
                    else if (is_dbl || ValidGenericVariable(ts))
                    {
                        //If it's not an int, then it's a varialbe. Let's save the value using the delegate Lookup. 
                        if (!is_dbl)
                        {
                            ts_i = lookup(ts);
                        }

                        if (operators.OnTop("*", "/"))
                        {
                            double temp_i = values.Peek();
                            values.Pop();
                            values.Push(Operator(operators.Peek(), temp_i, ts_i));
                            operators.Pop();
                        }
                        else
                        {
                            values.Push(ts_i);
                        }
                    }
                }
                catch (Exception e)
                {
                    return new FormulaError(e.Message); // Should always be a division by zero error.
                }
            }
            //Evaluate the stacks after all the terms have been processed.
            int val_count = values.Count;
            int op_count = operators.Count;
            if (op_count == 0 && val_count == 1)
            {
                result = values.Peek();
                values.Pop();
            }
            else
            {
                result = PopTwoEvaluation(values, operators);
            }

            return result;
        }

        /// <summary>
        /// Enumerates the normalized versions of all of the variables that occur in this 
        /// formula.  No normalization may appear more than once in the enumeration, even 
        /// if it appears more than once in this Formula.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        /// 
        /// new Formula("x+y*z", N, s => true).GetVariables() should enumerate "X", "Y", and "Z"
        /// new Formula("x+X*z", N, s => true).GetVariables() should enumerate "X" and "Z".
        /// new Formula("x+X*z").GetVariables() should enumerate "x", "X", and "z".
        /// </summary>
        public IEnumerable<String> GetVariables()
        {
            HashSet<string> ret_hs = new HashSet<string>();
            foreach (string tok in this._tokens)
            {
                if (ValidGenericVariable(tok))
                    ret_hs.Add(tok);
            }
            return ret_hs;
        }

        /// <summary>
        /// Returns a string containing no spaces which, if passed to the Formula
        /// constructor, will produce a Formula f such that this.Equals(f).  All of the
        /// variables in the string should be normalized.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        /// 
        /// new Formula("x + y", N, s => true).ToString() should return "X+Y"
        /// new Formula("x + Y").ToString() should return "x+Y"
        /// </summary>
        public override string ToString()
        {
            string ret = "";
            foreach (string tok in _tokens)
            {
                ret = ret + tok;
            }
            return ret;
        }

        /// <summary>
        /// If obj is null or obj is not a Formula, returns false.  Otherwise, reports
        /// whether or not this Formula and obj are equal.
        /// 
        /// Two Formulae are considered equal if they consist of the same tokens in the
        /// same order.  To determine token equality, all tokens are compared as strings 
        /// except for numeric tokens and variable tokens.
        /// Numeric tokens are considered equal if they are equal after being "normalized" 
        /// by C#'s standard conversion from string to double, then back to string. This 
        /// eliminates any inconsistencies due to limited floating point precision.
        /// Variable tokens are considered equal if their normalized forms are equal, as 
        /// defined by the provided normalizer.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        ///  
        /// new Formula("x1+y2", N, s => true).Equals(new Formula("X1  +  Y2")) is true
        /// new Formula("x1+y2").Equals(new Formula("X1+Y2")) is false
        /// new Formula("x1+y2").Equals(new Formula("y2+x1")) is false
        /// new Formula("2.0 + x7").Equals(new Formula("2.000 + x7")) is true
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Formula)
                return this == (Formula)obj;
            return false;
        }

        /// <summary>
        /// Reports whether f1 == f2, using the notion of equality from the Equals method.
        /// Note that if both f1 and f2 are null, this method should return true.  If one is
        /// null and one is not, this method should return false.
        /// </summary>
        public static bool operator ==(Formula f1, Formula f2)
        {
            if (f1 is null && f2 is null) return true;
            else if (f1 is null || f2 is null) return false;
            else return f1.GetHashCode() == f2.GetHashCode(); // We can use == because GetHashCode() returns and int.;
        }

        /// <summary>
        /// Reports whether f1 != f2, using the notion of equality from the Equals method.
        /// Note that if both f1 and f2 are null, this method should return false.  If one is
        /// null and one is not, this method should return true.
        /// </summary>
        public static bool operator !=(Formula f1, Formula f2)
        {
            return !(f1 == f2);
        }

        /// <summary>
        /// Returns a hash code for this Formula.  If f1.Equals(f2), then it must be the
        /// case that f1.GetHashCode() == f2.GetHashCode().  Ideally, the probability that two 
        /// randomly-generated unequal Formulae have the same hash code should be extremely small.
        /// </summary>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Given an expression, enumerates the tokens that compose it.  Tokens are left paren;
        /// right paren; one of the four operator symbols; a string consisting of a letter or underscore
        /// followed by zero or more letters, digits, or underscores; a double literal; and anything that doesn't
        /// match one of those patterns.  There are no empty tokens, and no token contains white space.
        /// </summary>
        private static IEnumerable<string> GetTokens(String formula)
        {
            // Patterns for individual tokens
            String lpPattern = @"\(";
            String rpPattern = @"\)";
            String opPattern = @"[\+\-*/]";
            String varPattern = @"[a-zA-Z_](?: [a-zA-Z_]|\d)*";
            String doublePattern = @"(?: \d+\.\d* | \d*\.\d+ | \d+ ) (?: [eE][\+-]?\d+)?";
            String spacePattern = @"\s+";

            // Overall pattern
            String pattern = String.Format("({0}) | ({1}) | ({2}) | ({3}) | ({4}) | ({5})",
                                            lpPattern, rpPattern, opPattern, varPattern, doublePattern, spacePattern);

            // Enumerate matching tokens that don't consist solely of white space.
            foreach (String s in Regex.Split(formula, pattern, RegexOptions.IgnorePatternWhitespace))
            {
                if (!Regex.IsMatch(s, @"^\s*$", RegexOptions.Singleline))
                {
                    yield return s;
                }
            }

        }

        /// <summary>
        /// Function to check whether it is a valid operator or not. 
        /// 
        /// If the operator is a '(' we push it on the stack.
        /// If it is a ')' and there is a valid '(' on the stack we will pop it off.
        ///
        /// If the operator is valid then we will return true
        /// else, it could be a variable or number so we will return false and continue to check.
        /// </summary>
        /// <param name="temp_s">The string containing the operator.</param>
        /// <param name="prev_op">Bool is true if the previous token was an operator.</param>
        /// <param name="p_stack">The parenthesis stack.</param>
        /// <returns></returns>
        private static bool CheckIfValidOp(string temp_s, ref bool prev_op, ref int p_stack)
        {
            switch (temp_s)
            {
                case "(":
                    p_stack++;
                    if (!prev_op)
                        throw new FormulaFormatException("Missing operator  before '('");
                    return true;
                case ")":
                    if (--p_stack < 0)
                        throw new FormulaFormatException("Missing '('");
                    if (prev_op)
                        throw new FormulaFormatException("Missing number before ')'");
                    return true;
                case "+":
                case "-":
                case "*":
                case "/":
                    if (prev_op) throw new FormulaFormatException("Missing number before operator");
                    else prev_op = true;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Evaluates if a variable is of the correct generic for.
        /// 
        /// It starts with at least one '_' or a-z, A-Z character.
        /// Then it is followed by zero or more alphanumeric characters, or '_'
        /// </summary>
        /// <param name="var">The variable to be checked.</param>
        /// <returns></returns>
        private static bool ValidGenericVariable(string var)
        {
            return Regex.IsMatch(var, @"^[_a-zA-Z]+[_0-9a-zA-Z]*$");
        }

        /// <summary>
        /// Checks to see if string num is a double. If it is the normalized version of the number is saved in res.
        /// </summary>
        /// <param name="num">The string to see if it parses as a double.</param>
        /// <param name="res">The return string to be used if num parsed successfully</param>
        /// <returns></returns>
        private static bool CheckIfNumber(string num, out string res)
        {
            // See if it is a valid double
            bool is_dbl = Double.TryParse(num, out double result_dbl);
            res = result_dbl.ToString();
            return is_dbl;
        }

        /// <summary>
        /// Make sure that the previous token was some sort of operator token.
        /// 
        /// If it wasn't throw a FormulaFormatException.
        /// If it was, change the boolean to reflect that we had a value (number or variable)
        /// </summary>
        /// <param name="prev_op">Bool which tells what the previous token was. (i.e. operator or value)</param>
        private static void NumberThingsToEvaluate(ref bool prev_op)
        {
            if (!prev_op) throw new FormulaFormatException("Missing operator.");
            prev_op = false;
        }

        /// <summary>
        /// Function to check the general syntax and validate the expression.
        /// 
        /// In this function the expression will be split into seperate tokens.
        /// All variables will be checked for general syntax, normalized with passed delegate, then validated with delegate.
        /// 
        /// Checks invalid syntax with operators, and converts all doubles to a general form.
        /// </summary>
        /// <param name="formula">The formula to be checked.</param>
        /// <param name="normalize">Normalizer for all variables.</param>
        /// <param name="isValid">Validator for all variables.</param>
        /// <returns></returns>
        private static IEnumerable<string> CheckGeneralValidity(string formula, Func<string, string> normalize, Func<string, bool> isValid)
        {
            int parenthesis = 0;
            IEnumerable<string> toks = GetTokens(formula);
            List<string> ret_toks = new List<string>();
            bool prev_op = true;

            if (toks.Count() == 0) throw new FormulaFormatException("No expression to evaluate.");

            foreach (string temp_s in toks)
            {
                if (!CheckIfValidOp(temp_s, ref prev_op, ref parenthesis))
                {
                    if (!CheckIfNumber(temp_s, out string res))
                    {
                        if (!ValidGenericVariable(temp_s))
                            throw new FormulaFormatException("Invalid token: " + temp_s);
                        else
                        {
                            NumberThingsToEvaluate(ref prev_op);
                            string normalized_s = normalize(temp_s);
                            if (ValidGenericVariable(normalized_s))
                            {
                                if (isValid(normalized_s))
                                    ret_toks.Add(normalized_s);
                                else
                                    throw new FormulaFormatException("Invalid variable name.");
                            }
                            else
                                throw new FormulaFormatException("Invalid variable name");
                        }
                    }
                    else
                    {
                        NumberThingsToEvaluate(ref prev_op);
                        ret_toks.Add(res);
                    }
                }
                else
                    ret_toks.Add(temp_s);
            }

            if (parenthesis > 0)
                throw new FormulaFormatException("Missing ')'");
            else if (prev_op)
                throw new FormulaFormatException("Invalid last token.");

            return ret_toks;
        }

        /// <summary>
        /// Function to pop two values off the value stack and operate on them with the top of the operator stack.
        /// This function is to clean up my code from above so nothing redundant is done. 
        /// 
        /// This function will return the result of the operation. 
        /// </summary>
        /// <param name="vals">Values Stack.</param>
        /// <param name="ops">Operators Stack.</param>
        /// <returns></returns>
        private static double PopTwoEvaluation(Stack<double> vals, Stack<string> ops)
        {
            double val1 = vals.Peek();
            vals.Pop();
            double result = Operator(ops.Peek(), vals.Peek(), val1);
            vals.Pop();
            ops.Pop();
            return result;
        }

        /// <summary>
        /// The function Operator is used for simple calculations between two integers. 
        /// Returning a single int, the result of the calculation.
        /// 
        /// This function was kept private because anything outside of this class doesn't need access to it.
        /// </summary>
        /// <param name="op">The operator that will be used to evaluate the two integers.</param>
        /// <param name="var1">The first term of the expression</param>
        /// <param name="var2">The second term of the expression</param>
        /// <returns></returns>
        private static double Operator(string op, double var1, double var2)
        {
            switch (op.Trim())
            {
                case "+":
                    return var1 + var2;
                case "-":
                    return var1 - var2;
                case "*":
                    return var1 * var2;
                default: // Default case is divide '/' because we already know there aren't any invalid operators.
                    if (var2 == 0)
                        throw new ArgumentException("Division by zero.");
                    return var1 / var2;
            }
        }
    }


    /// <summary>
    /// Used to report syntactic errors in the argument to the Formula constructor.
    /// </summary>
    public class FormulaFormatException : Exception
    {
        /// <summary>
        /// Constructs a FormulaFormatException containing the explanatory message.
        /// </summary>
        public FormulaFormatException(String message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// StackExtensions class will hold all extensions that I create for the stack class. 
    /// This class was made in order to simplify the code, and remove repetitive blocks of code.
    /// </summary>
    static class StackExtensions
    {
        /// <summary>
        /// The OnTop method will first check whether the passed stack has a value on it.
        /// Then it will see if the top value is equal to the passed value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ss"></param>
        /// <param name="val">Value to check to see if it's on top.</param>
        /// <returns></returns>
        public static bool OnTop<T>(this Stack<T> ss, T val)
        {
            if (ss.Count < 1)
                return false;
            else if (ss.Peek().Equals(val))
                return true;
            else
                return false;
        }


        /// <summary>
        /// The OnTop method will first check whether the passed stack has a value on it. 
        /// Then it will see if the top value is equal to one of the two passed values. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ss">This is the stack that the .OnTop() method will be called upon.</param>
        /// <param name="val1">The first possible value you want to match to the top of the stack.</param>
        /// <param name="val2">The second possible value you want to match to the top of the stack.</param>
        /// <returns></returns>
        public static bool OnTop<T>(this Stack<T> ss, T val1, T val2)
        {
            if (ss.Count < 1)
                return false;
            else if (ss.Peek().Equals(val1))
                return true;
            else if (ss.Peek().Equals(val2))
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Used as a possible return value of the Formula.Evaluate method.
    /// </summary>
    public struct FormulaError
    {
        /// <summary>
        /// Constructs a FormulaError containing the explanatory reason.
        /// </summary>
        /// <param name="reason"></param>
        public FormulaError(String reason)
            : this()
        {
            Reason = reason;
        }

        /// <summary>
        ///  The reason why this FormulaError was created.
        /// </summary>
        public string Reason { get; private set; }
    }
}