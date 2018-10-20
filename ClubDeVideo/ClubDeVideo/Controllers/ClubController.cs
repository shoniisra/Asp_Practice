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
    }
}