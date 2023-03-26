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
    /// Lógica de interacción para Register2.xaml
    /// </summary>
    public partial class Register2 : Window
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
        public Register2(string usuario, string clave, string cedula, string nombre, string apellido1, string apellido2, string correo, string direccion, string telefono)
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

            txt_cedula.Text = cedula.ToString();
            txt_nombre.Text = nombre;
            txt_apellido1.Text = apellido1;
            txt_apellido2.Text = apellido2;
        }

        private void btn_volver2_Click(object sender, RoutedEventArgs e)
        {
            string cedula = txt_cedula.Text;
            string nombre = txt_nombre.Text;
            string apellido1 = txt_apellido1.Text;
            string apellido2 = txt_apellido2.Text;
            new Register1(this.usuario, this.clave, cedula, nombre, apellido1, apellido2, this.correo, this.direccion, this.telefono).Show();
            this.Close();
        }

        private void btn_continuar2_Click(object sender, RoutedEventArgs e)
        {
            string cedula = txt_cedula.Text;
            string nombre = txt_nombre.Text;
            string apellido1 = txt_apellido1.Text;
            string apellido2 = txt_apellido2.Text;

            bool isNumber = int.TryParse(cedula, out int DNI);
            bool cedulaUnica = true;
            List<UsuarioClave> lst = new List<UsuarioClave>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.usuario select new UsuarioClave { cedula = (int)d.cedula, usuario = d.nombreusuario, correo = d.correo, clave = d.clave }).ToList();
            }
            foreach (UsuarioClave uc in lst)
            {
                if (uc.cedula.ToString() == cedula)
                {
                    cedulaUnica = false;
                }
            }



            if (cedula == null || nombre == null || apellido1 == null || cedula == "" || nombre == "" || apellido1 == "")
            {
                MessageBox.Show("No puedes dejar campos en blanco, solo el segundo apellido es opcional.\n\nPor favor virifique los espacios");
            }
            else
            {
                if (!isNumber)
                {
                    MessageBox.Show("Solo puedes ingresar numeros en la cedula");
                    txt_cedula.Text = "";
                }
                else
                {
                    if (!cedulaUnica)
                    {
                        MessageBox.Show($"La cedula {cedula} ya existe\nPor favor verifique su cedula.");
                        txt_cedula.Text = "";
                    }
                    else
                    {
                        new Registro3(this.usuario, this.clave, cedula, nombre, apellido1, apellido2, this.correo, this.direccion, this.telefono).Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
