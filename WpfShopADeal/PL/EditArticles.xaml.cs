using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfShopADeal.BusinessLogicLayer;
namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para EditArticles.xaml
    /// </summary>
    public partial class EditArticles : Window
    {
        public DAL.usuario usuario;
        public DAL.tienda tienda;

        public EditArticles(DAL.usuario usuario, DAL.tienda tienda)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tienda = tienda;
            lbl_Tienda.Content = tienda.nombre;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            Refresh();
        }

        private List<Articulos> lista()
        {
            List<Articulos> lst = new List<Articulos>();
            List<Articulos> lstFiltered = new List<Articulos>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.articulo select new Articulos { id = (int)d.id, codTienda = (int)d.tienda_codigo , nombre = d.nombre, categoria = d.categoria_categoria, precio = (double)d.precio, descripcion = d.descripcion, codigoBarras = d.codigobarras }).ToList();

                foreach (Articulos a in lst)
                {
                    if (a.codTienda == this.tienda.codigo)
                    {
                        lstFiltered.Add(a);
                    }
                }
            }
            return lstFiltered;
        }

        private bool categoriaExiste(string categoria)
        {
            bool existe = false;

            List<Categoria> lista = new List<Categoria>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lista = (from d in db.categoria select new Categoria { categoria = d.categoria1, descripcion = d.descripcion }).ToList();
            }

            foreach (Categoria c in lista)
            {
                if(c.categoria == categoria)
                {
                    existe = true;
                }
            }

            return existe;
        }

        private void Refresh()
        {
            DG.ItemsSource = lista();
        }

        private void btn_agregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            new FormArticle(this.usuario, this.tienda).Show();
            this.Close();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                DAL.articulo a = db.articulo.Find(id);
                new FormArticle(this.usuario, this.tienda, a).Show();
                this.Close();
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                DAL.articulo a = db.articulo.Find(id);
                db.articulo.Remove(a);
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            new EditStores(this.usuario).Show();
            this.Close();
        }
    }
}
