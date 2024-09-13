using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Models
{
    public class Proyecto
    {
        public List<Tarea> tareas;

        public int Id { get; set; }
        public string Nombre { get; set; }  // Solo lectura desde fuera de la clase
        public DateTime FechaInicio { get; set; }  // Solo lectura
        public DateTime FechaFin { get; set; }  // Solo lectura
        public string Estado { get; set; }  // Solo lectura

        public Proyecto(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            this.Nombre = nombre;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Estado = estado;
        }

        public Proyecto(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado,List<Tarea> tareas)
        {
            this.Nombre = nombre;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Estado = estado;
            this.tareas = tareas;
        }

        public Proyecto() { }
    }
}
