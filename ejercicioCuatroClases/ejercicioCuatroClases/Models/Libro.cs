using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejercicioCuatroClases.Models
{
    public class Libro
    {
        public int Codigo { get; set;}
        public String Nombre { get; set; }
        public float Costo { get; set; }

        public void CargarLibro(int cod, String nomb,float cost) {
            this.Codigo = cod;
            this.Nombre = nomb;
            this.Costo = cost;
        }
    }
}