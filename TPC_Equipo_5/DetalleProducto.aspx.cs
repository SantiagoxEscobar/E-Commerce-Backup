using Dominio.Pedidos;
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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public bool carrusel { get; set; }
        public Producto producto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    int ID = int.Parse(Request.QueryString["ID"].ToString());
                    LecturaProducto lecturaProducto = new LecturaProducto();
                    producto = lecturaProducto.listar(ID);
                    lblNombre.Text = producto.nombre.ToString();
                    if(producto.marca.nombre != null) lblMarca.Text = producto.marca.nombre.ToString();
                    if(producto.categoria.nombre != null) lblCategoria.Text = producto.categoria.nombre.ToString();
                    lblDescripcion.Text = producto.descripcion.ToString();
                    lblPrecio.Text = "$" + producto.precio.ToString("0.00");
                    txtCantidad.Text = "1";
                    if(producto.imagenPrincipal != null)ImagenProducto.ImageUrl = producto.imagenPrincipal;
                    if(producto.imagenes.Count > 1) carrusel = true;
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
        protected void BtnAgregarAlCarritoOpcional_Click(object sender, EventArgs e)
        {
            try
            {
                if(!Validacion.esNumeroEntero(txtCantidad))
                {
                    lblCantidad.Text = "Solo se permiten numeros enteros y positivos ⛔";
                    return;
                }
                //averiguar producto
                int ID = int.Parse(Request.QueryString["ID"].ToString());
                LecturaProducto lecturaProducto = new LecturaProducto();
                Producto producto = new Producto();
                producto = lecturaProducto.listar(ID);

                //averiguar cantidad
                int cantidadSolicitada = int.Parse(txtCantidad.Text);

                //Cargarlo en un objeto que pueda albergar ambos datos
                ProductosPedido productoSolicitado = new ProductosPedido();
                productoSolicitado.producto = producto;
                productoSolicitado.cantidad = cantidadSolicitada;

                //agregar el producto al carrito o en todo caso iniciar un nuevo carrito
                List<ProductosPedido> listaCarrito = new List<ProductosPedido>();
                if (Session["Carrito"] != null)
                {
                    listaCarrito = (List<ProductosPedido>)Session["Carrito"];
                    if(listaCarrito.Any(x => x.producto.id == productoSolicitado.producto.id))
                    {
                        incrementarCantidadDelMismoProducto(listaCarrito, productoSolicitado);
                    }
                    else
                    {
                        listaCarrito.Add(productoSolicitado);
                    }
                    Session["Carrito"] = listaCarrito;
                }
                else
                {
                    listaCarrito = new List<ProductosPedido>();
                    listaCarrito.Add(productoSolicitado);
                    Session["Carrito"] = listaCarrito;
                }

                //cambiar contador del master
                Label lblaux = (Label)Master.FindControl("Contador");
                int contador = 0;
                foreach (ProductosPedido productoRequerido in listaCarrito)
                {
                    contador += productoRequerido.cantidad;
                }
                lblaux.Text = contador.ToString();

                //devolver el textbox cantidad a una cantidad decente
                txtCantidad.Text = "1";

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx",false);
            }     
        }

        private void incrementarCantidadDelMismoProducto(List<ProductosPedido> listaCarrito, ProductosPedido productoSolicitado)
        {
            int indice  = listaCarrito.FindIndex(x => x.producto.id == productoSolicitado.producto.id);
            listaCarrito[indice].cantidad += productoSolicitado.cantidad;

        }

        protected void BtnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(Request.QueryString["ID"].ToString());
                LecturaProducto lecturaProducto = new LecturaProducto();
                Producto producto = new Producto();
                producto = lecturaProducto.listar(ID);
                List<Producto> listaCarrito;
                listaCarrito = (List<Producto>)Session["listaArticulosEnCarrito"];
                if (listaCarrito == null)
                {
                    listaCarrito = new List<Producto>();
                }
                for (int i = 0; i < int.Parse(txtCantidad.Text); i++)
                {
                    listaCarrito.Add(producto);
                }
                Label lblaux = (Label)Master.FindControl("Contador");
                lblaux.Text = listaCarrito.Count().ToString();
                Session["listaArticulosEnCarrito"] = listaCarrito;
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
            
        }
    }
}