using Gestion_de_proyectos.Models;
using System;
using System.Collections;
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
        string respuesta = "";
        SqlConnection Sqlcon = new SqlConnection();
        public ProyectoRepository() { }
        public string Agregar_Proyecto(Proyecto _proyecto)
        {


           
           

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

        public List<Proyecto> MostrarProyectosYTareas()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();

            try
            {
                Sqlcon = ConexionDB.crearInstanciaDB().CrearConexionDB();
                SqlCommand comando = new SqlCommand("SP_OBTENER_PROYECTOS_CON_TAREAS", Sqlcon);
                Sqlcon.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                Proyecto proyectoActual = null;
                int proyectoIdAnterior = -1; // Para rastrear el proyecto actual

                while (sqlDataReader.Read())
                {
                    int proyectoId = sqlDataReader.GetInt32(0);

                    // Si hemos encontrado un nuevo proyecto
                    if (proyectoId != proyectoIdAnterior)
                    {
                        // Añadimos el proyecto anterior a la lista
                        if (proyectoActual != null)
                        {
                            listaProyectos.Add(proyectoActual);
                        }

                        // Creamos un nuevo proyecto
                        proyectoActual = new Proyecto
                        {
                            Id = proyectoId,
                            Nombre = sqlDataReader.GetString(1),
                            FechaInicio = sqlDataReader.GetDateTime(2),
                            FechaFin = sqlDataReader.GetDateTime(3),
                            Estado = sqlDataReader.GetString(4),
                            tareas = new List<Tarea>()
                        };

                        proyectoIdAnterior = proyectoId; // Actualizamos el ID del proyecto anterior
                    }

                    // Verificamos si hay una tarea asociada (si no hay valores nulos en las columnas de tarea)
                    if (!sqlDataReader.IsDBNull(5)) // Si la columna de tarea no es nula
                    {
                        Tarea tarea = new Tarea
                        {
                            ProyectoID = sqlDataReader.GetInt32(0),
                            descripcion = sqlDataReader.GetString(6),
                            FechaCreacion = sqlDataReader.GetDateTime(7),
                            FechaEntrega = sqlDataReader.GetDateTime(8),
                            Estado = sqlDataReader.GetString(9)
                        };

                        proyectoActual.tareas.Add(tarea); // Añadimos la tarea al proyecto actual
                    }
                }

                // Añadimos el último proyecto a la lista si existe
                if (proyectoActual != null)
                {
                    listaProyectos.Add(proyectoActual);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Error al obtener los proyectos y las tareas");
                throw;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();
            }

            return listaProyectos;
        }
    }
}
