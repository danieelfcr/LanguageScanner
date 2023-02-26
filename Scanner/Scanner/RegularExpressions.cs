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
        //SETS RE------------------------------------------------------------------------------------------------------------
        Regex setsRE = new Regex("(SETS(\\s)+((\\s)*([A-Z])+( )*=( )*('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?)(\\+('([a-z])'\\.\\.'([a-z])'|'([A-Z])'\\.\\.'([A-Z])'|'.'|'([0-9])'\\.\\.'([0-9])'|CHR\\((([0-9])|([0-9])([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\)(\\.\\.CHR\\((([0-9])|0([0-9])|0([0-9])([0-9])|1([0-9])([0-9])|2([0-5])([0-5]))\\))?))*)+\\s*)?");

        //TOKENS RE----------------------------------------------------------------------------------------------------------


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
        public string GetSectionError(string file)
        {
            string error = "";
            //If is true, means that se actions SECTION do not match with the text, here exist an error who knows where at he moment
            if (!setsRE.IsMatch(file)) { error += "La sección actions contiene un error.\n"; }
            if (!actionsRE.IsMatch(file)) { error += "La sección de ACTIONS contiene un error.\n"; }
            if (!errorRE.IsMatch(file)) { error += "Se ha definido incorrectamente algún error.\n"; }
            return error;
        }

        public bool evaluateGrammar(string text)
        {
            Regex GrammarRegex = new Regex("^("+setsRE.ToString()+actionsRE.ToString()+errorRE.ToString()+")$");
            return GrammarRegex.IsMatch(text);
        }
    }
}
