using NaturVida.Data;
using NaturVida.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NaturVida
{
    public partial class GestionProdc : Form
    {
        public GestionProdc()
        {
            InitializeComponent();
            llenarGrid();
            actulizarCombos();
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
        //Btn guardar producto
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar un codigo valido");
            }
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar un producto valido");
            }
            else if (txtValor.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe de ingresar un valor  valido");
            }
            else if (txtCantidad.Text.Trim().Length < 1)
            {
                MessageBox.Show("Debe de ingresar una cantidad  valido");
            }
            else {

                try
                {
                    Models.Producto p = new Models.Producto();
                    p.ProCodigo = Convert.ToInt32(txtCodigo.Text.Trim());
                    p.ProDescripcion = txtDescripcion.Text.Trim();
                    p.ProValor = Convert.ToInt32(txtValor.Text.Trim());
                    p.ProCantidad = Convert.ToInt32(txtCantidad.Text.Trim());

                    if (ProductoCAD.guardar(p))
                    {
                        MessageBox.Show("El producto se guardo exitosamente");
                        limpiarCampos();
                        actulizarCombos();
                        llenarGrid();


                    }
                    else { MessageBox.Show("El producto no se pudo guardar"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Btn limpiar producto
        private void button2_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
        //funcion para limpiar campos
        private void limpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtValor.Clear();
            txtCantidad.Clear();
        }
        //funcion para actualizar los  combo box
        private void actulizarCombos()
        {
            llenarComboBox(cbProducto);
            llenarComboBox(cbModificar);
            llenarComboBox(cbEliminar);
        }
        //funcion para llenar tabla productos
        private void llenarGrid()
        {
            DataTable datos = ProductoCAD.listar();
            dgLista.DataSource = datos;
            dgLista.Columns[0].Width = 100;
            dgLista.Columns[1].Width = 170;
            dgLista.Columns[2].Width = 130;
        }
        //funcion para llenar combo box
        private void llenarComboBox(ComboBox comboBox)
        {   
            DataTable datos = ProductoCAD.listarPorDescripcion();
            comboBox.DataSource = datos;
            comboBox.DisplayMember = "proDescripcion";
            comboBox.ValueMember = "proCodigo";
        }
        //funcion para buscar producto
        private void buscarProducto()
        {
            Producto p = new Models.Producto();
            p.ProDescripcion = cbProducto.Text.Trim();
            DataTable datos = ProductoCAD.buscarProducto(p);
           
            if (cbProducto.Text.Trim().Equals("TODOS"))
            {
                if (cbProducto.Items.Count == 1)
                {
                    MessageBox.Show("No hay información ");
                }
                else
                {
                    llenarGrid();
                }
            }
            else
            {
                if (datos.Rows.Count.Equals(0))
                {
                    MessageBox.Show("No exite producto " + cbProducto.Text.Trim());
                }
                else
                {
                    
                    dgLista.DataSource = datos;

                }
            }
        }
        //funcion para eliminar producto
        private void eliminarProducto()
        {
            Models.Producto p = new Models.Producto();
            p.ProCodigo = Convert.ToInt32(cbEliminar.SelectedValue);
            ProductoCAD.eliminarProducto(p);
            if (cbEliminar.SelectedValue.Equals(-1))
            {
                MessageBox.Show("No es posible borrar todos los productos");
            }
            else
            {
                llenarGrid();
                MessageBox.Show("Se elimino " + cbEliminar.Text.Trim() + " exitosamente");
            }
        }

        private void button3_Click (object sender, EventArgs e) 
        {
            buscarProducto();
        }

        private void GestionProdc_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            eliminarProducto();
            actulizarCombos();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FrProductoM formEditar = new FrProductoM();

            Producto p = new Producto();
            p.ProCodigo = Convert.ToInt32(cbModificar.SelectedValue);
            DataTable datos = ProductoCAD.buscarProductoActualizar(p);
           
            if (cbModificar.SelectedValue.Equals(-1))
            {
                MessageBox.Show("No es posible llenar todos los productos");
            }
            else
            {
                DataRow row = datos.Rows[cbModificar.SelectedIndex - 1];
                formEditar.txtCodigoM.Text = Convert.ToString(p.ProCodigo);
                formEditar.txtDescripcionM.Text = row["Descripcion"].ToString();
                formEditar.txtValorM.Text = row["Valor"].ToString();
                formEditar.txtCantidadM.Text = row["Cantidad"].ToString(); ;
                formEditar.Show();
            }
                
            
        }

        private void cbModificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cbEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
