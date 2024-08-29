using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Productos;
using LecturaDatos;

namespace TPC_Equipo_5
{
    public partial class productosAdmin : System.Web.UI.Page
    {
        public List<Producto> listaLecturaProducto;
        string busqueda;
        public bool listaMostrable;
        string seleccionado;
        public bool FiltroValido { get; set; }
        public string msgError { get; set; }
        public bool filtroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {   
               
                filtroAvanzado = chk_FiltroAvanzado.Checked;
                cargardatos();
                if (!IsPostBack)
                {
                    FiltroValido = true;
                    chk_FiltroAvanzado.Checked = false;
                    cargarddl();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda = txtBuscar.Text;
                if (ValidarTextBox(busqueda))
                {
                    filtrarProducto(busqueda);
                    dgvProductos.DataSource = listaLecturaProducto;
                    dgvProductos.DataBind();
                }
                else
                {
                    cargardatos();
                    dgvProductos.DataSource = listaLecturaProducto;
                    dgvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
            
        }
        protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                List<Producto> listaFiltrada;

                if (ddlOrdenar.SelectedValue == "Precio Mayor")
                {
                    listaFiltrada = listaLecturaProducto.OrderByDescending(x => x.precio).ToList();
                }
                else if (ddlOrdenar.SelectedValue == "Precio Menor")
                {
                    listaFiltrada = listaLecturaProducto.OrderBy(x => x.precio).ToList();
                }
                else if (ddlOrdenar.SelectedValue == "Stock Mayor")
                {
                    listaFiltrada = listaLecturaProducto.OrderByDescending(x => x.stock).ToList();
                }
                else if (ddlOrdenar.SelectedValue == "Stock Menor")
                {
                    listaFiltrada = listaLecturaProducto.OrderBy(x => x.stock).ToList();
                }
                else if (ddlOrdenar.SelectedValue == "Activos")
                {
                    listaFiltrada = filtrarXEstado(true);
                }
                else if (ddlOrdenar.SelectedValue == "Inactivos")
                {
                    listaFiltrada = filtrarXEstado(false);
                }
                else
                {
                    listaFiltrada = listaLecturaProducto.OrderBy(x => x.id).ToList();
                }
                listaLecturaProducto = listaFiltrada;
                dgvProductos.DataSource = listaLecturaProducto;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }  
        }
        protected List<Producto> filtrarXEstado(bool estado)
        {
            try
            {
                List<Producto> listaFiltrada;
                listaFiltrada = listaLecturaProducto.FindAll(x => x.estado == estado);
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seleccionado = dgvProductos.SelectedDataKey.Value.ToString();
                Response.Redirect("ModificarProducto.aspx?id=" + seleccionado, false);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }        
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AgregarProducto.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        public void cargardatos()
        {
            try
            {
                LecturaProducto lecturaProducto = new LecturaProducto();
                listaLecturaProducto = lecturaProducto.listar();
                dgvProductos.DataSource = listaLecturaProducto;
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
            
        }
        protected bool ValidarTextBox(string busqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(busqueda))
                {
                    return false;
                }
                    return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }     
        }
        public void validarListaMostrable()
        {
            try
            {
                int cantidadRegistros = listaLecturaProducto.Count();
                listaMostrable = true;
                if (cantidadRegistros < 1)
                {
                    listaMostrable = false;
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
            
        }
        private void filtrarProducto(string filtro)
        {
            try
            {
                List<Producto> listaFiltrada;
                listaFiltrada = listaLecturaProducto.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper()));
                if(listaFiltrada != null)
                    listaLecturaProducto = listaFiltrada;
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
                ddlOrdenar.Items.Add("Por defecto");
                ddlOrdenar.Items.Add("Activos");
                ddlOrdenar.Items.Add("Inactivos");
                ddlOrdenar.Items.Add("Precio Mayor");
                ddlOrdenar.Items.Add("Precio Menor");
                ddlOrdenar.Items.Add("Stock Mayor");
                ddlOrdenar.Items.Add("Stock Menor");
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void chk_FiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                lblAvisoCampo.Text = "";
                lblAvisoCriterio.Text = "";
                lblAvisoFiltro.Text = "";
                lblAvisoEstado.Text = "";
                filtroAvanzado = chk_FiltroAvanzado.Checked;
                txtBuscar.Enabled = !filtroAvanzado;
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void ddl_campo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_criterio.Items.Clear();
                if(ddl_campo.SelectedItem.ToString() == "Producto" || ddl_campo.SelectedItem.ToString() == "Descripcion" || ddl_campo.SelectedItem.ToString() == "Marca" || ddl_campo.SelectedItem.ToString() == "Categoria")
                {
                
                    ddl_criterio.Items.Add("Contiene");
                    ddl_criterio.Items.Add("Comienza por");
                    ddl_criterio.Items.Add("Termina Con");
                }   
                if (ddl_campo.SelectedItem.ToString() == "Precio" || ddl_campo.SelectedItem.ToString() == "Stock")
                {

                    ddl_criterio.Items.Add("Igual a");
                    ddl_criterio.Items.Add("Mayor a");
                    ddl_criterio.Items.Add("Menor a");
                }

                ddl_estado.Items.Clear();
                ddl_estado.Items.Add("Todo");
                ddl_estado.Items.Add("Activo");
                ddl_estado.Items.Add("Inactivo");
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }

        }
        protected void btnAccionarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                    
                    if (ddl_campo.SelectedItem == null || string.IsNullOrEmpty(ddl_campo.SelectedItem.ToString()))
                    {
                        lblAvisoCampo.Text = "Debes seleccionar un campo para usar el filtro";
                        lblAvisoCampo.CssClass = "text-danger";
                        return;
                    }
                    if (ddl_criterio.SelectedItem == null || string.IsNullOrEmpty(ddl_criterio.SelectedItem.ToString()))
                    {
                        lblAvisoCriterio.Text = "Debes elegir un criterio para usar el filtro";
                        lblAvisoCriterio.CssClass = "text-danger";
                        return;
                    }
                    if (string.IsNullOrEmpty(txtFiltro.Text))
                    {
                        lblAvisoFiltro.Text = "Debes completar el campo Filtro";
                        lblAvisoFiltro.CssClass = "text-danger";
                        return;
                    }
                    if ((ddl_campo.SelectedItem.ToString() == "Precio" || ddl_campo.SelectedItem.ToString() == "Stock") && !(filtroTieneNumero()))
                    {
                        lblAvisoFiltro.Text = "El campo solo permite numeros";
                        lblAvisoFiltro.CssClass = "text-danger";
                        return;
                    }

                    LecturaProducto lecturaProducto = new LecturaProducto();
                    List<Producto> nuevaLista = lecturaProducto.filtradoAvanzado(ddl_campo.SelectedItem.ToString(), ddl_criterio.SelectedItem.ToString(), txtFiltro.Text, ddl_estado.SelectedItem.ToString());
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = nuevaLista;
                    dgvProductos.DataBind();
                    lblAvisoCampo.Text = "";
                    lblAvisoCriterio.Text = "";
                    lblAvisoFiltro.Text = "";
                    lblAvisoEstado.Text = "";

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected bool filtroTieneNumero()
        {

            double numero;
            bool validacion;
            validacion = double.TryParse(txtFiltro.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out numero);

            if (!validacion)
            {
                validacion = double.TryParse(txtFiltro.Text, NumberStyles.Any, new CultureInfo("es-ES"), out numero);
            }
            
            return validacion;
        }
        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvProductos.PageIndex = e.NewPageIndex;
                dgvProductos.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}