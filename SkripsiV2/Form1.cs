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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid(12, 12);
            WordsDic dic = new WordsDic();

            List<string> words = new List<string>(dic.Dictionary.Keys);

            Generator gen = new Generator(grid, words);

            int usedCount = gen.generate();
            grid.show();

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

            for (int k = 0; k < grid.MaxRows; k++)
            {
                dataGridView1.Rows.Add();
                //datagridview1.rows[i].height = 505 / tts_board.getlength(0);
            }
            Console.Write("Rows :  {0} \t Coloumns : {1}", grid.MaxRows, grid.MaxColumns);
            for (int p = 0; p < grid.MaxRows; p++)
            {
                for (int a = 0; a < grid.MaxColumns; a++)
                {
                    if (grid.getValue(p, a) == ' ')
                    {
                        dataGridView1.Rows[p].Cells[a].ReadOnly = true;
                        dataGridView1.Rows[p].Cells[a].Style.BackColor = Color.Black;
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
            dataGridView1.ColumnCount = 10;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 20);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[0].Name = "Product ID";
            //dataGridView1.Columns[1].Name = "Product Name";
            //dataGridView1.Columns[2].Name = "Product Price";

            for (int k = 0; k < 10; k++)
            {
                dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Height = 505 / tts_board.GetLength(0);
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j % 2 == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Black;
                    }
                    else
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;

                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
        }
    }
}
