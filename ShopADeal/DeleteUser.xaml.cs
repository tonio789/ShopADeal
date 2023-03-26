﻿using ShopADeal.Metodos;
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
    /// Lógica de interacción para DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        Usuario usuario;
        public DeleteUser(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            new Principal(this.usuario).Show();
            this.Close();
        }

        private void btn_confirmar_Click(object sender, RoutedEventArgs e)
        {
            string clave = txt_passwordcheck.Text;

            if(clave != null || clave != "")
            {
                MessageBox.Show("Por favor verifique su contraseña para poder eliminar la cuenta.");
            }
            else
            {
                Usuario usuarioValidado = new Usuario().Login_Usuario(this.usuario.nombreusuario, clave);

                if(usuarioValidado == null)
                {

                }
            }
        }
    }
}
