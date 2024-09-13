using Gestion_de_proyectos.Data.Repositories;
using Gestion_de_proyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_proyectos.Services
{
   public class TareaService
    {
        private readonly TareaRepository _repository;
        public TareaService(TareaRepository tareaRepository) 
        { 
            this._repository = tareaRepository;
        }

        public void AgregarTarea(Tarea tarea)
        {
            string respuesta = _repository.AgregarTarea(tarea);
            if (respuesta == "Ok")
            {
                Console.WriteLine("Tarea agregada correctamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error");
            }
        }
    }
}
