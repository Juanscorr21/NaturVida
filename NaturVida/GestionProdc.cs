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
    public partial class GestionProdc : Form
    {
        public GestionProdc()
        {
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar un producto valido");
            }
            else if (txtValor.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe de ingresar un valor  valido");
            }
            else {

                try
                {
                    ProductoM p = new ProductoM();
                    p.ProCodigo = Convert.ToInt32(txtCodigo.Text.Trim());
                    p.ProDescripcion = txtDescripcion.Text.Trim().ToUpper();
                    p.ProValor = Convert.ToInt32(txtValor.Text.Trim());
                    p.ProCantidad = Convert.ToInt32(txtCantidad.Text.Trim());

                    if (ProductoCAD.guardar(p))
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
    }
}
