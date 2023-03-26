using WpfShopADeal.Metodos;
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

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public DAL.usuario usuario;
        public bool dropVisible = false;
        public Principal(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (dropVisible)
            {

                btn_edituser.Visibility = Visibility.Hidden;
                btn_eraseuser.Visibility = Visibility.Hidden;
                btn_logout.Visibility = Visibility.Hidden;
                dropVisible = false;
            }
            else
            {
                btn_edituser.Visibility = Visibility.Visible;
                btn_eraseuser.Visibility = Visibility.Visible;
                btn_logout.Visibility = Visibility.Visible;
                dropVisible = true;
            }
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
        private void btn_Explorar_Click(object sender, RoutedEventArgs e)
        {
            new Shop(this.usuario).Show();
            this.Close();
        }

        private void btn_edituser_Click(object sender, RoutedEventArgs e)
        {
            new EditUser(this.usuario).Show();
            this.Close();
        }

        private void btn_eraseuser_Click(object sender, RoutedEventArgs e)
        {
            new DeleteUser(this.usuario).Show();
            this.Close();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            new Index().Show();
            this.Close();
        }

        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            new ShoppingCart(this.usuario).Show();
            this.Close();
        }
    }
}
