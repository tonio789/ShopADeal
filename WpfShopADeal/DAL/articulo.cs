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
    
    public partial class articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulo()
        {
            this.cesta = new HashSet<cesta>();
        }
    
        public int id { get; set; }
        public string codigobarras { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public int tienda_codigo { get; set; }
        public string categoria_categoria { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual tienda tienda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cesta> cesta { get; set; }
    }
}