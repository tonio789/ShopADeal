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
using WpfShopADeal.BusinessLogicLayer;

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para Register1.xaml
    /// </summary>
    public partial class Register1 : Window
    {
        public string usuario;
        public string clave;
        public string cedula;
        public string nombre;
        public string apellido1;
        public string apellido2;
        public string correo;
        public string direccion;
        public string telefono;
        public Register1(string usuario, string clave, string cedula, string nombre, string apellido1, string apellido2, string correo, string direccion, string telefono)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.clave = clave;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.correo = correo;
            this.direccion = direccion;
            this.telefono = telefono;


            txt_nombreusuario.Text = usuario;
            txt_clave1.Text = clave;
            txt_clave2.Text = clave;
        }

        private void btn_volver1_Click(object sender, RoutedEventArgs e)
        {
            new Index().Show();
            this.Close();
        }

        private void btn_continuar1_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txt_nombreusuario.Text;
            string clave1 = txt_clave1.Text;
            string clave2 = txt_clave2.Text;

            bool uniqueUser = true;

            List<UsuarioClave> lst = new List<UsuarioClave>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.usuario select new UsuarioClave { cedula = (int)d.cedula, usuario = d.nombreusuario, correo = d.correo, clave = d.clave }).ToList();
            }

            foreach (UsuarioClave uc in lst)
            {
                if (uc.usuario == usuario)
                {
                    uniqueUser = false;
                }
            }

            bool claveMatch = new Usuario().Register_ConfirmPassword(clave1, clave2);

            if (usuario == null || clave1 == null || clave2 == null || usuario == "" || clave1 == "" || clave2 == "")
            {
                MessageBox.Show("No puedes dejar campos en blanco\n\nPor favor virifique los espacios");
            }
            else
            {
                if (!uniqueUser)
                {
                    MessageBox.Show($"El usuario {usuario} ya existe.\nPor favor intente con un usuario diferente.");
                    txt_nombreusuario.Text = "";
                }
                else if (!claveMatch)
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden.\nPor favor intentelo de nuevo.");
                    txt_clave1.Text = "";
                    txt_clave2.Text = "";
                }
                else
                {
                    new Register2(usuario, clave1, this.cedula, this.nombre, this.apellido1, this.apellido2, this.correo, this.direccion, this.telefono).Show();
                    this.Close();
                    txt_nombreusuario.Text = "";
                    txt_clave1.Text = "";
                    txt_clave2.Text = "";
                }
            }

        }
    }
}
