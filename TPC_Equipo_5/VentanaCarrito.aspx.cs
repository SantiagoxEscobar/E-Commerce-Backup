using Dominio.Pedidos;
using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPC_Equipo_5
{
    public partial class VentanaCarrito : System.Web.UI.Page
    {
        public List<Producto> listaLecturaProductos;
        public List<ProductosPedido> listaProductosPedidos;
        public Producto producto;
        public int indice = 0;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    listaProductosPedidos = (List<ProductosPedido>)Session["Carrito"];
                    if (listaProductosPedidos != null)
                    {
                        repCarrito.DataSource = listaProductosPedidos;
                        repCarrito.DataBind();

                        decimal totalCarrito = CalcularCarritoTotal(listaProductosPedidos);
                        lblTotalCompra.Text = "Total: $" + (totalCarrito).ToString("0.00");
                    }
                }          
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnEliminarOpcional_Click(object sender, EventArgs e)
        {
            try
            {

                int IdProducto = int.Parse(((Button)sender).CommandArgument);
                listaProductosPedidos = (List<ProductosPedido>)Session["Carrito"];

                List<ProductosPedido> nuevaLista = new List<ProductosPedido>();
                bool eliminado = false;

                foreach (var producto in listaProductosPedidos)
                {
                    if (!eliminado && producto.producto.id == IdProducto)
                    {
                        eliminado = true;
                    }
                    else
                    {
                        nuevaLista.Add(producto);
                    }
                }

                if (nuevaLista.Count == 0)
                {
                    Session["ArticulosEnCarrito"] = null;
                    Session.Add("Carrito", nuevaLista);
                    //Response.Redirect("default.aspx", false);
                }
                else
                {
                    repCarrito.DataSource = nuevaLista;
                    repCarrito.DataBind();
                    Session.Add("Carrito", nuevaLista);
                    decimal totalCarrito = CalcularCarritoTotal(nuevaLista);
                    lblTotalCompra.Text = "Total: $" + (totalCarrito).ToString("0.00");

                }
                    Label lblaux = (Label)Master.FindControl("Contador");
                    int contador = 0;
                    foreach (ProductosPedido productoRequerido in nuevaLista)
                    {
                        contador += productoRequerido.cantidad;
                    }
                    lblaux.Text = contador.ToString();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int IdProducto = int.Parse(((Button)sender).CommandArgument);
                listaLecturaProductos = (List<Producto>)Session["listaArticulosEnCarrito"];

                List<Producto> nuevaLista = new List<Producto>();
                bool eliminado = false;

                foreach (var producto in listaLecturaProductos)
                {
                    if (!eliminado && producto.id == IdProducto)
                    {
                        eliminado = true;
                    }
                    else
                    {
                        nuevaLista.Add(producto);
                    }
                }

                listaLecturaProductos = nuevaLista;
                if (listaLecturaProductos.Count == 0)
                {
                    Session["ArticulosEnCarrito"] = null;
                    Session.Add("listaArticulosEnCarrito", listaLecturaProductos);
                    Response.Redirect("default.aspx", false);
                }
                else
                {
                    repCarrito.DataSource = listaLecturaProductos;
                    repCarrito.DataBind();
                    Session.Add("listaArticulosEnCarrito", listaLecturaProductos);
                    decimal totalCarrito = CalcularCarritoTotal(listaLecturaProductos);

                    lblTotalCompra.Text = "Total: $" + (totalCarrito).ToString("0.00");

                    site master = (site)Master;
                    master.cantidadItems = listaLecturaProductos.Count().ToString();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnContinuarComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentanaCompra.aspx", false);
        }
        private decimal CalcularCarritoTotal(List<Producto> productos)
        {
            decimal total = 0;

            foreach (var producto in productos)
            {
                total += (decimal)producto.precio;
            }

            return total;
        }
        private decimal CalcularCarritoTotal(List<ProductosPedido> productos)
        {
            decimal total = 0;

            foreach (var producto in productos)
            {
                total += (decimal)producto.producto.precio * producto.cantidad;
            }

            return total;
        }
        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
           TextBox txtCantidad = sender as TextBox;
            
            int numero;
            if(int.TryParse(txtCantidad.Text,out numero))
            {
                if (int.Parse(txtCantidad.Text) < 1)
                {
                    txtCantidad.Text = "1";
                }
            }
            else
            {
                txtCantidad.Text = "1";
            }
        }
    }
}