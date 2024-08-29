 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Pedidos;
using Dominio.Productos;
using Dominio.Usuarios;
using LecturaDatos;

namespace TPC_Equipo_5
{
    public partial class site : System.Web.UI.MasterPage
    {
        int cantidad;
        string busqueda;
        List<ProductosPedido> listaDeCompras;
        public bool BotonAdmin { get; set; }
        public string cantidadItems
        {
            get { return cantidadItems; }
            set { Contador.Text = value; }
        }

        protected bool ValidarTextBox(string busqueda)
        {
            if (string.IsNullOrEmpty(busqueda)) { return false; }
            else { return true; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Ventana_Usuario || Page is _default || Page is Productos || Page is DetalleProducto || Page is VentanaCarrito || Page is RegistroUsuario || Page is Error))
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Ventana_Usuario.aspx", false);
                }

            }
            if(Seguridad.esAdmin(Session["usuario"]))
            {
                BotonAdmin = true;
            }
            if (Session["Carrito"] == null)
            {
                Contador.Text = "";
            }
            else
            {
                listaDeCompras = (List<ProductosPedido>)Session["Carrito"];
                int acumulador = 0;
                foreach (var item in listaDeCompras)
                {
                    acumulador += item.cantidad;
                }
                Contador.Text = acumulador.ToString();
            }

            if(!Seguridad.sesionActiva(Session["usuario"]))
            {
                HyperLink1.NavigateUrl = "VentanaPerfilUsuario.aspx";
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                lblUsuario.Text = usuario.dato.nombre;
            }
            else
            {
                HyperLink1.NavigateUrl = "Ventana_Usuario.aspx";
            }
        }

        protected void imgBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            busqueda = txtBusqueda.Text;
            if (ValidarTextBox(busqueda))
            {
                //caso en el que tiene que iniciar la busqueda
                Response.Redirect("Productos.aspx?busqueda=" + busqueda, false);
            }
            else
            {
                //caso en el que tiene que mostrar todo
                Response.Redirect("Productos.aspx", false);
            }
        }

        protected void btnSuscribite_Click(object sender, EventArgs e)
        {

        }
    }
}