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
        //Dictionary where the key refer to the symbol y transition to the group of numbres that represents a transition
        public Dictionary<string, List<int>> Transition { get; set; }
        public bool IsFinalState { get; set; }
        public int StateNumber { get; set; }

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
