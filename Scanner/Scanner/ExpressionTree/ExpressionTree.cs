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

        public ExpressionTree(string regularExpression, Queue<Node> tokenSource)
        {
            leafCount = 0;
            Root = CreateTree(tokenSource);
            firstLastMatrix = new string[nodeCount, 4];
            followTable = new Dictionary<string, List<int>>();
        }

        public void SetConcatenations(ref Queue<Node> tokenSource)
        {
            Node baseToken;
            Node nextToken;
            int tokenSourceOriginalLenght = tokenSource.Count;
            for (int i = 1; i <= tokenSourceOriginalLenght; i++)
            {
                baseToken = tokenSource.Dequeue();
                nextToken = tokenSource.Peek();
                bool needsConcat = false;

                if (baseToken != null && nextToken != null)
                {
                    switch (baseToken.kindSymbol)
                    {
                        case 0:
                            //terminal symbol
                            if (nextToken.kindSymbol == 0 | nextToken.kindSymbol == 1 | nextToken.kindSymbol == 3)
                                needsConcat = true;
                            break;
                        case 1:
                            //no terminal symbol
                            if (nextToken.kindSymbol == 0 | nextToken.kindSymbol == 1 | nextToken.kindSymbol == 3)
                                needsConcat = true;
                            break;
                        case 2:
                            //operator
                            if (nextToken.kindSymbol == 0 | nextToken.kindSymbol == 1 | nextToken.kindSymbol == 3)
                                needsConcat = true;
                            break;
                        case 3:
                            //open parenthesis
                            needsConcat = false;
                            break;
                        case 4:
                            //closed parenthesis
                            if (nextToken.kindSymbol == 0 | nextToken.kindSymbol == 1 | nextToken.kindSymbol == 3)
                                needsConcat = true;
                            break;
                        default:
                            needsConcat = false;
                            break;
                    }
                
                    if (needsConcat)
                    {
                        //concatenation required
                        Node concat = new Node(".", 2);     //new node with concatenation operator
                        tokenSource.Enqueue(baseToken);     //base token to the end of tokenSource
                        tokenSource.Enqueue(concat);        //concatenation node to the end of tokenSource
                    }
                    else
                    {
                        //no concatenation required
                        tokenSource.Enqueue(baseToken);     //new node with concatenation operator
                    }
                }
            }
        }

        private Node CreateTree(Queue<Node> tokenSource)
        {
            SetConcatenations(ref tokenSource);
            Stack<Node> T = new Stack<Node>(); //Stack of tokens
            Stack<Node> S = new Stack<Node>(); //Stack of trees

            while(tokenSource.Count > 0)
            {
                Node actualToken = tokenSource.Dequeue();

            }

        }

    }
}
