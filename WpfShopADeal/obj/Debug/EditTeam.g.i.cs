// Updated by XamlIntelliSenseFileGenerator 8/12/2022 20:58:50
#pragma checksum "..\..\EditTeam.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3B391B9DA80803E2E67B977D13C0467CD7CE81B7F511A126C6ACB6EC8E9CA721"
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


namespace WpfShopADeal
{


    /// <summary>
    /// EditTeam
    /// </summary>
    public partial class EditTeam : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    {


#line 139 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;

#line default
#line hidden


#line 140 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_user;

#line default
#line hidden


#line 143 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DG;

#line default
#line hidden


#line 160 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_agregarTienda;

#line default
#line hidden


#line 161 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_tienda;

#line default
#line hidden


#line 163 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nombreUsuario;

#line default
#line hidden


#line 165 "..\..\EditTeam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_inicio;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfShopADeal;component/editteam.xaml", System.UriKind.Relative);

#line 1 "..\..\EditTeam.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Logo = ((System.Windows.Controls.Image)(target));
                    return;
                case 2:
                    this.btn_user = ((System.Windows.Controls.Button)(target));
                    return;
                case 3:
                    this.btn_edituser = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.btn_eraseuser = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.DG = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 7:
                    this.btn_agregarTienda = ((System.Windows.Controls.Button)(target));

#line 160 "..\..\EditTeam.xaml"
                    this.btn_agregarTienda.Click += new System.Windows.RoutedEventHandler(this.btn_agregarTienda_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.lbl_tienda = ((System.Windows.Controls.Label)(target));
                    return;
                case 9:
                    this.txt_nombreUsuario = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:
                    this.btn_inicio = ((System.Windows.Controls.Button)(target));

#line 165 "..\..\EditTeam.xaml"
                    this.btn_inicio.Click += new System.Windows.RoutedEventHandler(this.btn_inicio_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 6:

#line 151 "..\..\EditTeam.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_eliminarUsuario_Click);

#line default
#line hidden
                    break;
            }
        }
    }
}

