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
    }
}
