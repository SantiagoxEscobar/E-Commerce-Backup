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
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        Categoria seleccionada = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                LecturaCategoria lecturaCategoria = new LecturaCategoria();
                int id = int.Parse(Request.QueryString["id"].ToString());
                seleccionada = lecturaCategoria.listar(id);
                if (!IsPostBack)
                {
                    txtCategoria.Text = seleccionada.nombre;
                    ckbActivo.Checked = seleccionada.estado;
                }
            } 
            catch (Exception ex) 
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }    
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("categoriasAdmin.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }  
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoria.Text))
                {
                    Session["error"] = "La categoria no puede tener un nombre vacio";
                    Response.Redirect("error.aspx");
                }
                LecturaCategoria lecturaCategoria = new LecturaCategoria();
                seleccionada.nombre = txtCategoria.Text;
                seleccionada.estado = ckbActivo.Checked;
                lecturaCategoria.modificar(seleccionada);
                Response.Redirect("categoriasAdmin.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }   
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LecturaCategoria lecturaCategoria = new LecturaCategoria();
                lecturaCategoria.eliminarFisica(seleccionada);
                Response.Redirect("categoriasAdmin.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}