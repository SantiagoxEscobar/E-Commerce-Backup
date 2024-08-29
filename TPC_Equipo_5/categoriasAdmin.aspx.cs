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
    public partial class categoriasAdmin : System.Web.UI.Page
    {
        public List<Categoria> listaLecturaCategoria;
        string busqueda;
        public bool listaMostrable;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                cargardatos();

                if (!IsPostBack)
                {

                    cargarddl();
                    dgvCategorias.DataSource = listaLecturaCategoria;
                    dgvCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnBusquedaCategoria_Click(object sender, EventArgs e)
        {
            try
            {

                busqueda = txtBuscarCategoria.Text;
                if (ValidarTextBox(busqueda))
                {
                    filtrarCategoria(busqueda);
                    dgvCategorias.DataSource = listaLecturaCategoria;
                    dgvCategorias.DataBind();
                }
                else
                {
                    cargardatos();
                    dgvCategorias.DataSource = listaLecturaCategoria;
                    dgvCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlOrdenarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                List<Categoria> listaFiltrada;

                if (ddlOrdenarCategoria.SelectedValue == "Ascendente")
                {
                    listaFiltrada = listaLecturaCategoria.OrderBy(x => x.nombre).ToList();
                }
                else if (ddlOrdenarCategoria.SelectedValue == "Descendente")
                {
                    listaFiltrada = listaLecturaCategoria.OrderByDescending(x => x.nombre).ToList();
                }
                else
                {
                    listaFiltrada = listaLecturaCategoria.OrderBy(x => x.id).ToList();
                }
                listaLecturaCategoria = listaFiltrada;
                dgvCategorias.DataSource = listaLecturaCategoria;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = dgvCategorias.SelectedDataKey.Value.ToString();
                Response.Redirect("ModificarCategoria.aspx?id="+id,false);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnAgregarCategoría_Click(object sender, EventArgs e)
        {
            //var id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarCategoria.aspx",false);
            //Nueva ventana o usar javascript para abrir un modal
        }

        public void cargardatos()
        {
            try
            {

                LecturaCategoria lecturaCategoria = new LecturaCategoria();
                listaLecturaCategoria = lecturaCategoria.listar();
                dgvCategorias.DataSource = listaLecturaCategoria;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected bool ValidarTextBox(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void validarListaMostrable()
        {
            int cantidadRegistros = listaLecturaCategoria.Count();
            listaMostrable = true;
            if (cantidadRegistros < 1)
            {
                listaMostrable = false;
            }
        }

        private void filtrarCategoria(string filtro)
        {
            try
            {

                List<Categoria> listaFiltrada;
                listaFiltrada = listaLecturaCategoria.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper()));
                listaLecturaCategoria = listaFiltrada;
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        public void cargarddl()
        {
            try
            {

                ddlOrdenarCategoria.Items.Add("Por defecto");
                ddlOrdenarCategoria.Items.Add("Ascendente");
                ddlOrdenarCategoria.Items.Add("Descendente");
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                dgvCategorias.PageIndex = e.NewPageIndex;
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}