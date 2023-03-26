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
    /// Lógica de interacción para EditStores.xaml
    /// </summary>
    public partial class EditStores : Window
    {
        DAL.usuario usuario;
        public EditStores(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Refresh();
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
        }

        private void Refresh()
        {
            List<Tienda> lst = new List<Tienda>();

            List<Tienda> lstfiltered = new List<Tienda>();
            using ( DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.tienda select new Tienda { id = d.codigo, nombre = d.nombre, idUsuario = (int)d.usuario_cedula }).ToList();
            }

            foreach(Tienda t in lst)
            {
                if (t.idUsuario == this.usuario.cedula)
                {
                    lstfiltered.Add(t);
                }
            }

            DG.ItemsSource = lstfiltered;
        }

        private void btn_editarArticulos_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var tienda = db.tienda.Find(id);
                new EditArticles(this.usuario, tienda).Show();
                this.Close();
            }
        }

        private void btn_editarEquipo_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var tienda = db.tienda.Find(id);
                new EditTeam(this.usuario, tienda).Show();
                this.Close();
            }
        }
        private void btn_editarTienda_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var tienda = db.tienda.Find(id);
                new EditStore(this.usuario, tienda).Show();
                this.Close();
            }
        }
        private void btn_eliminarTienda_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var tienda = db.tienda.Find(id);
                db.tienda.Remove(tienda);
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn_agregarTienda_Click(object sender, RoutedEventArgs e)
        {
            new EditStore(this.usuario).Show();
            this.Close();
        }

        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }
    }
}
