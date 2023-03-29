using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scanner.ExpressionTree;

namespace Scanner
{
    public partial class AutomatonData : Form
    {
        ExpressionTree.ExpressionTree expressionTree;

        public AutomatonData(ExpressionTree.ExpressionTree expressionTree)
        {
            InitializeComponent();
            this.expressionTree = expressionTree;
            FollowOutput();
            FirstLastOutput();
            TransitionsOutput();
        }


        private void FollowOutput()
        {
            dGVFollow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for(int i = 1; i <= expressionTree.followDictionary.Count; i++)
            {
                List<int> followList = expressionTree.followDictionary[i].followList;
                string tempList = string.Join(',', followList.ToArray());
                dGVFollow.Rows.Add(i + " (" +expressionTree.followDictionary[i].symbol + ")", tempList);
            }
        }

        private void FirstLastOutput()
        {
            dGVFirstLastNullable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            expressionTree.PostOrder(3);

            // Determine the total length of the one-dimensional array
            int totalLength = expressionTree.firstLastMatrix.GetLength(0) * expressionTree.firstLastMatrix.GetLength(1);

            // Declare the one-dimensional array
            String[] oneDimensionalArray = new String[totalLength];

            // Traverse the matrix and copy each element into the one-dimensional array
            int index = 0;
            for (int row = 0; row < expressionTree.firstLastMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < expressionTree.firstLastMatrix.GetLength(1); column++)
                {
                    oneDimensionalArray[index] = expressionTree.firstLastMatrix[row, column];
                    index++;
                }
            }

            for (int i = 0; i < oneDimensionalArray.Length; i=i+4)
            {
                dGVFirstLastNullable.Rows.Add(oneDimensionalArray[i], oneDimensionalArray[i+1], oneDimensionalArray[i+2], oneDimensionalArray[i+3]);
            }
        }

        private void TransitionsOutput()
        {
            try
            {
                //Adjust matrix to fill the size of the content in the matrix
                dGVTransitions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //Add header of the transition table
                dGVTransitions.Columns.Add("Column0", "States");    //Add first column header, states
                for (int i = 0; i < expressionTree.symbols.Count; i++)
                {
                    dGVTransitions.Columns.Add("Column" + (i + 1).ToString(), expressionTree.symbols[i]);
                }

                List<string> auxList = new List<string>();
                int j = 0;
                foreach (var states in expressionTree.transitions)
                {
                    string S = string.Format("S{0} = [{1}]", j, states.Key);      //String with the key of the actual state

                    auxList.Clear();            //Reset auxiliar list
                    auxList.Add(S);             //Add the string for the state

                    //Process to add to the auxiliar list all the transitons in the list of each symbol
                    foreach (var transition in states.Value.Transition)
                    {
                        string temp = "";
                        if (transition.Value.Count > 0)
                        {
                            temp = string.Join(',', transition.Value.ToArray());
                        }
                        else
                        {
                            temp = "-";
                        }
                        auxList.Add(temp);
                    }

                    j++;
                    dGVTransitions.Rows.Add(auxList.ToArray());     //Add a complete row
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has ocurred: " + ex.Message);
            }
            
        }

        private void dGVFirstLastNullable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
