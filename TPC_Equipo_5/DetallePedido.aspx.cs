using Dominio.Pedidos;
using Dominio.Usuarios;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        List<ProductosPedido> listaProductos = new List<ProductosPedido>();
        Pedido seleccionado = new Pedido();
        DatosUsuario usuario = new DatosUsuario();
        int id = 0;
        decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());

                LecturaPedido lecturaPedido = new LecturaPedido();
                seleccionado = lecturaPedido.listar(id);

                LecturaProductosPedido lecturaProductosPedido = new LecturaProductosPedido();
                listaProductos = lecturaProductosPedido.listar(id);
                total = CalcularCarritoTotal(listaProductos);

                RepProductos.DataSource = listaProductos;
                RepProductos.DataBind();

                if (!IsPostBack)
                {
                    LblNumeroPedido.Text = "N° " + id.ToString();
                    LblFechaPedido.Text = seleccionado.fecha.ToString();
                    LblMetodoPago.Text = seleccionado.metodoPago.nombre.ToString();
                    LblEstado.Text = seleccionado.estadoPedido.nombre.ToString();

                    lblTotal.Text = "Total $" + total.ToString();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentanaPerfilUsuario.aspx");
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