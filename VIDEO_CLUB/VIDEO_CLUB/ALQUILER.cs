//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VIDEO_CLUB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALQUILER
    {
        public int ALQ_ID { get; set; }
        public Nullable<int> SOC_ID { get; set; }
        public Nullable<int> PEL_ID { get; set; }
        public System.DateTime ALQ_FECHA_DESDE { get; set; }
        public System.DateTime ALQ_FECHA_HASTA { get; set; }
        public decimal ALQ_VALOR { get; set; }
        public Nullable<System.DateTime> ALQ_FECHA_ENTREGA { get; set; }
    
        public virtual PELICULA PELICULA { get; set; }
        public virtual SOCIO SOCIO { get; set; }
    }
}
