using Dominio.Pedidos;
using Dominio.Usuarios;
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
    public partial class DetallePedidoAdmin : System.Web.UI.Page
    {
        List<ProductosPedido> listaProductos = new List<ProductosPedido>();
        Pedido seleccionado = new Pedido();
        DatosUsuario usuario = new DatosUsuario();
        int id = 0;
        decimal total = 0;
        public int estadoPedido = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());

                LecturaPedido lecturaPedido = new LecturaPedido();
                seleccionado = lecturaPedido.listar(id);

                LecturaProductosPedido lecturaProductosPedido = new LecturaProductosPedido();
                listaProductos = lecturaProductosPedido.listar(id);

                LecturaDatosUsuario lecturaDatosUsuario = new LecturaDatosUsuario();
                usuario = lecturaDatosUsuario.listar(seleccionado.usuario.id);

                estadoPedido = seleccionado.estadoPedido.id;
                total = CalcularCarritoTotal(listaProductos);

                if (!IsPostBack)
                {
                    
                    lblUsuario.NavigateUrl = "PerfilDetalle.aspx?id="+usuario.id.ToString();
                    lblNumeroPedido.Text = "N° PEDIDO: " + id.ToString();
                    lblUsuario.Text = seleccionado.usuario.usuario.ToString();
                    lblMetodoPago.Text = seleccionado.metodoPago.nombre.ToString();
                    lblEstado.Text = seleccionado.estadoPedido.nombre.ToString();
                    lblFecha.Text = seleccionado.fecha.ToString();

                    RepProductosxPedido.DataSource = listaProductos;
                    RepProductosxPedido.DataBind();

                    lblNombre.Text = usuario.nombre.ToString();
                    lblApellido.Text = usuario.apellido.ToString();
                    lblEmail.Text = usuario.email.ToString();
                    lblTelefono.Text = usuario.telefono.ToString();
                    lblDireccion.Text = usuario.direccion.ToString();

                    lblTotal.Text = "Total $ " + total.ToString("0.00");
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("pedidosAdmin.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx",false);
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            LecturaPedido lecturaPedido = new LecturaPedido();
            lecturaPedido.modificarEstado(id, estadoPedido);

            Response.Redirect("DetallePedidoAdmin.aspx?id=" + id.ToString(), false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LecturaPedido lecturaPedido = new LecturaPedido();
            lecturaPedido.bajaLogica(id);

            Response.Redirect("DetallePedidoAdmin.aspx?id=" + id.ToString(), false);
        }

        private decimal CalcularCarritoTotal(List<ProductosPedido> Productos)
        {
            try
            {

                foreach (var ProductosPedido in Productos)
                {
                    total += (decimal)ProductosPedido.producto.precio * ProductosPedido.cantidad;
                }
                return total;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}