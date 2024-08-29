using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Pedidos;
using Dominio.Productos;
using LecturaDatos;

namespace TPC_Equipo_5
{
    public partial class pedidosAdmin : System.Web.UI.Page
    {
        public List<Pedido> listaLecturaPedido;
        public List<Pedido> pedidosFiltrados;
        string busqueda;
        string seleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargardatos();
                if (!IsPostBack)
                {
                    cargarddl();
                    rblFiltroBusqueda.SelectedIndex = 0;
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
                    dgvPedidos.DataSource = pedidosFiltrados;
                    dgvPedidos.DataBind();
                }
                else
                {
                    cargardatos();
                    dgvPedidos.DataSource = listaLecturaPedido;
                    dgvPedidos.DataBind();
                    rblFiltroBusqueda.SelectedIndex = 0;
                    ddlOrdenar.SelectedIndex = 0;
                    ChkEnProceso.Checked = false;
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
                busqueda = txtBuscar.Text;
                ordenarProducto(busqueda);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ChkEnProceso_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                busqueda = txtBuscar.Text;
                if (ValidarTextBox(busqueda))
                {
                    filtrarProducto(busqueda);
                    ordenarProducto(busqueda);
                    if (ChkEnProceso.Checked)
                    {
                        filtroEnProceso(busqueda);
                    }
                    else
                    {
                        dgvPedidos.DataSource = pedidosFiltrados;
                        dgvPedidos.DataBind();
                    }
                }
                else
                {
                    ordenarProducto(busqueda);
                    if (ChkEnProceso.Checked)
                    {
                        filtroEnProceso(busqueda);
                    }
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seleccionado = dgvPedidos.SelectedDataKey.Value.ToString();
                Response.Redirect("DetallePedidoAdmin.aspx?id=" + seleccionado, false);
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
                LecturaPedido lecturaPedido = new LecturaPedido();
                listaLecturaPedido = lecturaPedido.listar();
                dgvPedidos.DataSource = listaLecturaPedido;
                dgvPedidos.DataBind();
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
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void filtrarProducto(string filtro)
        {
            try
            {
                if (rblFiltroBusqueda.SelectedValue == "N° Pedido")
                {
                    pedidosFiltrados = listaLecturaPedido.FindAll(x => x.id.ToString().ToUpper().Contains(filtro.ToUpper()));
                }
                else if (rblFiltroBusqueda.SelectedValue == "Cliente")
                {
                    pedidosFiltrados = listaLecturaPedido.FindAll(x => x.usuario.usuario.ToUpper().Contains(filtro.ToUpper()));
                }
                else if (rblFiltroBusqueda.SelectedValue == "Fecha")
                {
                    pedidosFiltrados = listaLecturaPedido.FindAll(x => x.fecha.ToString().ToUpper().Contains(filtro.ToUpper()));
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        private void ordenarProducto(string busqueda)
        {
            try
            {
                List<Pedido> listaFiltrada;
                pedidosFiltrados = new List<Pedido>();

                if (ValidarTextBox(busqueda))
                {
                    if (ChkEnProceso.Checked)
                    {
                        filtroEnProceso(busqueda);
                        filtrarProducto(busqueda);
                        if (ddlOrdenar.SelectedValue == "Más recientes")
                        {
                            listaFiltrada = pedidosFiltrados.OrderByDescending(x => x.fecha).ToList();
                        }
                        else if (ddlOrdenar.SelectedValue == "Más antiguos")
                        {
                            listaFiltrada = pedidosFiltrados.OrderBy(x => x.fecha).ToList();
                        }
                        else
                        {
                            listaFiltrada = pedidosFiltrados.OrderBy(x => x.id).ToList();
                        }
                        pedidosFiltrados = listaFiltrada;
                        dgvPedidos.DataSource = pedidosFiltrados;
                        dgvPedidos.DataBind();
                    }
                    else
                    {
                        cargardatos();
                        dgvPedidos.DataSource = listaLecturaPedido;
                        dgvPedidos.DataBind();
                    }
                }
                else
                {
                    if (ChkEnProceso.Checked)
                    {
                        filtroEnProceso(busqueda);
                        if (ddlOrdenar.SelectedValue == "Más recientes")
                        {
                            listaFiltrada = listaLecturaPedido.OrderByDescending(x => x.fecha).ToList();
                        }
                        else if (ddlOrdenar.SelectedValue == "Más antiguos")
                        {
                            listaFiltrada = listaLecturaPedido.OrderBy(x => x.fecha).ToList();
                        }
                        else
                        {
                            listaFiltrada = listaLecturaPedido.OrderBy(x => x.id).ToList();
                        }
                        listaLecturaPedido = listaFiltrada;
                        dgvPedidos.DataSource = listaLecturaPedido;
                        dgvPedidos.DataBind();
                    }
                    else
                    {
                        if (ddlOrdenar.SelectedValue == "Más recientes")
                        {
                            listaFiltrada = listaLecturaPedido.OrderByDescending(x => x.fecha).ToList();
                        }
                        else if (ddlOrdenar.SelectedValue == "Más antiguos")
                        {
                            listaFiltrada = listaLecturaPedido.OrderBy(x => x.fecha).ToList();
                        }
                        else
                        {
                            listaFiltrada = listaLecturaPedido.OrderBy(x => x.id).ToList();
                        }
                        listaLecturaPedido = listaFiltrada;
                        dgvPedidos.DataSource = listaLecturaPedido;
                        dgvPedidos.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        private void quitarCompletados(string busqueda)
        {
            try
            {
                List<Pedido> listaFiltrada;
                pedidosFiltrados = new List<Pedido>();

                if (ValidarTextBox(busqueda))
                {
                    listaFiltrada = pedidosFiltrados.FindAll(x => x.estadoPedido.nombre != "Completado");
                    pedidosFiltrados = listaFiltrada;
                    dgvPedidos.DataSource = pedidosFiltrados;
                    dgvPedidos.DataBind();
                }
                else
                {
                    listaFiltrada = listaLecturaPedido.FindAll(x => x.estadoPedido.nombre != "Completado");
                    listaLecturaPedido = listaFiltrada;
                    dgvPedidos.DataSource = listaLecturaPedido;
                    dgvPedidos.DataBind();
                }
            }

            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);

            }
        }

        private void filtroEnProceso(string busqueda)
        {
            List<Pedido> listaFiltrada;

            if (ValidarTextBox(busqueda))
            {
                listaFiltrada = pedidosFiltrados.FindAll(x => x.estadoPedido.nombre != "Completado");
                pedidosFiltrados = listaFiltrada;
                listaFiltrada = pedidosFiltrados.FindAll(x => x.estadoPedido.nombre != "Cancelado");
                pedidosFiltrados = listaFiltrada;

                dgvPedidos.DataSource = pedidosFiltrados;
                dgvPedidos.DataBind();
            }
            else
            {
                listaFiltrada = listaLecturaPedido.FindAll(x => x.estadoPedido.nombre != "Completado");
                listaLecturaPedido = listaFiltrada;
                listaFiltrada = listaLecturaPedido.FindAll(x => x.estadoPedido.nombre != "Cancelado");
                listaLecturaPedido = listaFiltrada;

                dgvPedidos.DataSource = listaLecturaPedido;
                dgvPedidos.DataBind();

            }
        }

        public void cargarddl()
        {
            try
            {
                ddlOrdenar.Items.Add("Por defecto");
                ddlOrdenar.Items.Add("Más recientes");
                ddlOrdenar.Items.Add("Más antiguos");
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvPedidos.PageIndex = e.NewPageIndex;
                dgvPedidos.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}