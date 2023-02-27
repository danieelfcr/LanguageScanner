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
                MessageBox.Show("Somos geniales");
                rTBResult.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("ERROR, gramática no bien definida:\n" + RegularEx.GetSectionError(text, rTBResult));
                rTBResult.BackColor = Color.Red;
            }


        }
    }
}