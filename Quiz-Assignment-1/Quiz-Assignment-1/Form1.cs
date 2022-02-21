using System.Text;

namespace Quiz_Assignment_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);
                this.dataGridView1.Text = readAllLine[0];
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;

                for(int i = 0; i < readAllText.Length; i++)
                {
                    string listRAW = readAllLine[i];
                    string[] listSplited = listRAW.Split(',');
                    IncomeAndExpenses list = new IncomeAndExpenses(listSplited[0]);
                    _ = new IncomeAndExpenses(listSplited[1]);
                    _ = new IncomeAndExpenses(listSplited[2]);
                }
            }
        }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != String.Empty)
                {
                    filepath = saveFileDialog.FileName;

                //save file
                File.WriteAllText(filepath, this.textBox1.Text, Encoding.UTF8);
                }
            }
        }

        int sumin = 0, sumex = 0, inIn = 0, inEx = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;

            inIn = Convert.ToInt32((textBox2.Text).ToString());
            inEx = Convert.ToInt32((textBox3.Text).ToString());

            sumin = inIn + sumin;
            sumex = inIn + sumex;

            textBox2.Text = sumin.ToString();
            textBox3.Text = sumex.ToString();
        }
    }
}