using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LecturaDatos;
using Dominio.Productos;

namespace TPC_Equipo_5
{
    public partial class publicidadAdmin : System.Web.UI.Page
    {
        public List<Imagen> listaPublicidad;
        protected ScriptManager ScriptManager1;
        int contador = 0;
        int IdPublicidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            LecturaImagen LecturaImagen = new LecturaImagen();
            listaPublicidad = new List<Imagen>();
            listaPublicidad = LecturaImagen.listarPublicidad();

            try
            {
                contador = listaPublicidad.Count;

                if (!IsPostBack)
                {
                    RepPublicidad.DataSource = listaPublicidad;
                    RepPublicidad.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnModalAgregar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ResetModal",
                "$('#modalAgregar').modal('show');", true);
        }

        protected void btnModalCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                IdPublicidad = int.Parse(((Button)sender).CommandArgument);
                Session["idPublicidad"] = null;
                Session.Add("idPublicidad", IdPublicidad);
                ScriptManager.RegisterStartupScript(this, GetType(), "ResetModal",
                "$('#modalCambiar').modal('show');", true);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnModalEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IdPublicidad = int.Parse(((Button)sender).CommandArgument);
                Session["idPublicidad"] = null;
                Session.Add("idPublicidad", IdPublicidad);

                ScriptManager.RegisterStartupScript(this, GetType(), "ResetModal",
                "$('#modalEliminar').modal('show');", true);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txtAgregarUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imgAgregar.ImageUrl = txtAgregarUrl.Text;
                ScriptManager.RegisterStartupScript(this, GetType(), "ResetModal",
                "$('#modalAgregar').modal('show');", true);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imgPublicidad.ImageUrl = txtImagenUrl.Text;
                ScriptManager.RegisterStartupScript(this, GetType(), "ResetModal",
                "$('#modalCambiar').modal('show');", true);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LecturaImagen LecturaImagen = new LecturaImagen();
            LecturaImagen.AgregarPublicidad(txtAgregarUrl.Text);

            Response.Redirect("publicidadAdmin.aspx", false);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            IdPublicidad = Session["idPublicidad"] != null ? (int)Session["idPublicidad"] : IdPublicidad;
            LecturaImagen LecturaImagen = new LecturaImagen();
            LecturaImagen.ActualizarPublicidad(IdPublicidad, txtImagenUrl.Text);

            Response.Redirect("publicidadAdmin.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            IdPublicidad = Session["idPublicidad"] != null ? (int)Session["idPublicidad"] : IdPublicidad;
            LecturaImagen LecturaImagen = new LecturaImagen();
            LecturaImagen.eliminarPublicidad(IdPublicidad);

            Response.Redirect("publicidadAdmin.aspx", false);
        }
    }
}