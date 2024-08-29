using Dominio.Productos;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("marcasAdmin.aspx", false);

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                LecturaMarca lecturaMarca = new LecturaMarca();
                Marca nuevo = new Marca();
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    Session["error"] = "La categoria no puede tener un nombre vacio";
                    Response.Redirect("error.aspx");
                }
                nuevo.nombre = txtNombre.Text;
                lecturaMarca.agregar(nuevo);
                Response.Redirect("marcasAdmin.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}