using Dominio.Productos;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class _default : System.Web.UI.Page
    {
        public List<Producto> listaProductos;
        public List<Imagen> listaImagenes;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //Carga los primeros 3 productos de db
                LecturaProducto lecturaProducto = new LecturaProducto();
                listaProductos = new List<Producto>();
                listaProductos = lecturaProducto.listar(true);
                RepeaterProducto.DataSource = listaProductos.Take(3);
                RepeaterProducto.DataBind();

                LecturaImagen lecturaImagen = new LecturaImagen();
                listaImagenes = new List<Imagen>();
                listaImagenes = lecturaImagen.listarPublicidad();
                cargarCarrusel();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }

        }
        protected void LinkButton_Click(object sender, EventArgs e)
        {
            try
            {

                string ID = ((LinkButton)sender).CommandArgument.ToString();
                Response.Redirect("DetalleProducto.aspx?ID=" + ID, false);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void cargarCarrusel()
        {
            try
            {
                StringBuilder indicadorHtml = new StringBuilder();
                StringBuilder innerHtml = new StringBuilder();

                for (int i = 0; i < listaImagenes.Count; i++)
                {
                    string activo = i == 0 ? "active" : "";

                    indicadorHtml.Append($@"
                    <button type=""button"" data-bs-target=""#carouselPublicitario"" data-bs-slide-to=""{i}"" class=""{activo}"" aria-current=""{activo}"" aria-label=""Diapositiva {i + 1}"">
                    </button>");

                    innerHtml.Append($@"
                    <div class=""carousel-item {activo}"">
                        <img src=""{listaImagenes[i].imagenUrl}"" class=""d-block w-100"" alt=""{listaImagenes[i].id}"">
                    </div>");
                }

                indicatorsCarrusel.Text = indicadorHtml.ToString();
                innerCarrusel.Text = innerHtml.ToString();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}