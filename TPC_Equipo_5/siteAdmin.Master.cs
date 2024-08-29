using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class siteAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Ventana_Usuario.aspx", false);
            }
            if(!(Seguridad.esAdmin(Session["usuario"])))
            {
                Session.Add("error", "necesitas permiso de administrador para acceder");
                Response.Redirect("error.aspx", false );
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }
    }

}