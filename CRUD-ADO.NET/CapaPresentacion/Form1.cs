using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Instancia de la capa de negocio para gestionar los productos.
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;  // Almacena el ID del producto seleccionado para editar o eliminar.
        private bool Editar = false;  // Indica si estamos en modo de edición o inserción.

        public Form1()
        {
            InitializeComponent();
        }

        // Método que se ejecuta cuando se carga el formulario.
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProdctos();  // Muestra todos los productos al cargar el formulario.
        }

        // Método para mostrar los productos en el DataGridView.
        private void MostrarProdctos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();  // Asigna los productos al DataGridView.
        }

        // Evento para el botón Guardar (inserta o edita un producto).
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Inserción de un nuevo producto.
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Producto insertado correctamente.");
                    MostrarProdctos();  // Actualiza la lista de productos.
                    limpiarForm();  // Limpia los campos del formulario.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar el producto debido a: " + ex.Message);
                }
            }
            // Edición de un producto existente.
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Producto editado correctamente.");
                    MostrarProdctos();  // Actualiza la lista de productos.
                    limpiarForm();  // Limpia los campos del formulario.
                    Editar = false;  // Resetea el estado de edición.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el producto debido a: " + ex.Message);
                }
            }
        }

        // Evento para el botón Editar (prepara la edición de un producto).
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;  // Cambia el estado a edición.
                // Rellena los campos del formulario con los valores del producto seleccionado.
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();  // Almacena el ID del producto.
            }
            else
            {
                MessageBox.Show("Seleccione una fila, por favor.");
            }
        }

        // Método para limpiar los campos del formulario.
        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        // Evento para el botón Eliminar (elimina un producto).
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();  // Obtiene el ID del producto.
                objetoCN.EliminarProd(idProducto);  // Llama al método para eliminar el producto.
                MessageBox.Show("Producto eliminado correctamente.");
                MostrarProdctos();  // Actualiza la lista de productos.
            }
            else
            {
                MessageBox.Show("Seleccione una fila, por favor.");
            }
        }

        // Evento para filtrar productos a medida que se escribe en el TextBox de búsqueda.
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        // Método para filtrar y buscar productos por nombre.
        private void filtro()
        {
            objetoCN = new CN_Productos();
            string nombreProducto = txtBuscar.Text;  // Obtiene el texto de búsqueda.
            dataGridView1.DataSource = objetoCN.BuscarProducto(nombreProducto);  // Filtra y actualiza el DataGridView.
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

