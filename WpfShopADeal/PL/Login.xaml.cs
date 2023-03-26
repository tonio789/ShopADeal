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
using System.Windows.Media.Media3D;
using WpfShopADeal.DAL;
using WpfShopADeal.BusinessLogicLayer;

namespace WpfShopADeal
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
            new Register1("", "", "", "", "", "", "", "", "").Show();
            this.Close();
        }

        private void btn_IrIndex_Click(object sender, RoutedEventArgs e)
        {
            new Index().Show();
            this.Close();
        }

        private void btn_iniciarsesion_Click(object sender, RoutedEventArgs e)
        {
            string user = txt_nombreusuario.Text;
            string clave = txt_clave.Text;

            List<UsuarioClave> lst = new List<UsuarioClave>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.usuario select new UsuarioClave { cedula = (int)d.cedula, usuario = d.nombreusuario, correo = d.correo, clave = d.clave }).ToList();
            }

            bool match = false;
            UsuarioClave u = null;
            foreach (UsuarioClave us in lst)
            {
                if (us.usuario == user && us.clave == clave)
                {
                    match = true;
                    u = us;
                }
            }

            if (match)
            {
                DAL.usuario us;
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                { us = db.usuario.Find(u.cedula); }
                new Principal(us).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se encontro el usuario\n\nPor favor verifique sus datos \ne intentelo de nuevo");
            }

        }
    }

    
}
