//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfShopADeal.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tienda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tienda()
        {
            this.administra = new HashSet<administra>();
            this.articulo = new HashSet<articulo>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal cedula { get; set; }
        public string direccion { get; set; }
        public decimal telefono { get; set; }
        public string correo { get; set; }
        public decimal usuario_cedula { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<administra> administra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulo> articulo { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
