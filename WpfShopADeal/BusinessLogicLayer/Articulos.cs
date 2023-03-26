using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShopADeal.BusinessLogicLayer
{
    public class Articulos
    {
        public int id { get; set; }
        public int codTienda { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public string codigoBarras { get; set; }
    }
}
