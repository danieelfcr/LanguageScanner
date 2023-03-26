using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ExpressionTree(Queue<Node> tokenSource)
        {
            leafCount = 0;
            Root = CreateTree(tokenSource);
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

        

        private Node CreateTree(Queue<Node> tokenSource)
        {
            Stack<Node> T = new Stack<Node>(); //Stack of tokens
            Stack<Node> S = new Stack<Node>(); //Stack of trees

            while(tokenSource.Count > 0)
            {
                Node actualToken = tokenSource.Dequeue();
                if (actualToken.kindSymbol == 0 || actualToken.kindSymbol == 1)
                {
                    //terminal / no terminal
                    Node st = actualToken;
                    S.Push(st);    //push in stack of trees
                }
                else if (actualToken.kindSymbol == 3)
                {
                    //open parenthesis
                    Node token = actualToken;
                    T.Push(token);    //push in stack of tokens
                }
                else if (actualToken.kindSymbol == 4)
                {
                    //closed parenthesis
                    while (T.Count > 0 && T.Peek().kindSymbol != 3)
                    {
                        if (T.Count == 0)
                        {
                            MessageBox.Show("Error, missing operands");
                            break;
                        }
                        if (S.Count < 2)
                        {
                            MessageBox.Show("Error, missing operands");
                            break;
                        }
                            
                        
                        Node temp = T.Pop();
                        temp.right = S.Pop();
                        temp.left = S.Pop();
                        S.Push(temp);
                    }

                    T.Pop();
                }
                else if (actualToken.kindSymbol == 2)   //is an operator token?
                {
                    
                    if (actualToken.symbol == "*" || actualToken.symbol == "+" || actualToken.symbol == "?") 
                    {
                        //Unary operator
                        Node op = actualToken;
                        if (S.Count < 0)
                        {
                            MessageBox.Show("Error, missing operands");
                            break;
                        }

                        op.left = S.Pop();
                        S.Push(op);
                    }
                    else if (T.Count != 0 && T.Peek().kindSymbol != 3 && (operatorHierarchy[actualToken.symbol] <= operatorHierarchy[T.Peek().symbol]))
                    {
                        Node op = actualToken;
                        Node temp = T.Pop();
                        T.Push(op);

                        if (S.Count < 2)
                        {
                            MessageBox.Show("Error, missing operands");
                            break;
                        }

                        temp.right = S.Pop();
                        temp.left = S.Pop();
                        S.Push(temp);
                    }
                    else
                    {
                        T.Push(actualToken);
                    }
                }
                else
                {
                    MessageBox.Show("Error, unknown operator");
                }
            }

            while (T.Count > 0)
            {
                Node temp = T.Pop();
                if (temp.kindSymbol == 3)
                {
                    MessageBox.Show("Error, missing operands");
                    break;
                }
                if (S.Count < 2)
                {
                    MessageBox.Show("Error, missing operands");
                    break;
                }

                temp.right = S.Pop();
                temp.left = S.Pop();
                S.Push(temp);
            }

            if (S.Count != 1)
            {
                MessageBox.Show("Error, missing operands");
                return null;
            }
            else
            {
                return S.Pop();
            }
        }
    }
}
