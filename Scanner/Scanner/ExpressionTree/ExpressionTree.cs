using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ExpressionTree
{
    public class ExpressionTree
    {
        public Node Root;
        public int leafCount;
        public int nodeCount;
        public string[,] firstLastMatrix;
        private Dictionary<string, List<int>> followTable; //symbol, follow list
        
        private Dictionary<string, int> operatorHierarchy = new Dictionary<string, int>() //symbol, number in the hierarchy
        {
            {"|", 1},
            {".", 2},
            {"*", 3},
            {"+", 4},
            {"?", 5},
            {"(", 6},
            {")", 7},
        }; 

        public ExpressionTree(string regularExpression)
        {
            leafCount = 0;
            
            firstLastMatrix = new string[nodeCount, 4];
            followTable = new Dictionary<string, List<int>>();
        }

        void PostOrder(Node node, int op)
        {
            if (node != null)
            {
                PostOrder(node.left, op);
                PostOrder(node.right, op);
                switch (op)
                {
                    case 0:
                        AssignNullable(node);
                        break;
                    case 1:
                        AssignFirstLast(node);
                        break;
                }
            }
        }

        //Llamar a este metodo para iniciar operaciones. "OP" es la operacion que se desea realizar "Nullable, First/Last, Follow"
        public void PostOrder(int op)
        {
            PostOrder(this.Root, op);
        }

        void AssignNullable(Node node)
        {
            //If node is leaf, it is not nullable
            if (node.left == null && node.right == null)
            {
                node.nullable = false;
                return;
            }
            else
            {
                switch (node.symbol)
                {
                    case "|":
                        if (node.left.nullable == true || node.right.nullable == true)
                        {
                            node.nullable = true;
                        }
                        break;

                    case ".":
                        if (node.left.nullable == true && node.right.nullable == true)
                        {
                            node.nullable = true;
                        }
                        break;

                    case "*":
                        node.nullable = true;
                        break;

                    case "+":
                        if (node.left.nullable == true)
                        {
                            node.nullable = true;
                        }
                        break;

                    case "?":
                        node.nullable = true;
                        break;

                    default:
                        node.nullable = false;
                        break;
                }
            }
            return;
        }
        void AssignFirstLast(Node node)
        {
            //If node is leaf, assign its number as first
            if (node.left == null && node.right == null)
            {
                //First
                node.firstList.Add(node.leafNumber);
                //Last
                node.lastList.Add(node.leafNumber);
                return;
            }
            else
            {
                switch (node.symbol)
                {
                    case "|":
                        //First
                        node.firstList.AddRange(node.left.firstList);
                        node.firstList.AddRange(node.right.firstList);
                        //Last
                        node.lastList.AddRange(node.left.lastList);
                        node.lastList.AddRange(node.right.lastList);
                        break;

                    case ".":
                        //First
                        if (node.left.nullable == true)
                        {
                            node.firstList.AddRange(node.left.firstList);
                            node.firstList.AddRange(node.right.firstList);
                        }
                        else
                        {
                            node.firstList.AddRange(node.left.firstList);
                        }

                        //Last
                        if (node.right.nullable == true)
                        {
                            node.lastList.AddRange(node.left.lastList);
                            node.lastList.AddRange(node.right.lastList);
                        }
                        else
                        {
                            node.lastList.AddRange(node.right.lastList);
                        }
                        break;

                    case "*":
                        //First
                        node.firstList.AddRange(node.left.firstList);
                        //Last
                        node.lastList.AddRange(node.left.lastList);
                        break;

                    case "+":
                        //First
                        node.firstList.AddRange(node.left.firstList);
                        //Last
                        node.lastList.AddRange(node.left.lastList);
                        break;

                    case "?":
                        //First
                        node.firstList.AddRange(node.left.firstList);
                        //Last
                        node.lastList.AddRange(node.left.lastList);
                        break;
                }
            }
            return;
        }

    }
}
