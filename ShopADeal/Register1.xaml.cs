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

            bool uniqueUser = new Usuario().Register_ConfirmUserName(usuario);
            bool claveMatch = new Usuario().Register_ConfirmPassword(clave1, clave2);

            if (usuario == null || clave1 == null || clave2 == null || usuario == "" || clave1 == "" || clave2 == "")
            {
                MessageBox.Show("No puedes dejar campos en blanco\n\nPor favor virifique los espacios");
            } else {
                if (!uniqueUser)
                {
                    MessageBox.Show($"El usuario {usuario} ya existe.\nPor favor intente con un usuario diferente.");
                    txt_nombreusuario.Text = "";
                } else if (!claveMatch)
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden.\nPor favor intentelo de nuevo.");
                    txt_clave1.Text = "";
                    txt_clave2.Text = "";
                } else
                {
                    new Register2(usuario, clave1, this.cedula, this.nombre,this.apellido1, this.apellido2,this.correo, this.direccion, this.telefono).Show();
                    this.Close();
                    txt_nombreusuario.Text = "";
                    txt_clave1.Text = "";
                    txt_clave2.Text = "";
                }
            }

        }
    }
}
