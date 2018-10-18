using ejercicioCuatroClases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejercicioCuatroClases.Controllers
{
    public class BibliotecaController : Controller
    {
        // GET: Biblioteca
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mostrar()
        {
            Libro libro1 = new Libro();
            libro1.CargarLibro(1, "inteligencia artificial", 20);
            return View(libro1);
        }
        public ActionResult Lista()
        {
            List<Libro> ListaLibros = new List<Libro>
            {
               new Libro{ Codigo=1,Nombre="Fisica",Costo=20 },
               new Libro{Codigo=2,Nombre="Mate",Costo=30 },
               new Libro{Codigo=3,Nombre="Quimica",Costo=40 },
               new Libro{Codigo=4,Nombre="Anatomia",Costo=35 },
               new Libro{Codigo=5,Nombre="Embriologia",Costo=45 }
            };
            return View(ListaLibros);
        }
        public ActionResult Nuevo()
        {

            Libro NewLibro = new Libro();
            return View(NewLibro);
        }
        [HttpPost]
        public ActionResult Crear(Libro MiLibro)
        {
            return View("Mostrar",MiLibro);
        }
        [HttpPost]
        public ActionResult CrearLista(Libro MiLibro)
        {
            List<Libro> ListaLibros = new List<Libro>
            {
               new Libro{ Codigo=1,Nombre="Fisica",Costo=20 },
               new Libro{Codigo=2,Nombre="Mate",Costo=30 },
               new Libro{Codigo=3,Nombre="Quimica",Costo=40 },
               new Libro{Codigo=4,Nombre="Anatomia",Costo=35 },
               new Libro{Codigo=5,Nombre="Embriologia",Costo=45 }
            };
            ListaLibros.Add(MiLibro);

            return View("Lista", ListaLibros);
        }
    }
}