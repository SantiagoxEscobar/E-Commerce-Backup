using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LecturaDatos;
using Dominio;
using Dominio.Productos;

namespace TPC_Equipo_5
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Producto> listaProductos;
        string busqueda = null;
        public bool listaMostrable;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                LecturaProducto lecturaProducto = new LecturaProducto();
                listaProductos = new List<Producto>();
                listaProductos = lecturaProducto.listar(true);

                busqueda = Request.QueryString["busqueda"];
                if (busqueda != null) filtrarArticulo(busqueda);
                validarListaMostrable();

                if (!IsPostBack)
                {
                    RepeaterProducto.DataSource = listaProductos;
                    RepeaterProducto.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
            
        }
        protected void LinkButton_Click(object sender, EventArgs e)
        {
            string ID = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("DetalleProducto.aspx?ID="+ID, false);
        }

        public void validarListaMostrable()
        {
            int cantidadRegistros = listaProductos.Count();
            listaMostrable = true;
            if (cantidadRegistros < 1)
            {
                listaMostrable = false;
            }
        }
        private void filtrarArticulo(string filtro)
        {
            try
            {

                List<Producto> listaFiltrada;
                listaFiltrada = listaProductos.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper()));
                listaProductos = listaFiltrada;
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}