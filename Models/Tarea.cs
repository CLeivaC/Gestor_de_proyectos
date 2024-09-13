using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Models
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public int ProyectoID { get; set; }
        public string descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; }

        public Tarea(int proyectoID, string descripcion, DateTime fechaCreacion, DateTime fechaEntrega, string estado)
        {
            this.ProyectoID = proyectoID;
            this.descripcion = descripcion;
            this.FechaCreacion = fechaCreacion;
            this.FechaEntrega = fechaEntrega;
            this.Estado = estado;
        }
    }
}
