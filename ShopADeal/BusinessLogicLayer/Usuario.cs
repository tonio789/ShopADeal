using ShopADeal.DataConnection;
using System;
using System.Data;
using System.Security.Permissions;

namespace ShopADeal.Metodos
{
    public class Usuario
    {

        public int cedula { get; set; }
        public string nombreusuario { get; set; }
        public string nombre { get; set; }  
        public string apellido1{ get; set; }  
        public string apellido2{ get; set; }  
        public string direccion{ get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public char rol { get; set; }
        public char estado { get; set; } 
        public Usuario() { }

        public Usuario(int cedula, string nombreusuario, string nombre, string apellido1, string apellido2, string direccion, int telefono, string correo, string clave, char rol, char estado)
        {
            this.cedula = cedula;
            this.nombreusuario = nombreusuario;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
            this.clave = clave;
            this.rol = rol;
            this.estado = estado;
        }

        public Usuario Login_Usuario(string nomUsuario, string clave)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            new DAL().SQLAdapterSelectFrom("*", "usuario").Fill(dt2);
            new DAL().SQLAdapterSelectFromWhere("*", "usuario", $"usuario = '{nomUsuario}' or correo = '{nomUsuario}' and clave = '{clave}'").Fill(dt);
            

            Usuario username = null;
            if (dt != null)
            { 
                if (dt.Rows.Count > 0)
                {
                    username = new Usuario(Convert.ToInt32(dt.Rows[0]["cedula"]),dt.Rows[0]["nombreusuario"].ToString(), dt.Rows[0]["nombre"].ToString(), dt.Rows[0]["apellido1"].ToString(), dt.Rows[0]["apellido2"].ToString(), dt.Rows[0]["direccion"].ToString(),Convert.ToInt32(dt.Rows[0]["telefono"]), dt.Rows[0]["correo"].ToString(), dt.Rows[0]["clave"].ToString(), Convert.ToChar(dt.Rows[0]["rol"]), Convert.ToChar(dt.Rows[0]["estado"]));
                }
            }
            return username;
        }
        public bool Register_ConfirmPassword(string clave1, string clave2)
        {
            bool matched=false;
            if(clave1 != null && clave1 != "" && clave2 != null && clave2 != "")
            {
                if (clave1 == clave2)
                {
                    matched = true;
                }
                else
                {
                    matched = false;
                }
            }
            return matched;
        }
        public bool Register_ConfirmUserName(string nomUsuario)
        {
            DataTable dt = new DataTable();
             new DAL().SQLAdapterSelectFromWhere("usuario", "usuario", $"nombreusuario = '{nomUsuario}'").Fill(dt);

            bool unique = false;
            if (dt != null)
            {
                if (dt != null && dt.Rows.Count == 0)
                {
                    unique = true;
                }
            }
            return unique;
        }

        public bool Register_ConfirmCedula(string cedula)
        {
            DataTable dt = new DataTable();
            //{Convert.ToInt32(cedula)}
            new DAL().SQLAdapterSelectFromWhere("cedula", "usuario", $"cedula = '{cedula}'").Fill(dt);

            bool unique = false;
            if (dt != null && dt.Rows.Count == 0)
            {
                unique = true;
            }
            return unique;
        }

        public bool Register_ConfirmCorreo(string correo)
        {
            DataTable dt = new DataTable();
            new DAL().SQLAdapterSelectFromWhere("correo", "usuario", $"correo = '{correo}'").Fill(dt);

            bool unique = false;
            if (dt != null && dt.Rows.Count == 0)
            {
                unique = true;
            }
            return unique;
        }


        public void Register_AddUser(Usuario usuario)
        {
            new DAL().SQLAdapterInsert("usuario",$"cedula, usuario, nombre, apellido1, apellido2, direccion, telefono, correo, clave, rol, estado",$"{usuario.cedula},{usuario.nombreusuario},{usuario.nombre},{usuario.apellido1},{usuario.apellido2},{usuario.direccion},{usuario.telefono},{usuario.correo},{usuario.clave},{usuario.rol},{usuario.estado}");
        }
        public void Delete_User(Usuario usuario)
        {

        }

        
        

    }
}
