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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        public Producto seleccionado = new Producto();
        public List<Imagen> imagenesForm;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    cargarddl();
                    imagenesForm = new List<Imagen>();
                    Session["ImagenesCargadas"] = imagenesForm;
                }
                else
                {
                    imagenesForm = (List<Imagen>)Session["ImagenesCargadas"];
                }
                dgv_ImgProductos.DataSource = imagenesForm;
                dgv_ImgProductos.DataBind();
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

                LecturaCategoria lecturaCategoria = new LecturaCategoria();
                List<Categoria> listaCategoria = new List<Categoria>();
                listaCategoria = lecturaCategoria.listar(true);

                DDLCategoria.DataSource = listaCategoria;
                DDLCategoria.DataTextField = "Nombre";
                DDLCategoria.DataValueField = "ID";
                DDLCategoria.DataBind();

                LecturaMarca lecturaMarca = new LecturaMarca();
                List<Marca> listaMarca = new List<Marca>();
                listaMarca = lecturaMarca.listar(true);

                DDLMarca.DataSource = listaMarca;
                DDLMarca.DataTextField = "Nombre";
                DDLMarca.DataValueField = "ID";
                DDLMarca.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("productosAdmin.aspx", false);

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {

                Imagen aux = new Imagen();
                aux.imagenUrl = txtImagenUrl.Text;
                imagenesForm.Add(aux);
                Session["ImagenesCargadas"] = imagenesForm;
                txtImagenUrl.Text = string.Empty;
                imgProducto.ImageUrl = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png";
                dgv_ImgProductos.DataSource = imagenesForm;
                dgv_ImgProductos.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtImagenUrl.Text))
                {
                    imgProducto.ImageUrl = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png";
                }
                else
                {
                    imgProducto.ImageUrl = txtImagenUrl.Text;
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.validarTexto(txtNombre.Text))
                {
                    Session["error"] = "el campo nombre no puede estar vacio";
                    Response.Redirect("error.aspx");
                }
                if (Validacion.validarTexto(txtDescripcion.Text))
                {
                    Session["error"] = "el campo Descripcion no puede estar vacio";
                    Response.Redirect("error.aspx");
                }
                if (string.IsNullOrEmpty(txtStock.Text))
                {
                    txtStock.Text = "0";
                }


                seleccionado.categoria.id = int.Parse(DDLCategoria.SelectedItem.Value);
                seleccionado.marca.id = int.Parse(DDLMarca.SelectedItem.Value);
                seleccionado.descripcion = txtDescripcion.Text;
                seleccionado.precio = decimal.Parse(txtPrecio.Text);
                seleccionado.stock = int.Parse(txtStock.Text);

                if (seleccionado.stock < 1) 
                    seleccionado.stock = 0;

                seleccionado.nombre = txtNombre.Text;
                seleccionado.imagenes = (List<Imagen>)Session["ImagenesCargadas"];
                LecturaProducto lecturaProducto = new LecturaProducto();
                lecturaProducto.agregar(seleccionado);
                Response.Redirect("productosAdmin.aspx", false);
            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        protected void dgv_ImgProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TableCell campo = e.Row.Cells[0];
                    string imagenUrl = campo.Text;
                    int maximo_caracteres = 50;
                    if (imagenUrl.Length > maximo_caracteres)
                    {
                        campo.Text = imagenUrl.Substring(0, maximo_caracteres) + "...";
                    }
                    campo.ToolTip = imagenUrl;
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        } //acorta los url para que no se rompa el disenio
        protected void dgv_ImgProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (dgv_ImgProductos.SelectedIndex >= 0)
                {
                    var index = dgv_ImgProductos.SelectedIndex;

                    // Remover el elemento de la lista imagenesForm por su índice
                    if (index < imagenesForm.Count)
                    {
                        imagenesForm.RemoveAt(index);
                    }
                    dgv_ImgProductos.DataSource = null;
                    dgv_ImgProductos.DataSource = imagenesForm;
                    dgv_ImgProductos.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}