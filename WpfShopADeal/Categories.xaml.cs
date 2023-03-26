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
    /// Lógica de interacción para Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {

        public DAL.usuario usuario;
        public Categories(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
