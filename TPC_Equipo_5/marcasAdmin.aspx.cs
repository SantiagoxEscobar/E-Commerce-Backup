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
    public partial class marcasAdmin : System.Web.UI.Page
    {
        public List<Marca> listaLecturaMarca;
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
                    dgvMarcas.DataSource = listaLecturaMarca;
                    dgvMarcas.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }

        }

        protected void btnBusquedaMarca_Click(object sender, EventArgs e)
        {
            try
            {

                busqueda = txtBuscarMarca.Text;
                if (ValidarTextBox(busqueda))
                {
                    filtrarMarca(busqueda);
                    dgvMarcas.DataSource = listaLecturaMarca;
                    dgvMarcas.DataBind();
                }
                else
                {
                    cargardatos();
                    dgvMarcas.DataSource = listaLecturaMarca;
                    dgvMarcas.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlOrdenarMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                List<Marca> listaFiltrada;

                if (ddlOrdenarMarca.SelectedValue == "Ascendente")
                {
                    listaFiltrada = listaLecturaMarca.OrderBy(x => x.nombre).ToList();
                }
                else if (ddlOrdenarMarca.SelectedValue == "Descendente")
                {
                    listaFiltrada = listaLecturaMarca.OrderByDescending(x => x.nombre).ToList();
                }
                else
                {
                    listaFiltrada = listaLecturaMarca.OrderBy(x => x.id).ToList();
                }
                listaLecturaMarca = listaFiltrada;
                dgvMarcas.DataSource = listaLecturaMarca;
                dgvMarcas.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string id = dgvMarcas.SelectedDataKey.Value.ToString();
                Response.Redirect("ModificarMarca.aspx?id="+id, false);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }


            //Nueva ventana o usar javascript para abrir un modal
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca.aspx", false);
        }
        public void cargardatos()
        {
            try
            {

                LecturaMarca lecturaMarca = new LecturaMarca();
                listaLecturaMarca = lecturaMarca.listar();
                dgvMarcas.DataSource = listaLecturaMarca;
                dgvMarcas.DataBind();
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
            int cantidadRegistros = listaLecturaMarca.Count();
            listaMostrable = true;
            if (cantidadRegistros < 1)
            {
                listaMostrable = false;
            }
        }

        private void filtrarMarca(string filtro)
        {
            try
            {

                List<Marca> listaFiltrada;
                listaFiltrada = listaLecturaMarca.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper()));
                listaLecturaMarca = listaFiltrada;
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
                ddlOrdenarMarca.Items.Add("Por defecto");
                ddlOrdenarMarca.Items.Add("Ascendente");
                ddlOrdenarMarca.Items.Add("Descendente");

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvMarcas.PageIndex = e.NewPageIndex;
                dgvMarcas.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}