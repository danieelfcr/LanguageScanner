using Scanner.ExpressionTree;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.InteropServices;

namespace Scanner
{
    public partial class Form1 : Form
    {
        public static string text = "";
        public Form1()
        {
            InitializeComponent();
        }

        public string fileName;

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
                fileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Replace(" ", "_");
            }
        }

        private void readText(string filePath)
        {
            try
            { 
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
                
                List<string> symbols = new List<string>();  //List to know all the different symbols for the grammar
                Dictionary<int, TokenSummary> tokenSummary = new Dictionary<int, TokenSummary>();      //Dictionary used to refer a token to a group of values that describes a state
                int terminalSymbol = new int();

                Queue<Node> tokensQueue = RegularEx.GetQueueExpression(RegularEx.GetRegularExpression(rTBResult, ref tokenSummary, ref terminalSymbol), ref symbols);
                ExpressionTree.ExpressionTree expressionTree = new ExpressionTree.ExpressionTree(tokensQueue, symbols, tokenSummary, terminalSymbol);
                expressionTree.PostOrder(0); //assign nullable
                expressionTree.PostOrder(1); //assign first and last
                expressionTree.PostOrder(2); //assign follows
                expressionTree.MakeTransitions();

                AutomatonData AD = new AutomatonData(expressionTree);
                AD.Show();

                //creation of the CodeGenerator class
                CodeGenerator cd = new CodeGenerator(expressionTree, fileName, RegularEx.GetActionFunctions(rTBResult.Text));
            }
            else
            {
                MessageBox.Show("ERROR, grammar is not correctly defined:\n" + RegularEx.GetSectionError(text, rTBResult));
                rTBResult.BackColor = Color.Red;
            }


        }
    }
}