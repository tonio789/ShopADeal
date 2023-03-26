using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfShopADeal.BusinessLogicLayer;

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        public DAL.usuario usuario;
        public int pedido;
        public ShoppingCart(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            pedido = nPedido();
            Refresh();
        }

        private void Refresh()
        {
            List<Compra> lstCest = lstCesta();
            DG.ItemsSource = lstCest;
            double total = 0;

            foreach(Compra comp in lstCest)
            {
                double precio = comp.precio;
                int cantidad = comp.cantidad;
                total += precio * cantidad;
            }

            lb_total.Content = total.ToString();


        }

        private List<Pedidos> Pedidos()
        {
            List<Pedidos> lst = new List<Pedidos>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.pedido select new Pedidos { id = (int)d.numpedido, tipo = d.tipodoc, idUsuario = (int)d.usuario_cedula }).ToList();
            }

            return lst;
        }

        private int nPedido()
        {
            int pedido = 0;
            bool tienePedidoAbierto = false;
            foreach (Pedidos p in Pedidos())
            {
                //"A" significa abierto
                if (p.idUsuario == this.usuario.cedula && p.tipo == "A")
                {
                    pedido = p.id;
                    tienePedidoAbierto = true;
                }
            }
            if (!tienePedidoAbierto)
            {
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    DAL.pedido ped = new DAL.pedido();
                    ped.tipodoc = "A";
                    ped.usuario_cedula = this.usuario.cedula;
                    db.pedido.Add(ped);
                    db.SaveChanges();
                }

                foreach (Pedidos p in Pedidos())
                {
                    //"A" significa abierto
                    if (p.idUsuario == this.usuario.cedula && p.tipo == "A")
                    {
                        pedido = p.id;
                    }
                }
            }
            return pedido;
        }

        private List<Compra> lstCesta()
        {

            List<Cesta> lst = new List<Cesta>();
            
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst=(from d in db.cesta select new Cesta {idArticulo = (int)d.articulo_id, idPedido = (int)d.pedido_numpedido, cantidad = (int)d.cantidad }).ToList();
            }


            List<Compra> lstFiltered = new List<Compra>();

            foreach (Cesta c in lst)
            {
                Compra compra = new Compra();

                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    compra.nombre = db.articulo.Find(c.idArticulo).nombre;
                    compra.precio = (double)db.articulo.Find(c.idArticulo).precio;
                    compra.cantidad = c.cantidad;
                    compra.idArticulo = c.idArticulo;
                }

                if (c.idPedido == this.pedido)
                {
                    lstFiltered.Add(compra);
                }
            }

            return lstFiltered;
        }
        
        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }

        private void btn_tiendas_Click(object sender, RoutedEventArgs e)
        {
            new EditStores(this.usuario).Show();
            this.Close();
        }

        private void btn_compras_Click(object sender, RoutedEventArgs e)
        {
            new PreviousOrders(this.usuario).Show();
            this.Close();
        }

        private void btn_categorias_Click(object sender, RoutedEventArgs e)
        {
            new Categories(this.usuario).Show();
            this.Close();
        }

        private void btn_seguirComprando_Click(object sender, RoutedEventArgs e)
        {
            new Shop(this.usuario).Show();
            this.Close();
        }

        private void btn_aumentar_Click(object sender, RoutedEventArgs e)
        {
            int idArticulo = (int)((Button)sender).CommandParameter;

            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                DAL.cesta articuloEnCesta = db.cesta.Find(idArticulo, this.pedido);
                articuloEnCesta.cantidad++;
                db.Entry(articuloEnCesta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            int idArticulo = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                DAL.cesta c = db.cesta.Find(idArticulo, this.pedido);
                db.cesta.Remove(c);
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn_disminuir_Click(object sender, RoutedEventArgs e)
        {
            int idArticulo = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {

                if (db.cesta.Find(idArticulo,this.pedido).cantidad == 1)
                {
                    DAL.cesta cestaArticulo = db.cesta.Find(idArticulo, this.pedido);
                    db.cesta.Remove(cestaArticulo);
                    db.SaveChanges();
                }
                else
                {
                    DAL.cesta cestaArticulo = db.cesta.Find(idArticulo, this.pedido);
                    cestaArticulo.cantidad--;
                    db.Entry(cestaArticulo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            Refresh();
        }


        private void btn_pagar_Click(object sender, RoutedEventArgs e)
        {
            using(DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                DAL.pedido p = db.pedido.Find(this.pedido);
                //"L" significa Listo
                p.tipodoc = "L";
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Tu pedido fue recibido correctamente.");
            new Shop(this.usuario).Show();
            this.Close();
        }

        
    }
}
