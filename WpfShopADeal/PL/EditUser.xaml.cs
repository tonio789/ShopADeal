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
    /// Lógica de interacción para EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        DAL.usuario usuario;
        public EditUser(DAL.usuario usuario)
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
            string nombreusuario = txt_nombreUsuario.Text;
            string clave = txt_clave.Text;
            string nombre = txt_nombre.Text;
            string apellido1 = txt_Apellido1.Text;
            string apellido2 = txt_Apellido2.Text;
            string correo = txt_correo.Text;
            string direccion = txt_direccion.Text;
            string telefono = txt_telefono.Text;

            if (nombreusuario == null || nombreusuario == "" || clave == null || clave == "" || nombre == null || nombre == "" || apellido1 == null || apellido1 == "" || correo == null || correo == "" || direccion == null || direccion == "" || telefono == null || telefono == "")
            {
                MessageBox.Show("No puedes dejar campos en blanco, solo el segundo apellido es opcional.\n\nPor favor virifique los espacios");
            }
            else
            {
                //bool uniqueUser = new Usuario().Register_ConfirmUserName(nombreusuario);
                bool correoUnico = true;
                bool usuarioUnico = true;
                bool isNumber = int.TryParse(telefono, out int phone);

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

                    if (uc.usuario == nombreusuario)
                    {
                        correoUnico = false;
                    }
                }

                if (!usuarioUnico && nombreusuario != this.usuario.nombreusuario)
                {
                    MessageBox.Show($"El usuario {nombreusuario} ya existe.\nPor favor intente con un usuario diferente.");
                    txt_nombreUsuario.Text = "";
                }
                else if (!correoUnico && correo != this.usuario.correo)
                {
                    MessageBox.Show($"El correo {correo} ya existe\nPor favor verifique su correo.");
                    txt_correo.Text = "";
                }
                else if (!isNumber)
                {
                    MessageBox.Show("Solo puedes ingresar numeros en el telefono");
                    txt_telefono.Text = "";
                }
                else
                {
                    using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                    {
                        DAL.usuario usuario = db.usuario.Find(this.usuario.cedula);
                        usuario.nombreusuario = nombreusuario;
                        usuario.clave = clave;
                        usuario.nombre = nombre;
                        usuario.apellido1 = apellido1;
                        usuario.apellido2 = apellido2;
                        usuario.direccion = direccion;
                        usuario.correo = correo;
                        usuario.telefono = Convert.ToInt32(telefono);

                        db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        new Principal(db.usuario.Find(usuario.cedula)).Show();
                        this.Close();
                    }

                    //DataAccessLayer.usuario user = new Usuario(this.usuario.cedula, nombreusuario, nombre, apellido1, apellido2, direccion, Convert.ToInt32(telefono), correo, clave, this.usuario.rol, this.usuario.estado);
                    //new Usuario().UpdateUser(user);

                }
            }
        }

        private void txt_nombreUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
