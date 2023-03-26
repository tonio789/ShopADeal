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
    /// Lógica de interacción para EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        Usuario usuario;
        public EditUser(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            txt_nombreUsuario.Text = usuario.nombreusuario;
            txt_clave.Text = usuario.clave;
            txt_nombre.Text = usuario.nombre;
            txt_Apellido1.Text = usuario.apellido1;
            txt_Apellido2.Text = usuario.apellido2;
            txt_correo.Text = usuario.correo;
            txt_direccion.Text = usuario.direccion;
            txt_telefono.Text = usuario.telefono.ToString();
        }

        

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }

        private void btn_listo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
