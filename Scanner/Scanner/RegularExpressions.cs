using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using Scanner.ExpressionTree;
using System.Security;

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
        public Regex tokenRE = new Regex("TOKEN( |\\t)*([1-9][0-9]*)( |\\t)*="); //Expresión regular utilizada para evaluar si una línea corresponde a un token

        //ACTIONS RE---------------------------------------------------------------------------------------------------------
        Regex actionsRE = new Regex("ACTIONS\\s*RESERVADAS\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*(([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*)*");
        Regex actionsToken = new Regex("\\s*([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*");
        Regex actionsFunction = new Regex("([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*");

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
        public string GetRegularExpression(RichTextBox rich, ref Dictionary<int, TokenSummary> tokenSummary, ref int terminalSymbol)
        {
            List<string> tokens = new List<string>();
            int numToken = new int();
            
            int symbolCount = 1;
            string auxLine;

            for (int i = 0; i < rich.Lines.Count(); i++)
            {
                List<int> auxlist = new List<int>();
                if (tokenRE.IsMatch(rich.Lines[i]))
                {
                    auxLine = rich.Lines[i];
                    numToken = Convert.ToInt32(new Regex("[1-9][0-9]*").Match(tokenRE.Match(auxLine).Value).Value);
                    auxLine = tokenRE.Replace(auxLine, string.Empty);

                    TokenSummary auxSummary = new TokenSummary();
                    auxSummary.TokenValue = auxLine.Trim();
                    auxSummary.TokenNumber = numToken;

                    if (new Regex("{\\s*(\\w+\\s*\\(\\s*\\)\\s*)+}").IsMatch(auxLine))
                    {
                        auxSummary.CallMethod = true;
                        auxSummary.Method = new Regex("\\w+").Match(new Regex("{\\s*(\\w+\\s*\\(\\s*\\)\\s*)+}").Match(auxLine).Value).Value;
                    }

                    auxLine = new Regex("{\\s*(\\w+\\s*\\(\\s*\\)\\s*)+}").Replace(auxLine, string.Empty); //expression to delete calls in tokens

                    foreach (Match match in new Regex("'\\S'|[A-Za-z]+").Matches(auxLine))
                    {
                        auxlist.Add(symbolCount);
                        symbolCount++;
                    }

                    auxSummary.token_States = auxlist;
                    tokenSummary.Add(numToken, auxSummary);
                    tokens.Add(auxLine.Trim());
                }
            }
            terminalSymbol = symbolCount;
            //create re with extended Symbol
            string re = "";
            re += "(";
            re += string.Join('|', tokens.ToArray());
            re += ")";
            re += "'#'";
            return re;
        }

        public Queue<Node> GetQueueExpression(string expression, ref List<string> symbols)
        {
            List<Node> listExpression = new List<Node>();
            Node auxNode;
            string auxChar;
            string tempSymbol = "";
            Regex letter = new Regex("[a-zA-Z]");               //No Terminal Symbols expresion

            for (int i = 0; i < expression.Length; i++)
            {
                //First step, create the node with the actual read from expression
                auxChar = expression[i].ToString();

                if (auxChar != " " && auxChar != "\t")
                {
                    if (letter.IsMatch(auxChar))               //No Terminal Symbol case
                    {
                        tempSymbol = ""; //Reset temp variable
                        while (letter.IsMatch(auxChar) && i < expression.Length)
                        {
                            tempSymbol += auxChar;
                            i++;
                            if (i < expression.Length)
                            {
                                auxChar = expression[i].ToString();
                            }
                        }
                        i--;
                        auxNode = new Node(tempSymbol, 1);
                        if (!symbols.Contains(auxNode.symbol) && auxNode.symbol != "'#'")
                        {
                            symbols.Add(auxNode.symbol);
                        }
                    }
                    else if (auxChar == "'")                        //Terminal symbol case
                    {
                        tempSymbol = "";    //Reset temp value
                        tempSymbol += auxChar;
                        tempSymbol += expression[i + 1].ToString();
                        tempSymbol += expression[i + 2].ToString();

                        i += 2;
                        auxNode = new Node(tempSymbol, 0);
                        if (!symbols.Contains(auxNode.symbol) && auxNode.symbol != "'#'")
                        {
                            symbols.Add(auxNode.symbol);
                        }
                    }
                    else //("?" | "+" | "*" | "|" | "(" | ")")    //Operator case
                    {
                        int auxKind;
                        if (auxChar == "(")
                        {
                            auxKind = 3;
                        }
                        else if (auxChar == ")")
                        {
                            auxKind = 4;
                        }
                        else
                        {
                            auxKind = 2;
                        }
                        auxNode = new Node(auxChar, auxKind);
                    }

                    //SecondStep, evaluate if is necessary to add a concatenation   0 - terminal, 1 - no terminal, 2 - (+,*,|,?), 3 = (, 4 = )

                    if (listExpression.Count > 0)
                    {
                        Node preNode = listExpression[listExpression.Count - 1];

                        if (auxNode.kindSymbol == 0 | auxNode.kindSymbol == 1 | auxNode.kindSymbol == 3)
                        {
                            if (preNode.kindSymbol != 3)
                            {
                                if (preNode.symbol != "|")
                                {
                                    listExpression.Add(new Node(".", 2));
                                }
                            }
                        }
                    }

                    //Add actual read symbol to the list
                    listExpression.Add(auxNode);
                }
            }


            Queue<Node> queueExpression = new Queue<Node>();
            foreach (Node node in listExpression)
            {
                queueExpression.Enqueue(node);
            }

            return queueExpression;
        }

        /// <summary>
        /// Function to obtain the Actions Functions used to write the code specify method in code generator process
        /// </summary>
        /// <param name="grammar">The complete grammar inserted</param>
        /// <returns>A string list that contains all the text from all functions in Actions</returns>
        public List<string> GetActionFunctions(string grammar)
        {
            List<string> functions = new List<string>();
            if (actionsFunction.IsMatch(grammar))
            {
                foreach (Match match in actionsFunction.Matches(grammar))
                {
                    functions.Add(match.Value);
                }
            }
            return functions;
        }
    }
}
