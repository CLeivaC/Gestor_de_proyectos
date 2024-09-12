using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; private set; }  // Solo lectura desde fuera de la clase
        public DateTime FechaInicio { get; private set; }  // Solo lectura
        public DateTime FechaFin { get; private set; }  // Solo lectura
        public string Estado { get; private set; }  // Solo lectura

        public Proyecto(string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            this.Nombre = nombre;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Estado = estado;
        }
        public Proyecto() { }
    }
}
