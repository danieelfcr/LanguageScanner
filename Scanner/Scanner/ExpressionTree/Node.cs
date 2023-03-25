using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class Node
    {
        public string symbol;
        public int kindSymbol;
        public Node right;
        public Node left;
        private List<int> firstList;
        private List<int> lastList;
        public bool nullable = false;
        public int leafNumber;

        public Node(string symbol, int kind)
        {
            this.symbol = symbol;
            kindSymbol = kind;
            this.right = null;
            this.left = null;
            firstList = new List<int>();
            lastList = new List<int>();
            this.nullable = false;
            leafNumber = 0;
        }

    }
}
