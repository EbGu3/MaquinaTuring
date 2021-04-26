using MaquinaTuring.Models;
using MaquinaTuring.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaTuring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(Data.Instance.Path != null)
            {
                

            }
            else
            {
                MessageBox.Show("No se a ingresado ningun archivo");
            }
        }


        public void PaintNewMoving(int cell)
        {
            dataGridView1.Rows[1].Cells[cell].Style.BackColor = Color.Black;
            dataGridView1.Rows[1].Cells[cell].Style.ForeColor = Color.White;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Codigo de manejo del archivo
                Data.Instance.Path = openFileDialog1.FileName;
                dataGridView1.Rows.Add();
                FileManagement file = new FileManagement();
                file.LecturaArchivo(Data.Instance.Path);


                //Llenar el grid con estado inicial de la maquina
                for (int i = 0; i < Data.Instance.ListOfString.Count(); i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = Data.Instance.ListOfString[i];
                    dataGridView1.Columns.Add("", "");
                }
                dataGridView1.Rows[1].Cells[0].Value = "^";
                txtIdE.Text = Data.Instance.ListOfStates.Find(x => x.IdState == Data.Instance.FirstState).IdState;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
