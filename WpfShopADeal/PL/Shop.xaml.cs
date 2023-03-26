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
using WpfShopADeal.DAL;

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
       public DAL.usuario usuario;
       public int pedido;
        private bool filtered;

        public Shop(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            pedido = nPedido();

            filtered = false;

            Refresh();
            RefreshCategoria();

            
        }

        private void RefreshCategoria()
        {
            List<Categoria> lst = new List<Categoria>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.categoria select new Categoria { categoria = d.categoria1}).ToList();
            }
            List<string> lstString = new List<string>();
            foreach(Categoria c in lst)
            {
                lstString.Add(c.categoria);
            }

            lbCat.ItemsSource = lstString;
        }

        private List<Cesta> Cesta()
        {
            List<Cesta> lst = new List<Cesta>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.cesta select new Cesta { idArticulo = (int)d.articulo_id, idPedido = (int)d.pedido_numpedido, cantidad = (int)d.cantidad , calificacion = (int)d.calificacion}).ToList();
            }

            return lst;
        }



        private int Cantidades(int idArt)
        {
            int cantidad = 0;

            foreach(Cesta c in Cesta())
            {
                if(c.idArticulo == idArt && c.idPedido == this.pedido)
                {
                    cantidad =+ c.cantidad;
                }
            }

            return cantidad;
        }


        private List<Pedidos> Pedidos()
        {
            List<Pedidos> lst = new List<Pedidos>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.pedido select new Pedidos { id = (int)d.numpedido, tipo = d.tipodoc, idUsuario = (int)d.usuario_cedula}).ToList();
            }

            return lst;
        } 

        private int nPedido()
        {
            int pedido = 0;
            bool tienePedidoAbierto = false;
            foreach(Pedidos p in Pedidos())
            {
                //"A" significa abierto
                if(p.idUsuario == this.usuario.cedula && p.tipo == "A")
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


        private List<Compra> lstCompra()
        {
            List<Compra> lst = new List<Compra>();
            using(DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.articulo select new Compra { idArticulo = (int)d.id, nombre = d.nombre, descripcion = d.descripcion, categoria = d.categoria_categoria, codTienda = (int)d.tienda_codigo, precio = (double)d.precio}).ToList();
                
                foreach (Compra c in lst)
                {
                    c.nombreDescripcion = c.nombre + "\n" + c.descripcion;
                    c.tienda = db.tienda.Find(c.codTienda).nombre;
                    c.calificacion = lstCestaCalif(c.idArticulo);
                    c.cantidad = Cantidades(c.idArticulo);
                }
            }
            return lst;
        }

        private double lstCestaCalif(int idArticulo)
        {
            double cantidad = 0;
            double sumCalificacion = 0;
            foreach (Cesta c in Cesta())
            {
                if(c.idArticulo == idArticulo)
                {
                    sumCalificacion += c.calificacion;
                    cantidad++;
                }
            }

            double calificacion = 0;
            if (sumCalificacion != 0)
            {
                calificacion = sumCalificacion / cantidad;
            }
            
            return calificacion;
        }


        private void Refresh()
        {
            DG.ItemsSource = lstCompra();
        }

        private void RefreshFiltered( string categoria)
        {
            List<Compra> lst = new List<Compra>();

            foreach(Compra c in lstCompra())
            {
                if(categoria == c.categoria)
                {
                    lst.Add(c);
                }
            }
            DG.ItemsSource = lst;
        }


        private void lbArticulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshFiltered(lbCat.SelectedValue.ToString());
            filtered = true;
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            filtered = false;
        }

        private void btn_disminuir_Click(object sender, RoutedEventArgs e)
        {
            int idArticulo = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            { 
            

                if(Cantidades(idArticulo) == 0)
                {

                } else if(Cantidades(idArticulo) == 1)
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

                if (filtered)
                {
                    RefreshFiltered(lbCat.SelectedValue.ToString());
                }
                else
                {
                    Refresh();
                }

            }

        }


        private bool estaEnCesta(int idArticulo)
        {

            bool esta = false;
            foreach(Cesta c in Cesta())
            {
                if(c.idArticulo == idArticulo && c.idPedido == this.pedido)
                {
                    esta = true;
                }
            }

            return esta;
        }



        private void btn_aumentar_Click(object sender, RoutedEventArgs e)
        {
            int idArticulo = (int)((Button)sender).CommandParameter;




            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                if (estaEnCesta(idArticulo))
                {
                    DAL.cesta articuloEnCesta = db.cesta.Find(idArticulo, this.pedido);
                    articuloEnCesta.cantidad ++;
                    db.Entry(articuloEnCesta).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    DAL.cesta articuloNuevoEnCesta = new DAL.cesta();
                    articuloNuevoEnCesta.articulo_id = idArticulo;
                    articuloNuevoEnCesta.pedido_numpedido = this.pedido;
                    articuloNuevoEnCesta.cantidad = 1;
                    articuloNuevoEnCesta.calificacion = 0;
                    db.cesta.Add(articuloNuevoEnCesta);
                }
                db.SaveChanges();
            }

            if (filtered)
            {
                RefreshFiltered(lbCat.SelectedValue.ToString());
            }
            else 
            { 
            Refresh();
            }
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

        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            new ShoppingCart(this.usuario).Show();
            this.Close();
        }

        
    }
}
