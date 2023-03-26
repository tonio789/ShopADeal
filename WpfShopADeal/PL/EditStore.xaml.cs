using System;
using System.Windows;

namespace WpfShopADeal
{
    /// <summary>
    /// Lógica de interacción para EditStore.xaml
    /// </summary>
    public partial class EditStore : Window
    {
        public DAL.usuario usuario;
        public DAL.tienda tienda;
        public bool nuevaTienda = false;

        public EditStore(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            this.nuevaTienda = true;
        }



        public EditStore(DAL.usuario usuario, DAL.tienda tienda)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tienda = tienda;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;

            txt_nombre.Text = tienda.nombre;
            txt_cedula.Text = tienda.cedula.ToString();
            txt_direccion.Text = tienda.direccion;
            txt_telefono.Text = tienda.telefono.ToString();
            txt_correo.Text = tienda.correo;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            new EditStores(this.usuario).Show();
            this.Close();
        }

        private void btn_listo_Click(object sender, RoutedEventArgs e)
        {
            string cedula = txt_cedula.Text;
            string telefono = txt_telefono.Text;

            bool isNumberCed = int.TryParse(cedula, out int ced);
            bool isNumberTel = int.TryParse(telefono, out int tel);

            if (!isNumberCed)
            {
                MessageBox.Show("La cedula debe solo contener numeros.");
                txt_cedula.Text = "";
            } else if (!isNumberTel)
            {
                MessageBox.Show("El telefono debe solo contener numeros.");
                txt_telefono.Text = "";
            } else
            {
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    
                    if (nuevaTienda)
                    {

                        //agregar

                        DAL.tienda tienda = new DAL.tienda();
                        tienda.nombre = txt_nombre.Text;
                        tienda.direccion = txt_direccion.Text;
                        tienda.correo = txt_correo.Text;
                        tienda.cedula = Convert.ToInt32(cedula);
                        tienda.telefono = Convert.ToInt32(telefono);
                        tienda.usuario_cedula = this.usuario.cedula;

                        db.tienda.Add(tienda);
                        db.SaveChanges();
                    }
                    else
                    {

                        DAL.tienda tienda = db.tienda.Find(this.tienda.codigo);
                        tienda.nombre = txt_nombre.Text;
                        tienda.direccion = txt_direccion.Text;
                        tienda.correo = txt_correo.Text;
                        tienda.cedula = Convert.ToInt32(cedula);
                        tienda.telefono = Convert.ToInt32(telefono);
                        tienda.usuario_cedula = this.usuario.cedula;

                        //editar
                        db.Entry(tienda).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    new EditStores(this.usuario).Show();
                    this.Close();
                }
            }
        }
    }
}
