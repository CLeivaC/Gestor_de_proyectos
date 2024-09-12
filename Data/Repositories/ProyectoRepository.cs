using Gestion_de_proyectos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Data.Repositories
{
    public class ProyectoRepository
    {

        public ProyectoRepository() { }
        public string Agregar_Proyecto(Proyecto _proyecto)
        {


            string respuesta = "";
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon = ConexionDB.crearInstanciaDB().CrearConexionDB();
                SqlCommand comando = new SqlCommand("SP_CREAR_PROYECTO", Sqlcon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = _proyecto.Nombre;
                comando.Parameters.Add("@dFechaInicio", SqlDbType.DateTime).Value = _proyecto.FechaInicio;
                comando.Parameters.Add("@dFechaFin", SqlDbType.DateTime).Value = _proyecto.FechaFin;
                comando.Parameters.Add("@cEstado", SqlDbType.VarChar).Value = _proyecto.Estado;

                Sqlcon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Ha ocurrido un error al agregar un proyecto nuevo";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                throw;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();
            }
            return respuesta;
        }
    }
}
