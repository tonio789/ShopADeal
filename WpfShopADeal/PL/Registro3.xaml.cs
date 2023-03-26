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
using WpfShopADeal.DAL;
using WpfShopADeal.BusinessLogicLayer;

namespace WpfShopADeal
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

            bool correoUnico = true;
            List<UsuarioClave> lst = new List<UsuarioClave>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.usuario select new UsuarioClave { cedula = (int)d.cedula, usuario = d.nombreusuario, correo = d.correo, clave = d.clave }).ToList();
            }
            foreach (UsuarioClave uc in lst)
            {
                if (uc.correo == correo)
                {
                    correoUnico = false;
                }
            }


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
                    if (!correoUnico)
                    {
                        MessageBox.Show($"El correo {correo} ya existe\nPor favor verifique su correo.");
                        txt_email.Text = "";
                    }
                    else
                    {
                        using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                        {
                            var usuario = new DAL.usuario();
                            usuario.nombreusuario = this.usuario;
                            usuario.clave = this.clave;
                            usuario.nombre = this.nombre;
                            usuario.apellido1 = this.apellido1;
                            usuario.apellido2 = this.apellido2;
                            usuario.direccion = txt_direction.Text;
                            usuario.correo = txt_email.Text;
                            usuario.rol = "C";
                            usuario.telefono = Convert.ToInt32(txt_phone.Text);
                            usuario.cedula = Convert.ToInt32(this.cedula);

                            db.usuario.Add(usuario);
                            db.SaveChanges();
                            new Login().Show();
                            this.Close();
                        }


                    }
                }
            }
        }
    }
}
