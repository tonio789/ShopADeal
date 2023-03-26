using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShopADeal.BusinessLogicLayer
{
    public class Compra
    {
        public int idArticulo { get; set; }
        public int codTienda { get; set; }
        public string tienda { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nombreDescripcion { get; set; }
        public int cantidad { get; set; }
        public double calificacion { get; set; }
        public double precio { get; set; }
    }
}
