//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutosDataAnnotation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.compra = new HashSet<compra>();
        }
        [DisplayName("ID")]
        public int cli_id { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("NOMBRE")]
        public string cli_nombre { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2018",
        ErrorMessage = "fechas aceptadas para campo {0} entre {1} y {2}")]
        [DisplayName("FECHA DE NACIMIENTO")]
        public Nullable<System.DateTime> cli_fecha_nacimiento { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compra> compra { get; set; }
    }
}