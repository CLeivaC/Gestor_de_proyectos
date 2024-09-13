using Gestion_de_proyectos.Data.Repositories;
using Gestion_de_proyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Services
{
    public class ProyectoService
    {
        public ProyectoService() { }
        private readonly ProyectoRepository _proyectoRepository;

        public ProyectoService(ProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        public void AgregarProyecto(Proyecto proyecto)
        {
            string respuesta = _proyectoRepository.Agregar_Proyecto(proyecto);

            if (respuesta == "Ok")
            {
                Console.WriteLine("Proyecto agregado correctamente");

            }
            else
            {
                Console.WriteLine("Ha ocurrido un error");
            }
        }

        public List<Proyecto> ObtenerProyectosConTareas()
        {
            try
            {
                
                List<Proyecto> proyectosConTareas = _proyectoRepository.MostrarProyectosYTareas();

                return proyectosConTareas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ProyectoService: " + ex.Message);
                throw;
            }
        }
    }
}
