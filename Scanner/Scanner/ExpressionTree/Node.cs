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
        public Node right;
        public Node left;
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
