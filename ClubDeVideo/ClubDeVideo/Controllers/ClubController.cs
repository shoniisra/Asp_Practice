using ClubDeVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubDeVideo.Controllers
{
    public class ClubController : Controller
    {
       
        public List<Pelicula> listapelis = new List<Pelicula>
                    {
                       new Pelicula{ id=1,Nombre="tres metros sobre el cielo",Genero="romance",Precio=20 },
                       new Pelicula{ id=2,Nombre="iron man",Genero="ficcion",Precio=15 },
                       new Pelicula{ id=3,Nombre="piratas del caribe",Genero="ficcion",Precio=25 },
                       new Pelicula{ id=4,Nombre="los simpson",Genero="infantil",Precio=10 },
                       new Pelicula{ id=5,Nombre="mi pequeño angelito",Genero="familiar",Precio=35 }
                    };
        
        // GET: Club
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mostrar()
        {
            Pelicula peli1 = new Pelicula();
            peli1.LlenarPelicula(1, "titanic","romance", 20);
            return View(peli1);
        }
        public ActionResult Leer()
        {
            Pelicula NewPeli = new Pelicula();
            return View(NewPeli);
        }
        [HttpPost]
        public ActionResult Leer(Pelicula MiPeli)
        {
            return View("Mostrar", MiPeli);
        }


        public ActionResult ResultLista()
        {
            return View(this.listapelis);
        }
        [HttpPost]
        public ActionResult ResultLista(Pelicula MiPeli)
        {
            listapelis.Add(MiPeli);
            return View("ResultLista", listapelis);
        }
    }
}