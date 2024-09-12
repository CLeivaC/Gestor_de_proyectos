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
            ProyectoRepository repository = new ProyectoRepository();
            ProyectoService proyectoService = new ProyectoService(repository);
            ProyectoView proyectoView = new ProyectoView(proyectoService);

            proyectoView.Agregar_Proyectos();




        }
    }
}
