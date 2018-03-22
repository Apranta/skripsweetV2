using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkripsiV2
{
    public partial class Form1 : Form
    {
        Grid grid;
        WordsDic dic = new WordsDic();
        List<string> words;
        Generator gen;
        int usedCount;
        char[][] data;
        int row, column;
        String jawabanboard;
        public Form1(int row , int column)
        {
            InitializeComponent();
            this.row = row;
            this.column = column;
            grid = new Grid(row, column);
            words = new List<string>(dic.Dictionary.Keys);
            gen = new Generator(grid, words);
            usedCount = gen.generate();
            grid.show();
            this.show();
            
        }


        private void show()
        {
            Dictionary<int, List<string>> horizontalAnnex = gen.HorizontalAnnex;
            Dictionary<int, List<string>> verticalAnnex = gen.VerticalAnnex;
            List<int> list = new List<int>(horizontalAnnex.Keys);
            list = list.OrderBy(r => r).ToList();
            mendatar.Items.Add("Koor \t Pertanyaan");
            foreach (int key in list)
            {
                foreach (string word in horizontalAnnex[key])
                {
                    mendatar.Items.Add(key + "\t" + dic.Dictionary[word]);
                }
            }

            List<int> list1 = new List<int>(verticalAnnex.Keys);
            list1 = list1.OrderBy(r => r).ToList();
            Menurun.Items.Add("Koor \t Pertanyaan");
            foreach (int key in list1)
            {
                foreach (string word in verticalAnnex[key])
                {
                    Menurun.Items.Add(key + "\t" + dic.Dictionary[word]);
                }
            }

            Console.WriteLine("Used : ( " + usedCount + " / " + words.Count + " )");
            wordCount.Text = "Used : ( " + usedCount + " / " + words.Count + " )";
            dataGridView1.ColumnCount = this.column;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            for (int k = 0; k < this.row; k++)
            {
                
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Height = 35;
                dataGridView1.Columns[k].Width = 35;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[k]).MaxInputLength = 1;
                dataGridView1.Columns[k].HeaderText = k.ToString();
                dataGridView1.Rows[k].HeaderCell.Value = k.ToString();
            }
            for (int p = 0; p < this.row; p++)
            {
                for (int a = 0; a < this.column; a++)
                {
                  
                    if (grid.getValue(p,a) == ' ')
                    {
                        dataGridView1.Rows[p].Cells[a].ReadOnly = true;
                        dataGridView1.Rows[p].Cells[a].Style.BackColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.ForeColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.SelectionBackColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.SelectionForeColor = Color.Black;
                        dataGridView1[a, p].Value = "0";
                    }
                    else
                        dataGridView1[a,p].Value = "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<string>> horizontalAnnex = gen.HorizontalAnnex;
            Dictionary<int, List<string>> verticalAnnex = gen.VerticalAnnex;

            Console.WriteLine("Used : ( " + usedCount + " / " + words.Count + " )");
            Console.WriteLine("Horizontal annex :");
            printAnnex(horizontalAnnex, dic);
            Console.WriteLine("Vertical annex :");
            printAnnex(verticalAnnex, dic);
            dataGridView1.ColumnCount = grid.MaxRows;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            for (int k = 0; k < grid.MaxRows; k++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Height = 25;
                dataGridView1.Columns[k].Width = 25;
            }
            Console.Write("Rows :  {0} \t Coloumns : {1}", grid.MaxRows, grid.MaxColumns);
            for (int p = 0; p < grid.MaxRows; p++)
            {
                for (int a = 0; a < grid.MaxColumns; a++)
                {
                    if (grid.getValue(p, a) == ' ')
                    {
                        dataGridView1.Rows[p].Cells[a].ReadOnly = true;
                        //dataGridView1.Rows[p].Cells[a].Style.BackColor = Color.Black;
                    }
                    else
                        dataGridView1.Rows[p].Cells[a].Style.BackColor = Color.White;

                    dataGridView1[p,a].Value = grid.getValue(p,a);

                    Console.Write(p + '\t' + a);
                    Console.WriteLine(grid.getValue(a, a));
                }
                Console.WriteLine();
            }
        }

        private static void printAnnex(Dictionary<int, List<string>> annex, WordsDic dic)
        {

            List<int> list = new List<int>(annex.Keys);
            list = list.OrderBy(r => r).ToList(); ;

            foreach (int key in list)
            {

                Console.Write(key + " : ");
                
                foreach (string word in annex[key])
                {
                    Console.Write(dic.Dictionary[word] + " | ");
                }

                Console.WriteLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool benar = false;
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    jawabanboard = dataGridView1[j,i].Value.ToString();
                    Console.WriteLine(jawabanboard);
                    if (jawabanboard == "0")
                    {
                        continue;
                    }
                    else if (jawabanboard != Convert.ToString(grid.getValue(i, j)))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        benar = false;
                    }
                    else
                    {
                        benar = true;
                    }

                }
            }

            if (benar)
            {
                MessageBox.Show("Anda Benar", "Selamat",
                   MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Masih Ada Yang salah", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void Mendatar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
