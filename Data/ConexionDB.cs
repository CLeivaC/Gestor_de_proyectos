using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Data
{
    public class ConexionDB
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static ConexionDB Con = null;

        private ConexionDB() 
        {
            this.Servidor = "DESKTOP-NRFRB6B\\SQLEXPRESS";
            this.Base = "GestionProyectos";
            this.Usuario = "leiva";
            this.Clave = "1234";
        }

        public SqlConnection CrearConexionDB() 
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                          "; Database= " + this.Base +
                                          "; User id=" + this.Usuario +
                                          "; Password =" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static ConexionDB crearInstanciaDB()
        {
            if (Con == null)
            {
                  Con = new ConexionDB();
            }
            return Con;
        }


    }
}
