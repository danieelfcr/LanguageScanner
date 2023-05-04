using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class TokenSummary
    {
        public int TokenNumber { get; set; }            //Number that represents the state

        public List<int> token_States { get; set; }     //Dictionary to save the information that join tokens with states, key = # od token, value = numbers that represents the symbols used in the states

        public string TokenValue { get; set; }

        public bool CallMethod { get; set; }

        public string Method { get; set; }
    }
}
