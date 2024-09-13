using Gestion_de_proyectos.Models;
using Gestion_de_proyectos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Views
{
    public class TareaView
    {
        private readonly TareaService _tareaService;

        public TareaView(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        public void Agregar_Tareas()
        {
            DateTime fechaCreacionTarea;
            DateTime fechaEntregaTarea;
            int idTarea;
            Console.WriteLine("Dime id del proyecto");
            string idTareaS = Console.ReadLine();

            int.TryParse(idTareaS, out idTarea);

            Console.WriteLine("Dimela Descripción de la tarea");
            string descripcionTarea = Console.ReadLine();
           

            Console.WriteLine("Dime la fecha de creación de la tarea");
            string inputfechaCreacionTarea = Console.ReadLine();

            Console.WriteLine("Dime la fecha de creación de la tarea");
            string inputfechaEntregaTarea = Console.ReadLine();

            Console.WriteLine("Dime el estado del proyecto");
            string estadoTarea = Console.ReadLine();

            DateTime.TryParse(inputfechaEntregaTarea, out fechaCreacionTarea);
            DateTime.TryParse(inputfechaCreacionTarea, out fechaEntregaTarea);

            Tarea tarea = new Tarea(idTarea, descripcionTarea, fechaCreacionTarea, fechaEntregaTarea, estadoTarea);

            _tareaService.AgregarTarea(tarea);
        }
    }
}
