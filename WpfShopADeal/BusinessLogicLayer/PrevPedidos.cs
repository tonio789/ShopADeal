using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShopADeal.BusinessLogicLayer
{
    public class PrevPedidos
    {
        public int idPedido { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public int calificacion { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string idArticuloPedido { get; set; }
    }
}
