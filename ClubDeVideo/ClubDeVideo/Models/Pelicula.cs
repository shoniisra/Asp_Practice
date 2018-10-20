using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubDeVideo.Models
{
    public class Pelicula
    {
        public int id { get; set; }
        public String Nombre { get; set; }
        public String Genero { get; set; }
        public float Precio { get; set; }

        public void LlenarPelicula(int id, String nomb, String genero, float cost)
            {
                this.id = id;
                this.Nombre = nomb;
                this.Genero = genero;
                this.Precio = cost;
            }
       
    }
}