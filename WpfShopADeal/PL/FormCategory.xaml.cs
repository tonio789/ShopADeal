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
    /// Lógica de interacción para FormCategory.xaml
    /// </summary>
    public partial class FormCategory : Window
    {
        public DAL.usuario usuario;
        public DAL.categoria categoria;
        private bool isNew = true;

        public FormCategory(DAL.usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            

        }

        public FormCategory(DAL.usuario usuario, DAL.categoria categoria)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.categoria = categoria;
            btn_user.Content = usuario.nombre + " " + usuario.apellido1 + " " + usuario.apellido2;
            txt_nombre.Text = this.categoria.categoria1;
            txt_nombre.IsEnabled = false;
            txt_descripcion.Text = this.categoria.descripcion;
            isNew = false;
            
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            new Categories(this.usuario).Show();
            this.Close();
        }

        private void btn_listo_Click(object sender, RoutedEventArgs e)
        {
            string categ = txt_nombre.Text;
            string desc = txt_descripcion.Text;
            var newCategoria = new DAL.categoria();
            newCategoria.categoria1 = categ;
            newCategoria.descripcion = desc;
            bool isUnique = true;

            List<Categoria> lst = new List<Categoria>();
            using(DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lst = (from d in db.categoria select new Categoria {categoria = d.categoria1, descripcion = d.descripcion}).ToList();
            }
            foreach(Categoria c in lst)
            {
                if(c.categoria == categ)
                {
                    isUnique = false;
                }
            }

            if (desc == null || desc == "")
            {
                MessageBox.Show("Por favor agrega el detalle a la categoria.");
            } else if (this.isNew && !isUnique)
            {
                MessageBox.Show("Esta categoria ya exite, crea una diferente.");
            }
            else { 
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    if (isNew)
                    {
                        db.categoria.Add(newCategoria);
                        db.SaveChanges();
                    }
                    else { 
                
                        DAL.categoria categoria = db.categoria.Find(categ);
                        categoria.descripcion = desc;
                        db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                new Categories(this.usuario).Show();
                this.Close();
            }
        }

        
    }
}
