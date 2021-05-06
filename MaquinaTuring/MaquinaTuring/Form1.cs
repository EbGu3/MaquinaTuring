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
            if (Data.Instance.Path != null)
            {
                OperationText operation = new OperationText();
                operation.MovingTransition(txtIdE.Text);

                dataGridView1.Rows[0].Cells[0].Value = "Cadena";
                dataGridView1.Rows[1].Cells[0].Value = "Cabezal";

                //Llenar el grid con estado inicial de la maquina
                for (int i = 0; i < Data.Instance.ListOfString.Count(); i++)
                {
                    dataGridView1.Rows[0].Cells[i + 1].Value = Data.Instance.ListOfString[i];
                    dataGridView1.Columns.Add("", "");
                }
                dataGridView1.Rows[1].Cells[1].Value = "";
                dataGridView1.Rows[1].Cells[Data.Instance.HeadLocation].Value = "^";
                PaintMoving(Data.Instance.HeadLocation);
                //Asignar los valores a los txt
                txtIdE.Text = Data.Instance.ListOfStates.Find(x => x.IdState == Data.Instance.FirstState).IdState;
                txtInitialE.Text = Data.Instance.ActualState.ActualTransition.InitialState;
                txtReadC.Text = Data.Instance.ActualState.ActualTransition.CharacterRead;
                txtFinalE.Text = Data.Instance.ActualState.ActualTransition.FinalState;
                txtWriteC.Text = Data.Instance.ActualState.ActualTransition.CharacterWrite;
                txtMoveC.Text = Data.Instance.ActualState.ActualTransition.HeadMovement.ToString();

            }
            else
            {
                MessageBox.Show("No se a ingresado ningun archivo");
            }
        }

        public void PaintMoving(int cell)
        {
            dataGridView1.Rows[1].Cells[cell].Style.BackColor = Color.Blue;
            dataGridView1.Rows[1].Cells[cell].Style.ForeColor = Color.White;
        }


        public void PaintInitialMoving(int cell)
        {
            dataGridView1.Rows[1].Cells[cell].Style.BackColor = Color.Black;
            dataGridView1.Rows[1].Cells[cell].Style.ForeColor = Color.White;
        }

        /// <summary>
        /// Método que inicializa el valor de listOfStrings del singleton a través 
        /// del textBox txtCadena. 
        /// </summary>
        private void CargarCadena()
        {
            Data.Instance.ListOfString.Add("_");

            foreach (var character in txtCadena.Text)
                Data.Instance.ListOfString.Add(character.ToString());

            Data.Instance.ListOfString.Add("_");
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            if (txtCadena.Text != "")
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    Data.ResetData();
                    CargarCadena();

                    //Codigo de manejo del archivo
                    Data.Instance.Path = openFileDialog1.FileName;
                    dataGridView1.Rows.Add();
                    FileManagement file = new FileManagement();
                    file.LecturaArchivo(Data.Instance.Path);

                    dataGridView1.Rows[0].Cells[0].Value = "Cadena";
                    dataGridView1.Rows[1].Cells[0].Value = "Cabezal";

                    //Llenar el grid con estado inicial de la maquina
                    for (int i = 0; i < Data.Instance.ListOfString.Count(); i++)
                    {
                        dataGridView1.Rows[0].Cells[i + 1].Value = Data.Instance.ListOfString[i];
                        dataGridView1.Columns.Add("", "");
                    }
                    dataGridView1.Rows[1].Cells[Data.Instance.HeadLocation].Value = "^";
                    PaintInitialMoving(Data.Instance.HeadLocation);

                    //Asignar los valores a los txt
                    txtIdE.Text = Data.Instance.ListOfStates.Find(x => x.IdState == Data.Instance.FirstState).IdState;
                    txtInitialE.Text = Data.Instance.ActualState.ActualTransition.InitialState;
                    txtReadC.Text = Data.Instance.ActualState.ActualTransition.CharacterRead;
                    txtFinalE.Text = Data.Instance.ActualState.ActualTransition.FinalState;
                    txtWriteC.Text = Data.Instance.ActualState.ActualTransition.CharacterWrite;
                    txtMoveC.Text = Data.Instance.ActualState.ActualTransition.HeadMovement.ToString();
                }
            }
            else MessageBox.Show("Ingrese una cadena a evaluar para cargar un archivo");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
