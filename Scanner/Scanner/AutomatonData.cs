using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }


        private void FollowOutput()
        {
            for(int i = 1; i <= expressionTree.followDictionary.Count; i++)
            {
                List<int> followList = expressionTree.followDictionary[i].followList;
                string tempList = string.Join(',', followList.ToArray());
                dGVFollow.Rows.Add(i + " (" +expressionTree.followDictionary[i].symbol + ")", tempList);
            }
        }
    }
}
