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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using WpfShopADeal.BusinessLogicLayer;
using WpfShopADeal.DAL;

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para PreviousOrders.xaml
    /// </summary>
    public partial class PreviousOrders : Window
    {
        public DAL.usuario usuario;
        public PreviousOrders(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            Refresh();
        }

        private void Refresh()
        {
            DG.ItemsSource = lstPedidos();
        }

        private List<Pedidos> Pedidos()
        {
            List<Pedidos> lst = new List<Pedidos>();
            List<Pedidos> lstFiltered = new List<Pedidos>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.pedido select new Pedidos { id = (int)d.numpedido, tipo = d.tipodoc, idUsuario = (int)d.usuario_cedula }).ToList();
            }

            foreach(Pedidos pedido in lst)
            {
                if(pedido.idUsuario == this.usuario.cedula)
                {
                    lstFiltered.Add(pedido);
                }
            }
            return lstFiltered;
        }

        private List<PrevPedidos> lstPedidos()
        {

            List<Cesta> lst = new List<Cesta>();

            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.cesta select new Cesta { idArticulo = (int)d.articulo_id, idPedido = (int)d.pedido_numpedido, cantidad = (int)d.cantidad , calificacion = (int)d.calificacion}).ToList();
            }

            List<PrevPedidos> lstFiltered = new List<PrevPedidos>();

            foreach (Cesta c in lst)
            {
                PrevPedidos pedido = new PrevPedidos();

                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {

                    pedido.idArticulo = c.idArticulo;
                    pedido.idPedido = c.idPedido;
                    pedido.cantidad = c.cantidad;
                    pedido.calificacion = c.calificacion;
                    pedido.idArticulo = c.idArticulo;

                    pedido.nombre = db.articulo.Find(c.idArticulo).nombre;
                    pedido.precio = (double)db.articulo.Find(c.idArticulo).precio;
                   
                    pedido.idArticuloPedido = c.idArticulo + "," + c.idPedido;
                }

                foreach(Pedidos p in Pedidos())
                {
                    if (p.idUsuario == this.usuario.cedula && c.idPedido == p.id)
                    {
                        lstFiltered.Add(pedido);
                    }
                }                
            }

            return lstFiltered;
        }



        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }

        private void btn_comprar_Click(object sender, RoutedEventArgs e)
        {
            new Shop(this.usuario).Show();
            this.Close();
        }

        private void btn_tiendas_Click(object sender, RoutedEventArgs e)
        {
            new EditStores(this.usuario).Show();
            this.Close();
        }

        private void btn_categorias_Click(object sender, RoutedEventArgs e)
        {
            new Categories(this.usuario).Show();
            this.Close();
        }

        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            new Shop(this.usuario).Show();
            this.Close();
        }

        private void calificacion (string idArticuloPedido,int calificacion)
        {
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {

                int idArticulo = 0;
                int idPedido = 0 ;

                foreach (PrevPedidos pp in lstPedidos())
                {
                    if(pp.idArticuloPedido == idArticuloPedido)
                    {
                        idArticulo = pp.idArticulo;
                        idPedido = pp.idPedido;
                    }
                }


                DAL.cesta cesta = db.cesta.Find(idArticulo, idPedido);
                cesta.calificacion = calificacion;
                db.Entry(cesta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            Refresh();
        }



        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            string idArticuloPedido = (string)((Button)sender).CommandParameter;
            calificacion(idArticuloPedido, 1);
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            string idArticuloPedido = (string)((Button)sender).CommandParameter;
            calificacion(idArticuloPedido, 2);
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            string idArticuloPedido = (string)((Button)sender).CommandParameter;
            calificacion(idArticuloPedido, 3);
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            string idArticuloPedido = (string)((Button)sender).CommandParameter;
            calificacion(idArticuloPedido, 4);
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            string idArticuloPedido = (string)((Button)sender).CommandParameter;
            calificacion(idArticuloPedido, 5);
        }
    }
}
