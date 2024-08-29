using Dominio;
using Dominio.Productos;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Usuarios;

namespace TPC_Equipo_5
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        List<Provincia> ListaProvincias;
        LecturaProvincia lecturaProvincias;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {


                    
                }

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        
        
        protected void Btn_CrearCuenta_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                try
                {
                    LecturaDatosUsuario lecturadatos = new LecturaDatosUsuario();
                    DatosUsuario datosUsuario = new DatosUsuario();
                    datosUsuario.nombre = Txt_Nombre.Text;
                    datosUsuario.apellido = Txt_Apellido.Text;                 
                    datosUsuario.email = Txt_Email.Text;                                                     
                    LecturaUsuario lecturaUsuario = new LecturaUsuario();
                    Usuario aux = new Usuario();
                    aux.usuario = Txt_Usuario.Text;
                    aux.password = Txt_Password.Text;
                    lecturaUsuario.agregar(aux, datosUsuario);
                    
                    ServiceEmail email = new ServiceEmail();
                    email.armarcorreo(Txt_Email.Text, "Cuenta creada correctamente 🥳", "Tu cuenta fue creada con exito! Asegurate de tener todos tu datos actualizado en tu perfil!! nos vemos pronto ❤️");
                    email.enviarEmail();

                    if (lecturaUsuario.loguear(aux))
                    {
                        Session.Add("usuario", aux);
                        Response.Redirect("default.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("Ventana_Usuario.aspx", false);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}