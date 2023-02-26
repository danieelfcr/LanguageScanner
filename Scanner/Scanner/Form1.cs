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
            }
        }

        private void readText(string filePath)
        {
            try
            {
                text = "";
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    text += line;
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("An error has occured \nError: " + e.Message);
            }
        }
    }
}