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
    /// Lógica de interacción para EditTeam.xaml
    /// </summary>
    public partial class EditTeam : Window
    {
        public DAL.usuario usuario;
        public DAL.tienda tienda;
        public EditTeam(DAL.usuario usuario, DAL.tienda tienda)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tienda = tienda;

            lbl_tienda.Content = tienda.nombre;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;

            Refresh();
        }


        private List<Administra> lista()
        {
            List<Administra> lst = new List<Administra>();
            List<Administra> lstFiltered = new List<Administra>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.administra select new Administra { idUsuario = (int)d.usuario_cedula, idTienda = (int)d.tienda_codigo }).ToList();

                foreach (Administra a in lst)
                {
                    if (a.idTienda == this.tienda.codigo)
                    {
                        a.Usuario = db.usuario.Find((int)a.idUsuario).nombreusuario;
                        lstFiltered.Add(a);
                    }
                }
            }
            return lstFiltered;
        }

        private void Refresh()
        {
            DG.ItemsSource = lista();
        }

        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            new EditStores(this.usuario).Show();
            this.Close();
        }

        private void btn_agregarTienda_Click(object sender, RoutedEventArgs e)
        {
            string nomusuario = txt_nombreUsuario.Text;
            bool usuarioNuevo = true;
            bool usuarioExiste = false;
            int id = 0;

            List<UsuarioClave> lst = new List<UsuarioClave>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.usuario select new UsuarioClave { cedula = (int)d.cedula, usuario = d.nombreusuario }).ToList();
            }

            foreach (Administra a in lista())
            {
                if(nomusuario == a.Usuario)
                {
                    usuarioNuevo = false;
                }
            }

            foreach (UsuarioClave u in lst)
            {
                if (nomusuario == u.usuario)
                {
                    usuarioExiste = true;
                    id = u.cedula;
                }
            }


            if (txt_nombreUsuario.Text == null || txt_nombreUsuario.Text == ""|| txt_nombreUsuario.Text == this.usuario.nombreusuario)
            {
                MessageBox.Show("Por favor escribe un usuario valido para poder agregarlo a tu equipo.");
                
            } else if(!usuarioNuevo)
            {
                MessageBox.Show("Este usuario ya es parte del equipo.");
                
            }
            else if (!usuarioExiste)
            {
                MessageBox.Show("Este usuario no existe.");
                
            } else
            {
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    DAL.administra administra = new DAL.administra();
                    administra.usuario_cedula = id;
                    administra.tienda_codigo = this.tienda.codigo;

                    db.administra.Add(administra);
                    db.SaveChanges();
                    Refresh();
                    
                }
            }

            txt_nombreUsuario.Text = "";
        }

        private void btn_eliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var idUsuario = (int)((Button)sender).CommandParameter;

            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                var administra = db.administra.Find(idUsuario, this.tienda.codigo);
                db.administra.Remove(administra);
                db.SaveChanges();
            }
            Refresh();
        }

    
    }
}
