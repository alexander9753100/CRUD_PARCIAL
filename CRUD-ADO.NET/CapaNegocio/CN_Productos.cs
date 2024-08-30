using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        // Instancia de la capa de datos
        private CD_Productos objetoCD = new CD_Productos();

        // Método para mostrar los productos
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        // Método para insertar un producto
        public void InsertarProd(string nombre, string desc, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        // Método para editar un producto
        public void EditarProd(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        // Método para eliminar un producto
        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

        // Método para buscar un producto por nombre
        public DataTable BuscarProducto(string nombre)
        {
            return objetoCD.Buscar(nombre);
        }
    }
}
