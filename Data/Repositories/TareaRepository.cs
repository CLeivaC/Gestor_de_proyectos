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
    public class TareaRepository
    {
        public TareaRepository() { }

        public string AgregarTarea(Tarea tarea)
        {
            String respuesta = "";
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon = ConexionDB.crearInstanciaDB().CrearConexionDB();
                SqlCommand comando = new SqlCommand("SP_CREAR_TAREA", Sqlcon);

                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("@nProyectoID", SqlDbType.Int).Value = tarea.ProyectoID;
                comando.Parameters.Add("@cDescripcion",SqlDbType.VarChar).Value = tarea.descripcion;
                comando.Parameters.Add("@dFechaCreacion", SqlDbType.VarChar).Value = tarea.FechaCreacion;
                comando.Parameters.Add("@dFechaEntrega", SqlDbType.DateTime).Value = tarea.FechaEntrega;
                comando.Parameters.Add("@cEstado", SqlDbType.VarChar).Value = tarea.Estado;

                Sqlcon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Ha ocurrido un error al agregar una tarea nueva";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                throw;
            }
            finally 
            {
                if(Sqlcon.State == ConnectionState.Open) Sqlcon.Close();
            }
            return respuesta;
        }
    }
}
