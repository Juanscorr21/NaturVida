using NaturVida.Data;
using NaturVida.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturVida
{
    public partial class FrProductoM : Form
    {
        public FrProductoM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MoficarProductoForm_Load(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtCodigoM.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar un codigo valido");
            }
            if (txtDescripcionM.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar un producto valido");
            }
            else if (txtValorM.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe de ingresar un valor  valido");
            }
            else if (txtCantidadM.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe de ingresar una cantidad  valido");
            }
            else
            {

                try
                {
                    Producto p = new Producto();
                    p.ProCodigo = Convert.ToInt32(txtCodigoM.Text.Trim());
                    p.ProDescripcion = txtDescripcionM.Text.Trim();
                    p.ProValor = Convert.ToInt32(txtValorM.Text.Trim());
                    p.ProCantidad = Convert.ToInt32(txtCantidadM.Text.Trim());

                    if (ProductoCAD.actualizar(p))
                    {
                        MessageBox.Show("El producto se guardo exitosamente");
                        
                    }
                    else { MessageBox.Show("El producto no se pudo guardar"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
