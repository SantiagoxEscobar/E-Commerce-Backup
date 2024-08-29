using Dominio.Usuarios;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class Ventana_Usuario : System.Web.UI.Page
    {
        public bool correo_enviado= false;
         public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            correo_enviado = false;
        }


        protected void Btn_login_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            LecturaUsuario lecturaUsuario = new LecturaUsuario();
            try
            {
                usuario.usuario = TxtUser.Text;
                usuario.password = TxtPass.Text;
                if(lecturaUsuario.loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("default.aspx", false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx",false);
            }
        }

        protected void btnOlvidemipass_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceEmail email = new ServiceEmail();
                Usuario user = new Usuario();
                LecturaUsuario datos = new LecturaUsuario();
                user = (Usuario)Session["usuario"];
                datos.recuperarcontraseña(Txt_Email.Text, user);
                correo_enviado = true;
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }  
        }
    }
}