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
        //MAIN Regular Expression
        Regex mainRegex = new Regex("");

        //SETS RE


        //TOKENS RE


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
        public void GetSectionError(string file)
        {
            string error = "";
            //If is true, means that se actions SECTION do not match with the text, here exist an error who knows where at he moment
            if (!actionsRE.IsMatch(file))
            {
                //Error in this sections
                //Still thinkig how to express the error here
            }
            if (!errorRE.IsMatch(file))
            {
                error += "Se ha definido incorrectamente algún error";
            }
        }
    }
}
