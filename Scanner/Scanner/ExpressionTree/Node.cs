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

        //0 is terminal, 1 is no terminal, 2 is operator, 3 is grouper
        public int typeSymbol { get; set; }

        public Node right { get; set; }

        public Node left { get; set; }

        private List<int> firstList;

        private List<int> lastList;

        public bool nullable = false;

        public int leafNumber;

        public Node(string symbol, Node right, Node left, bool nullable)
        {
            this.symbol = symbol;
            this.right = right;
            this.left = left;
            firstList = new List<int>();
            lastList = new List<int>();
            this.nullable = nullable;
            leafNumber = 0;
        }

    }
}
