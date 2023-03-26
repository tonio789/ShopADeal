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
    /// Lógica de interacción para Registro3.xaml
    /// </summary>
    public partial class Registro3 : Window
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
        public Registro3(string usuario, string clave, string cedula, string nombre, string apellido1, string apellido2, string correo, string direccion, string telefono)
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

            txt_direction.Text = direccion;
            txt_email.Text = correo;
            txt_phone.Text = telefono;
        }

        private void btn_volver3_Click(object sender, RoutedEventArgs e)
        {
            string direccion = txt_direction.Text;
            string correo = txt_email.Text;
            string telefono = txt_phone.Text;
            new Register2(this.usuario, this.clave, this.cedula, this.nombre, this.apellido1, this.apellido2, correo, direccion, telefono).Show();
            this.Close();
        }

        private void btn_finalizar_Click(object sender, RoutedEventArgs e)
        {
            string direccion = txt_direction.Text;
            string correo = txt_email.Text;
            string telefono = txt_phone.Text;

            bool isNumber = int.TryParse(telefono, out int phone);

            if (direccion == null || correo == null || telefono == null || direccion == "" || correo == "" || telefono == "")
            {
                MessageBox.Show("No puedes dejar campos en blanco\n\nPor favor virifique los espacios");
            }
            else
            {
                if (!isNumber)
                {
                    MessageBox.Show("Solo puedes ingresar numeros en el telefono");
                    txt_phone.Text = "";
                }
                else
                {
                    if (!new Usuario().Register_ConfirmCorreo(correo))
                    {
                        MessageBox.Show($"El correo {correo} ya existe\nPor favor verifique su correo.");
                        txt_email.Text = "";
                    }
                    else
                    {
                        new Usuario().Register_AddUser(new Usuario(Convert.ToInt32(this.cedula), this.usuario, this.nombre, this.apellido1, this.apellido2, direccion, Convert.ToInt32(telefono), correo, this.clave, 'C', '1'));
                        new Login().Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
