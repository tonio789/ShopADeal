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
    /// Lógica de interacción para FormArticle.xaml
    /// </summary>
    public partial class FormArticle : Window
    {
        DAL.usuario usuario;
        DAL.tienda tienda;
        DAL.articulo articulo;
        bool isNew = true;
        public FormArticle(DAL.usuario usuario, DAL.tienda tienda)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tienda = tienda;

            btn_user.Content = this.usuario.nombre + " " + this.usuario.apellido1 + " " + this.usuario.apellido2;


        }
        public FormArticle(DAL.usuario usuario, DAL.tienda tienda, DAL.articulo articulo)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tienda = tienda;
            this.articulo = articulo;
            btn_user.Content = this.usuario.nombre + " " + this.usuario.apellido1 + " " + this.usuario.apellido2;
            isNew = false;
            txt_nombre.Text = this.articulo.nombre;
            txt_descripcion.Text = this.articulo.descripcion;
            txt_categoria.Text = this.articulo.categoria_categoria;
            txt_codigobarras.Text = this.articulo.codigobarras;
            txt_precio.Text = (this.articulo.precio).ToString();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            new EditArticles(this.usuario, this.tienda).Show();
            this.Close();
        }

        private bool categoriaExiste(string categoria)
        {
            bool existe = false;

            List<Categoria> lista = new List<Categoria>();
            using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
            {
                lista = (from d in db.categoria select new Categoria { categoria = d.categoria1, descripcion = d.descripcion }).ToList();
            }

            foreach (Categoria c in lista)
            {
                if (c.categoria == categoria)
                {
                    existe = true;
                }
            }

            return existe;
        }

        private void btn_listo_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txt_nombre.Text;
            string descripcion = txt_descripcion.Text;
            string categoria = txt_categoria.Text;
            string codigobarras = txt_codigobarras.Text;
            string precio = txt_precio.Text;
            bool isDouble = double.TryParse(precio, out double d);


            if (nombre == null || nombre == "")
            {
                MessageBox.Show("El nombre es un campo oblicagorio.");
            } else if (descripcion == null || descripcion == "")
            {
                MessageBox.Show("La descripcion es un campo oblicagorio.");
            }
            else if (categoria == null || categoria == "")
            {
                MessageBox.Show("La categoria es un campo oblicagorio.");
            }
            else if (!isDouble)
            {
                MessageBox.Show("El precio solo puede contener numeros.");
                txt_precio.Text = "";
            }
            else if (precio == null || Convert.ToDouble(precio) < 0)
            {
                MessageBox.Show("El precio es un campo oblicagorio y no puede ser negativo.");
            }
            else if (!categoriaExiste(categoria))
            {
                MessageBox.Show("La categoria no existe, valide que la categoria este bien digitada.");
                txt_categoria.Text = "";
            }
            else if (isNew)
            {
                DAL.articulo a = new DAL.articulo();

                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    a.nombre = nombre;
                    a.descripcion = descripcion;
                    a.codigobarras = codigobarras;
                    a.precio = Convert.ToDecimal(precio);
                    a.categoria = db.categoria.Find(categoria);
                    a.tienda = db.tienda.Find(this.tienda.codigo);

                    db.articulo.Add(a);
                    db.SaveChanges();
                    new EditArticles(this.usuario, this.tienda).Show();
                    this.Close();
                }
            }
            else if (!isNew)
            {
                using (DAL.dbshopadealEntities db = new DAL.dbshopadealEntities())
                {
                    DAL.articulo a = db.articulo.Find(this.articulo.id);
                    a.nombre = nombre;
                    a.descripcion = descripcion;
                    a.codigobarras = codigobarras;
                    a.precio = Convert.ToDecimal(precio);
                    a.categoria = db.categoria.Find(categoria);
                    a.tienda = db.tienda.Find(this.tienda.codigo);
                    

                    db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    new EditArticles(this.usuario, this.tienda).Show();
                    this.Close();
                }
            }

            
        }
    }
}
