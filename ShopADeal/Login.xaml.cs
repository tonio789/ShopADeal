using ShopADeal.Metodos;
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

namespace ShopADeal
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_crearcuenta_Click(object sender, RoutedEventArgs e)
        {
            new Register1("","","","","","","","","").Show();
            this.Close();
        }

        private void btn_IrIndex_Click(object sender, RoutedEventArgs e)
        {
            new Index().Show();
            this.Close();
        }

        private void btn_iniciarsesion_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txt_nombreusuario.Text;
            string clave = txt_clave.Text;

            Usuario user = new Usuario().Login_Usuario(usuario, clave);
            if (user == null)
            {
                MessageBox.Show("No se encontro el usuario\n\nPor favor verifique sus datos \ne intentelo de nuevo");
                
            }
            else
            {
                new Principal(user).Show();
                this.Close();
            }

            txt_nombreusuario.Text = "";
            txt_clave.Text = "";
        }
    }
}
