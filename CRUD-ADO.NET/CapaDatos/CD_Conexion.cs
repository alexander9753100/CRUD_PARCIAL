using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
        // Definición de la conexión a la base de datos con la cadena de conexión correspondiente.
        private SqlConnection Conexion = new SqlConnection("Data Source=(localdb)\\alex;Initial Catalog=Practica;Integrated Security=True;");

        // Método para abrir la conexión a la base de datos.
        public SqlConnection AbrirConexion()
        {
            // Verifica si la conexión está cerrada y la abre si es necesario.
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        // Método para cerrar la conexión a la base de datos.
        public SqlConnection CerrarConexion()
        {
            // Verifica si la conexión está abierta y la cierra si es necesario.
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}

