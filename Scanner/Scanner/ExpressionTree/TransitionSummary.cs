using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class TransitionSummary
    {
        public List<int> State { get; set; }
        public Dictionary<string, List<int>> Transition { get; set; }

        public TransitionSummary(List<string> symbols)
        {
            Transition = new Dictionary<string, List<int>>();
            State = new List<int>();
            foreach (string symbol in symbols)
            {
                Transition.Add(symbol, new List<int>());
            }
        }
    }
}
