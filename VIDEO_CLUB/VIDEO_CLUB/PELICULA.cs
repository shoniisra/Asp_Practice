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
    
    public partial class PELICULA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PELICULA()
        {
            this.ACTOR_PELICULA = new HashSet<ACTOR_PELICULA>();
            this.ALQUILER = new HashSet<ALQUILER>();
        }
    
        public int PEL_ID { get; set; }
        public Nullable<int> GEN_ID { get; set; }
        public Nullable<int> DIR_ID { get; set; }
        public Nullable<int> FOR_ID { get; set; }
        public string PEL_NOMBRE { get; set; }
        public decimal PEL_COSTO { get; set; }
        public Nullable<System.DateTime> PEL_FECHA_ESTRENO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTOR_PELICULA> ACTOR_PELICULA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALQUILER> ALQUILER { get; set; }
        public virtual DIRECTOR DIRECTOR { get; set; }
        public virtual FORMATO FORMATO { get; set; }
        public virtual GENERO GENERO { get; set; }
    }
}
