using Gestion_de_proyectos.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos
{
      public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = ConexionDB.crearInstanciaDB().CrearConexionDB();

           

            try
            {
                sqlCon.Open();
                Console.WriteLine("Conexión exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conexión fallida");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
