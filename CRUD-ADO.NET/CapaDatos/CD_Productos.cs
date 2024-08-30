using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        // Instancia de la clase CD_Conexion para gestionar la conexión a la base de datos
        private CD_Conexion conexion = new CD_Conexion();

        // Variables para manejar la lectura de datos y comandos SQL
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        // Método para mostrar los productos
        public DataTable Mostrar()
        {
            // Configuración de la conexión y comando para ejecutar el procedimiento almacenado 'MostrarProductos'
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            // Ejecución del comando y carga de los datos en la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cierre de la conexión a la base de datos
            conexion.CerrarConexion();

            return tabla;
        }



        // Método para insertar un nuevo producto en la base de datos
        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            // Configuración del comando para ejecutar el procedimiento almacenado 'InsertarProductos'
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al comando con los valores correspondientes
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            // Ejecución del comando
            comando.ExecuteNonQuery();

            // Limpieza de los parámetros después de la ejecución
            comando.Parameters.Clear();
        }



        // Método para editar un producto existente en la base de datos
        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            // Configuración del comando para ejecutar el procedimiento almacenado 'EditarProductos'
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al comando con los valores correspondientes
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            // Ejecución del comando
            comando.ExecuteNonQuery();

            // Limpieza de los parámetros después de la ejecución
            comando.Parameters.Clear();
        }



        // Método para eliminar un producto de la base de datos
        public void Eliminar(int id)
        {
            // Configuración del comando para ejecutar el procedimiento almacenado 'EliminarProducto'
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar el parámetro 'idpro' al comando
            comando.Parameters.AddWithValue("@idpro", id);

            // Ejecución del comando
            comando.ExecuteNonQuery();

            // Limpieza de los parámetros después de la ejecución
            comando.Parameters.Clear();
        }



        // Método para buscar un producto por nombre
        public DataTable Buscar(string nombre)
        {
            // Configuración del comando para ejecutar el procedimiento almacenado 'BuscarProducto'
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            // Agregar el parámetro 'nombre' al comando
            comando.Parameters.AddWithValue("@nombre", nombre);

            // Ejecución del comando y carga de los datos en la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cierre de la conexión a la base de datos
            conexion.CerrarConexion();

            // Limpieza de los parámetros después de la ejecución
            comando.Parameters.Clear();

            return tabla;
        }
    }
}
