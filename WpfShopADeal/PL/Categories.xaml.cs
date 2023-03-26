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
    /// Lógica de interacción para Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {

        public DAL.usuario usuario;
        public Categories(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Refresh();
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
        }

        private void Refresh()
        {
            List<Categoria> lista = new List<Categoria>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lista = (from d in db.categoria select new Categoria { categoria = d.categoria1, descripcion = d.descripcion}).ToList();
            }
            DG.ItemsSource = lista;
        }


        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            string categoria = (string)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var cat = db.categoria.Find(categoria);
                new FormCategory(this.usuario, cat).Show();
                this.Close();
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            string categoria = (string)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var cat = db.categoria.Find(categoria);
                db.categoria.Remove(cat);
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn_agregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            new FormCategory(this.usuario).Show();
            this.Close();
        }

        private void btn_categorias_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }
    }
}
