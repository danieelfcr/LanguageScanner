using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scanner
{
    internal class RegularExpressions
    {
        //SETS RE
        Regex setsRE = new Regex("(\\s*SETS(\\s)+((\\s)*([A-Z])+( |\\t)*=( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?)(( |\\t)*\\+( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?))*)+\\s*)?");
        Regex setsREVerify = new Regex("^(\\s*SETS(\\s)+((\\s)*([A-Z])+( |\\t)*=( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?)(( |\\t)*\\+( |\\t)*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|([0-9])([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?))*)+\\s*)$");


        //TOKENS RE---------------------------------------------------------------------------------------------------------
        Regex tokensRE = new Regex("\\s*TOKENS\\s*\\n(\\s*TOKEN( |\\t)*([1-9][0-9]*)( |\\t)*=( |\\t)*(((( |\\t)*{( |\\t)*([A-Z]+( |\\t)*\\(( |\\t)*\\)( |\\t)*)+( |\\t)*}( |\\t)*)|(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))|(( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*)|(\\(( |\\t)*(((([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)|(( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*)|(\\(( |\\t)*(((([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)|(( |\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))+( |\\t)*\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?))( |\\t)*(\\|( |\\t)*(([A-Z]+( |\\t)*(\\*|\\+|\\?)?)|('\\S'( |\\t)*(\\*|\\+|\\?)?)( |\\t)*)+)*))+\\)( |\\t)*(\\*|\\+|\\?)?))+\\)( |\\t)*(\\*|\\+|\\?)?))( |\\t)*)+)+\\s*");

        //ACTIONS RE---------------------------------------------------------------------------------------------------------
        Regex actionsRE = new Regex("ACTIONS\\s*RESERVADAS\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*(([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*)*");
        Regex actionsToken = new Regex("(\\s*([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+");
        Regex actionsFunction = new Regex("(([A-Z]|[a-z])+\\s*\\(\\s*\\)\\s*{\\s*(([0-9]|([1-9][0-9]*))\\s*=\\s*'([A-Z]|[a-z])+'\\s*)+}\\s*)*");

        //ERROR RE-----------------------------------------------------------------------------------------------------------
        Regex errorRE = new Regex("\\s*([A-Z]*ERROR\\s*=\\s*[1-9][0-9]*\\s*)+");

        /// <summary>
        /// The Proc idea is to validate at least the section where the error come form. First getting error in the entire mainRegex, so then evaluate the individual RE for each section.
        /// </summary>
        /// <param name="file">It refers to the text contain in the file</param>
        public string GetSectionError(string file, RichTextBox rich)
        {
            string error = "";
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
                return false;
            }
        }
    }
}
