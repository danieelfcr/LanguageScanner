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
        public int actualRow;
        public List<string> symbols { get; set; }           //Variable to contain the present symbols in the grammar
        
        public Dictionary<int, Follow> followDictionary; //key = follow id (symbol id) value = follow object

        public string[,] firstLastMatrix;

        private Dictionary<string, List<int>> followTable; //symbol, follow list

        public Dictionary<string, TransitionSummary> transitions { get; set; }

        public int terminalSymbol { get; set; }         //It refers to the number that represents the terminal symbol in the follow calculate

        public Dictionary<int, List<int>> token_State { get; set; }     //Dictionary to save the information that join tokens with states, key = # od token, value = numbers that represents the symbols used in the states

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
            leafCount = 1;
            actualRow = 0;
            nodeCount = 0;
            followDictionary = new Dictionary<int, Follow>();
            Root = CreateTree(tokenSource);
            firstLastMatrix = new string[nodeCount, 4];
            followTable = new Dictionary<string, List<int>>();
            transitions = new Dictionary<string, TransitionSummary>();
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
                    case 2:
                        AssignFollows(node);
                        break;
                    case 3:
                        FillMatrix(node);
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

        void AssignFollows(Node node)
        {
            //If node is not a leaf then check what symbol it has
            if (node.left != null || node.right != null)
            {
                switch (node.symbol)
                {
                    //The only symbols that cannot be part of the algorithm are '|' and '?' 
                    case ".":
                        CombinationFollow(node.left.lastList, node.right.firstList);
                        break;
                    case "*":
                        CombinationFollow(node.left.lastList, node.left.firstList);
                        break;
                    case "+":
                        CombinationFollow(node.left.lastList, node.left.firstList);
                        break;          
                }
            }
        }

        private void CombinationFollow(List<int> c1, List<int> c2)
        {
            //iteration of all elements in c1 
            for (int i = 0; i < c1.Count; i++)
            {
                //iteration of all elements in c2
                for (int j = 0; j < c2.Count; j++)
                {
                    followDictionary[c1[i]].insertFollow(c2[j]);
                }
            }
        }

        void FillMatrix(Node node)
        {
            firstLastMatrix[actualRow, 0] = node.symbol;
            firstLastMatrix[actualRow, 1] = string.Join(",", node.firstList);
            firstLastMatrix[actualRow, 2] = string.Join(",", node.lastList);
            firstLastMatrix[actualRow, 3] = node.nullable.ToString();
            actualRow++;
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
                    nodeCount++;
                    //terminal / no terminal
                    Node st = actualToken;
                    st.leafNumber = leafCount;

                    //creation of a new Follow object
                    Follow follow = new Follow(st.symbol);
                    followDictionary.Add(leafCount, follow);
                    leafCount++;
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
                    nodeCount++;
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

        //public Dictionary<int, Follow> followDictionary; //key = follow id (symbol id) value = follow object
        //public Dictionary<string, TransitionSummary> transitions { get; set; }
        public void MakeTransitions()
        {
            //Validate if exist values to make the process
            if (Root != null && Root.firstList.Count > 0)
            {
                //Create the first state, the first of the tree
                string temp = string.Join(',', Root.firstList.ToArray());
                bool isFinalState = false;
                TransitionSummary auxTransition = new TransitionSummary(symbols);
                auxTransition.State = Root.firstList;
                transitions.Add(temp, auxTransition);

                Queue<string> auxTransitionQueue = new Queue<string>(); //Queue to set a transition queue where the unworked states are in
                auxTransitionQueue.Enqueue(temp);

                //Iterative process with each state
                while (auxTransitionQueue.Count > 0)
                {
                    temp = auxTransitionQueue.Peek();
                    //Process to put all the elements of transition for one state in the determine state
                    foreach (int value in transitions[temp].State)
                    {
                        string auxActualSymbol = followDictionary[value].symbol;
                        List<int> auxActualFollow = followDictionary[value].followList;

                        //Foreach of the elments of the follow try to insert to the list in transitions
                        foreach (int x in auxActualFollow)
                        {
                            //The element is added only if doesn't exist
                            if (!transitions[temp].Transition[auxActualSymbol].Contains(x))
                            {
                                transitions[temp].Transition[auxActualSymbol].Add(x);
                            }
                        }
                        //Validation the the sort is not making in the extended symbol from the expression
                        if (transitions[temp].Transition.ContainsKey(auxActualSymbol))
                        {
                            transitions[temp].Transition[auxActualSymbol].Sort();
                        }
                    }

                    //Process to evaluate if exist new state form the before process en added to a queue to be operated
                    foreach (var value in transitions[temp].State)
                    {
                        string S = followDictionary[value].symbol;
                        if (transitions[temp].Transition.ContainsKey(S))
                        {
                            string key = string.Join(',', transitions[temp].Transition[S].ToArray());
                            if (!transitions.ContainsKey(key))
                            {
                                TransitionSummary newTransition = new TransitionSummary(symbols);
                                newTransition.State = transitions[temp].Transition[S];
                                //if (transitions[temp].Transition[S].Contains('#'))
                                //{

                                //}
                                transitions.Add(key, newTransition);
                                auxTransitionQueue.Enqueue(key);
                            }
                        }
                    }

                    auxTransitionQueue.Dequeue();
                }
            }
        }
    }
}
