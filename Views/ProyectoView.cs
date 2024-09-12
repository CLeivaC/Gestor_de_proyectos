using Gestion_de_proyectos.Data.Repositories;
using Gestion_de_proyectos.Models;
using Gestion_de_proyectos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Views
{
    public class ProyectoView
    {
        private readonly ProyectoService _proyectoService;

        public ProyectoView(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }

        public void Agregar_Proyectos()
        {
            DateTime fechaInicioProyecto;
            DateTime fechaFinProyecto;

            Console.WriteLine("Dime el nombre del proyecto");
            string nombreProyecto = Console.ReadLine();

            Console.WriteLine("Dime la fecha de inicio del proyecto");
            string inputfechaInicioProyecto = Console.ReadLine();

            Console.WriteLine("Dime la fecha fin del proyecto");
            string inputfechaFinProyecto = Console.ReadLine();

            Console.WriteLine("Dime el estado del proyecto");
            string estadoProyecto = Console.ReadLine();

            DateTime.TryParse(inputfechaInicioProyecto, out fechaInicioProyecto);
            DateTime.TryParse(inputfechaFinProyecto, out fechaFinProyecto);

            Proyecto proyecto = new Proyecto(nombreProyecto, fechaInicioProyecto, fechaFinProyecto, estadoProyecto);

            _proyectoService.AgregarProyecto(proyecto);
        }
    }
}
