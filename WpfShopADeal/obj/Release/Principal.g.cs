﻿#pragma checksum "..\..\Principal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "74C1ABC0BF03EBC0900D46263AF5ACE72CAC58E7EA01AC0422CDB665DBDA61B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfShopADeal;


namespace WpfShopADeal {
    
    
    /// <summary>
    /// Principal
    /// </summary>
    public partial class Principal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Explorar;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_user;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_edituser;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_eraseuser;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_logout;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_comprar;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_tiendas;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_compras;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Principal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_categorias;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfShopADeal;component/principal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Principal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.btn_Explorar = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\Principal.xaml"
            this.btn_Explorar.Click += new System.Windows.RoutedEventHandler(this.btn_Explorar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_user = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\Principal.xaml"
            this.btn_user.Click += new System.Windows.RoutedEventHandler(this.OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_edituser = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\Principal.xaml"
            this.btn_edituser.Click += new System.Windows.RoutedEventHandler(this.btn_edituser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_eraseuser = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Principal.xaml"
            this.btn_eraseuser.Click += new System.Windows.RoutedEventHandler(this.btn_eraseuser_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_logout = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\Principal.xaml"
            this.btn_logout.Click += new System.Windows.RoutedEventHandler(this.btn_logout_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_comprar = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Principal.xaml"
            this.btn_comprar.Click += new System.Windows.RoutedEventHandler(this.btn_comprar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_tiendas = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\Principal.xaml"
            this.btn_tiendas.Click += new System.Windows.RoutedEventHandler(this.btn_tiendas_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_compras = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\Principal.xaml"
            this.btn_compras.Click += new System.Windows.RoutedEventHandler(this.btn_compras_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_categorias = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\Principal.xaml"
            this.btn_categorias.Click += new System.Windows.RoutedEventHandler(this.btn_categorias_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
