using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using Scanner.ExpressionTree;

namespace Scanner
{
    internal class RegularExpressions
    {
        string error = "";

        //SETS RE
        Regex setsRE = new Regex("(\\s*SETS(\\s)+((\\s)*([A-Z])+( |\\t)*=( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?)(( |\\t)*\\+( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?))*)+\\s*)?");
        Regex setsREVerify = new Regex("^(\\s*SETS(\\s)+((\\s)*([A-Z])+( |\\t)*=( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?)(( |\\t)*\\+( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?))*)+\\s*)$");


        //TOKENS RE---------------------------------------------------------------------------------------------------------
        Regex tokensRE = new Regex("\\s*TOKENS\\s*\\n(\\s*TOKEN( |\\t)*([1-9][0-9]*)( |\\t)*=( |\\t)*(((( |\\t)*{( |\\t)*([A-Z]+( |\\t)*\\(( |\\t)*\\)( |\\t)*)+( |\\t)*}( |\\t)*)|(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))|(( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*)|(\\(( |\\t)*(((([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)|(( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*)|(\\(( |\\t)*(((([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)|(( |\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*))+\\)( |\\t)*(\\*|\\+|\\?)?))+\\)( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)+)+\\s*");
        Regex tokenRE = new Regex("TOKEN( |\\t)*([1-9][0-9]*)( |\\t)*="); //Expresión regular utilizada para evaluar si una línea corresponde a un token

        //ACTIONS RE---------------------------------------------------------------------------------------------------------
        Regex actionsRE = new Regex("ACTIONS\\s*RESERVADAS\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*(([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*)*");
        Regex actionsToken = new Regex("(\\s*([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+");
        Regex actionsFunction = new Regex("(([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*)*");

        //ERROR RE-----------------------------------------------------------------------------------------------------------
        Regex errorRE = new Regex("([A-Z]*ERROR\\s*=\\s*[1-9][0-9]*\\s*)+");

        /// <summary>
        /// The Proc idea is to validate at least the section where the error come form. First getting error in the entire mainRegex, so then evaluate the individual RE for each section.
        /// </summary>
        /// <param name="file">It refers to the text contain in the file</param>
        /// <param name="rich">It refers to the visual object that contains the information</param>
        public string GetSectionError(string file, RichTextBox rich)
        {
            
            //If is true, means that se actions SECTION do not match with the text, here exist an error who knows where at he moment
            if (file.Contains("SETS")) 
            {
                string setsAux = "";
                for (int i = 0; i < rich.Lines.Count(); i++)
                {
                    if (!rich.Lines[i].Contains("TOKENS"))
                        setsAux += rich.Lines[i];
                    else
                        break;
                }
                if (!setsREVerify.IsMatch(setsAux))
                    error += "Sets section has an error.\n"; 
            }
            if (!tokensRE.IsMatch(file)) { error += "Tokens section has an error.\n"; }
            if (!actionsRE.IsMatch(file)) { error += "Actions section has an error.\n"; }
            if (!errorRE.IsMatch(file)) { error += "Errors section has a syntaxis error.\n"; }
            return error;
        }

        public bool evaluateGrammar(string text)
        {
            TimeSpan timeOut = new TimeSpan(0, 0, 3);
            Regex GrammarRegex = new Regex("^(" + setsRE.ToString() + tokensRE.ToString() + actionsRE.ToString() + errorRE.ToString() + ")$", RegexOptions.None, timeOut);
            try
            {
                return GrammarRegex.IsMatch(text);
            }
            catch(RegexMatchTimeoutException ex)
            {
                error += "Tokens section has an error.\n";
                return false;
            }
        }

        /// <summary>
        /// function to get te regular expression to build the expression tree, using line by line method
        /// </summary>
        /// <param name="rich">Richtextbox that contains the grammar and it can be access line by line</param>
        /// <returns></returns>
        public string GetRegularExpression(RichTextBox rich)
        {
            List<string> tokens = new List<string>();
            string auxLine;
            for (int i = 0; i < rich.Lines.Count(); i++)
            {
                if (tokenRE.IsMatch(rich.Lines[i]))
                {
                    auxLine = rich.Lines[i];
                    auxLine = tokenRE.Replace(auxLine, string.Empty);
                    auxLine = new Regex("{\\s*(\\w+\\s*\\(\\s*\\)\\s*)+}").Replace(auxLine, string.Empty); //expression to delete calls in tokens
                    tokens.Add(auxLine.Trim());
                }
            }
            //create re with extended Symbol
            string re = "";
            re += "(";
            re += string.Join('|', tokens.ToArray());
            re += ")";
            re += "#";
            return re;
        }

        public Queue<Node> GetQueueExpression(string expression)
        {
            Queue<Node> queueExpression = new Queue<Node>();
            Regex letter = new Regex("[a-zA-Z]");           //No Terminal Symbols expresion
            string auxChar;
            string nextChar;
            string lastChar;
            for (int i = 0; i < expression.Length; i++)
            {
                auxChar = expression[i].ToString();

                if (auxChar == " " | auxChar == "\t")
                {
                    if ((i + 1) < expression.Length)
                    {
                        nextChar = expression[i + 1].ToString();

                        if (nextChar != "" | nextChar != "\t")
                        {
                            //evaluar si es un terminal o no terminal, parénteis o un agrupador
                        }
                    }
                }
                else if (auxChar == "?" | auxChar == "+" | auxChar == "*" | auxChar == "|" | auxChar == "(" | auxChar == ")")
                {
                    Node auxNode = new Node(auxChar, null, null, false);
                    if ()
                    {

                    }
                    queueExpression.Enqueue(auxNode);
                }
                else if (letter.IsMatch(auxChar))
                {
                    string tempSymbol = "";
                    while (letter.IsMatch(auxChar))
                    {
                        tempSymbol += auxChar;
                        i++;
                        if (i < expression.Length)
                        {
                            auxChar = expression[i].ToString();
                        }
                         
                    }
                }
            }
            return queueExpression;
        }

    }
}
