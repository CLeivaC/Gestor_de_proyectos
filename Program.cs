using Gestion_de_proyectos.Data;
using Gestion_de_proyectos.Data.Repositories;
using Gestion_de_proyectos.Models;
using Gestion_de_proyectos.Services;
using Gestion_de_proyectos.Views;
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

            menuPrincipal();
           




        }

        private static void menuPrincipal() 
        {
            ProyectoRepository Prepository = new ProyectoRepository();
            ProyectoService proyectoService = new ProyectoService(Prepository);
            ProyectoView proyectoView = new ProyectoView(proyectoService);

            TareaRepository Trepository = new TareaRepository();
            TareaService tareaService = new TareaService(Trepository);
            TareaView tareaView = new TareaView(tareaService);

           

            Console.WriteLine("1. Agregar proyecto nuevo");
            Console.WriteLine("2. Agregar tarea nueva");
            Console.WriteLine("3. Ver todos los proyectos y tareas asociadas");
            Console.WriteLine("4. Actualizar estado de tarea");
            Console.WriteLine("5. Eliminar una tarea");
            String opcionS = Console.ReadLine();
            int opcion;

            int.TryParse(opcionS, out opcion);

            switch (opcion)
            {
                case 1:
                    proyectoView.Agregar_Proyectos();
                    break;
                case 2:
                    tareaView.Agregar_Tareas();
                    break;
                case 3:
                    proyectoView.MostrarProyectosConTareas();
                    break;
                case 4:
                    tareaView.ActualizarEstadoTarea();
                    break;
                default:
                    break;
            }
        }
    }
}
