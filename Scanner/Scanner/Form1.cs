using Scanner.ExpressionTree;
using System.IO;

namespace Scanner
{
    public partial class Form1 : Form
    {
        string text;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Txt Files|*.txt";
                openFileDialog1.Title = "Select File";
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                string filePath = openFileDialog1.FileName;
                tBFilePath.Text = filePath;
                btnAnalyze.Enabled = true;
                readText(filePath);
                MessageBox.Show("File was uploaded succesfully!");
                rTBResult.Text = text;
                rTBResult.BackColor = Color.White;
            }
        }

        private void readText(string filePath)
        {
            try
            {
                text = "";
                StreamReader sr = new StreamReader(filePath);
                text = sr.ReadToEnd();
                sr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("An error has occured \nError: " + e.Message);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            RegularExpressions RegularEx = new RegularExpressions();
           
            if (RegularEx.evaluateGrammar(text))
            {
                MessageBox.Show("Grammar is correctly defined");
                rTBResult.BackColor = Color.Green;
                
                List<string> symbols = new List<string>();

                Queue<Node> tokensQueue = RegularEx.GetQueueExpression(RegularEx.GetRegularExpression(rTBResult), ref symbols);
                ExpressionTree.ExpressionTree expressionTree = new ExpressionTree.ExpressionTree(tokensQueue);
                expressionTree.PostOrder(0); //assign nullable
                expressionTree.PostOrder(1); //assign first and last
                expressionTree.PostOrder(2); //assign follows
            }
            else
            {
                MessageBox.Show("ERROR, grammar is not correctly defined:\n" + RegularEx.GetSectionError(text, rTBResult));
                rTBResult.BackColor = Color.Red;
            }


        }
    }
}