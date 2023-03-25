using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class Node
    {
        public string symbol { get; set; }

        /// <summary>
        ///0 is terminal, 1 is no terminal, 2 is operator, 3 is open parenthesis, 4 is a closed parenthesis 
        /// </summary>
        public int kindSymbol { get; set; }

        public Node right { get; set; }

        public Node left { get; set; }

        private List<int> firstList;

        private List<int> lastList;

        public bool nullable = false;

        public int leafNumber;


        /// <summary>
        /// Constructor to create a new node where set default values and key values
        /// </summary>
        /// <param name="symbol">string that contains the read symbol</param>
        /// <param name="kind"> it refers to the kind of the symbol, like: 0 - terminal, 1 - no terminal, 2 - (+,*,|,?), 3 = (, 4 = )</param>
        public Node(string symbol, int kind)
        {
            this.symbol = symbol;
            this.kindSymbol = kind;
            this.right = null;
            this.left = null;
            firstList = new List<int>();
            lastList = new List<int>();
            this.nullable = false;
            leafNumber = 0;
        }
    }
}
