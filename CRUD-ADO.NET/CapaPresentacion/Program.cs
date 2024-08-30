using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita el uso de estilos visuales modernos en la aplicación.
            Application.EnableVisualStyles();

            // Configura la aplicación para usar un motor de renderizado de texto compatible.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia y ejecuta la aplicación con el formulario principal (Form1).
            Application.Run(new Form1());
        }
    }
}

