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
    public partial class ModificarProducto : System.Web.UI.Page
    {
        public Producto seleccionado = new Producto();
        public List<Imagen> imagenesProducto;
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LecturaProducto lecturaProducto = new LecturaProducto();
                int id = int.Parse(Request.QueryString["id"].ToString());
                seleccionado = lecturaProducto.listar(id);
                if (!IsPostBack)
                {
                    Session["NuevasImagenes"] = new List<Imagen>();
                    Session["ImagenesBorrar"] = new List<Imagen>();
                    Session["ListaTemporal"] = new List<Imagen>();
                    cargarddl();
                    buscarIndiceDDLCategoria(seleccionado);
                    buscarIndiceDDLMarca(seleccionado);

                    ckbActivo.Checked = seleccionado.estado;
                    txtNombre.Text = seleccionado.nombre;
                    txtDescripcion.Text = seleccionado.descripcion;
                    txtPrecio.Text = seleccionado.precio.ToString();
                    txtStock.Text = seleccionado.stock.ToString();
                    Session["ListaTemporal"] = seleccionado.imagenes;



                    LecturaImagen lecturaImagen = new LecturaImagen();
                    seleccionado.imagenes = lecturaImagen.listar(seleccionado.id);

                    dgv_ImgProductos.DataSource = (List<Imagen>)Session["ListaTemporal"];
                    dgv_ImgProductos.DataBind();

                    dgv_nuevasImg.DataSource = (List<Imagen>)Session["NuevasImagenes"];
                    dgv_nuevasImg.DataBind();

                    if (seleccionado.imagenes.Count > 0)
                    {
                        seleccionado.imagenPrincipal = seleccionado.imagenes[0].imagenUrl;
                        imgProducto.ImageUrl = seleccionado.imagenPrincipal;
                    }
                }
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
        protected void btnModificar_Click(object sender, EventArgs e)
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
                if(Validacion.esNumeroEntero(txtStock.Text))
                {
                    Session["error"] = "el campo Stock solo permite numeros enteros";
                    Response.Redirect("error.aspx");
                }
                if(Validacion.esNumeroDecimal(txtPrecio.Text))
                {
                    Session["error"] = "el campo Precio solo permite numeros decimales";
                    Response.Redirect("error.aspx");
                }
                if(string.IsNullOrEmpty(txtStock.Text))
                {
                    txtStock.Text = "0";
                }

                seleccionado.estado = ckbActivo.Checked;
                seleccionado.categoria.id = int.Parse(DDLCategoria.SelectedItem.Value);
                seleccionado.marca.id = int.Parse(DDLMarca.SelectedItem.Value);
                seleccionado.descripcion = txtDescripcion.Text;
                seleccionado.precio = decimal.Parse(txtPrecio.Text);
                seleccionado.stock = int.Parse(txtStock.Text);
                if (seleccionado.stock < 1) 
                    seleccionado.stock = 0;
                seleccionado.nombre = txtNombre.Text;

                List<Imagen>ImagenesBorrar = new List<Imagen>();
                List<Imagen>ImagenesNueva = new List<Imagen>();


                ImagenesBorrar = (List<Imagen>)Session["ImagenesBorrar"];
                ImagenesNueva = (List<Imagen>)Session["NuevasImagenes"];

                foreach (Imagen imagen in ImagenesBorrar)
                {
                    LecturaImagen lecturaImagen = new LecturaImagen();
                    lecturaImagen.eliminarFisica(imagen);
                }
                foreach (Imagen imagen in ImagenesNueva)
                {
                    LecturaImagen lecturaImagen2 = new LecturaImagen();
                    lecturaImagen2.agregar(imagen);
                }

                LecturaProducto lecturaProducto = new LecturaProducto();
                lecturaProducto.modificar(seleccionado);
                Response.Redirect("productosAdmin.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
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
                if (Validacion.validarTexto(txtNombre.Text))
                {
                    Session["error"] = "el campo nombre no puede estar vacio";
                    Response.Redirect("error.aspx");
                }
                Imagen aux = new Imagen();
                List<Imagen> nuevasImagenes = new List<Imagen>();
                aux.imagenUrl = txtImagenUrl.Text;
                aux.idProducto = seleccionado.id;
                aux.tipo = 1;

                //La agrega a la lista de pendientes de cargar
                nuevasImagenes = (List<Imagen>)Session["NuevasImagenes"];
                nuevasImagenes.Add(aux);
                Session["NuevasImagenes"] = nuevasImagenes;
            
                txtImagenUrl.Text = string.Empty;
                imgProducto.ImageUrl = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png";

            
                dgv_nuevasImg.DataSource = (List<Imagen>)Session["NuevasImagenes"];
                dgv_nuevasImg.DataBind();
            }
            catch (System.Threading.ThreadAbortException ex) { }
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
        public void buscarIndiceDDLCategoria(Producto seleccionado)
        {
            try
            {
                string id = seleccionado.categoria.id.ToString();
                ListItem listItem = new ListItem();
                listItem = DDLCategoria.Items.FindByValue(id);

                if (listItem != null)
                {
                    DDLCategoria.SelectedIndex = DDLCategoria.Items.IndexOf(listItem);
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        public void buscarIndiceDDLMarca(Producto seleccionado)
        {
            try
            {
                string id = seleccionado.marca.id.ToString();
                ListItem listItem = new ListItem();
                listItem = DDLMarca.Items.FindByValue(id);

                if (listItem != null)
                {
                    DDLMarca.SelectedIndex = DDLMarca.Items.IndexOf(listItem);
                }
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
        protected void achicarLinks(object sender, GridViewRowEventArgs e)
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

                Imagen imagenSeleccionada =  new Imagen();
                List<Imagen> imagenesBorrar = new List<Imagen>();

                int id = int.Parse(dgv_ImgProductos.SelectedDataKey.Value.ToString());
                imagenSeleccionada.id = id;
                //NUEVO
                int index = dgv_ImgProductos.SelectedIndex;
                if (Session["ListaTemporal"] != null)
                {
                    List<Imagen> ImagenesActuales = (List<Imagen>)Session["ListaTemporal"];
                    ImagenesActuales.RemoveAt(index);
                    Session["ListaTemporal"] = ImagenesActuales;
                    dgv_ImgProductos.DataSource = null;
                    dgv_ImgProductos.DataSource = ImagenesActuales;
                    dgv_ImgProductos.DataBind();
                }
                //NUEVO

               imagenesBorrar = (List<Imagen>)Session["ImagenesBorrar"];
                imagenesBorrar.Add(imagenSeleccionada);
                Session["ImagenesBorrar"] = imagenesBorrar;


            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
        //protected void BtnConfirmarEliminacion_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(chkConfirmarEliminacion.Checked)
        //        {
        //            LecturaProducto lecturaProducto = new LecturaProducto();
        //            foreach (var imagen in seleccionado.imagenes)
        //            {
        //                LecturaImagen lecturaImagen = new LecturaImagen();
        //                lecturaImagen.eliminarFisica(imagen);
        //            }
        //            lecturaProducto.eliminarFisica(seleccionado);
        //            Response.Redirect("productosAdmin.aspx", false);
        //        }          
        //    }
        //    catch (Exception ex)
        //    {

        //        Session["error"] = ex.Message;
        //        Response.Redirect("error.aspx", false);
        //    }
        //}
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }
        protected void dgv_nuevasImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                List<Imagen> listaNueva = new List<Imagen>();
                listaNueva = (List<Imagen>)Session["NuevasImagenes"];
                if (dgv_nuevasImg.SelectedIndex >= 0)
                {

                    int index = dgv_nuevasImg.SelectedIndex;


                    // Remover el elemento de la lista imagenesForm por su índice
                    if (index < listaNueva.Count)
                    {
                        listaNueva.RemoveAt(index);
                        Session["NuevasImagenes"] = listaNueva;
                    }
                    dgv_nuevasImg.DataSource = null;
                    dgv_nuevasImg.DataSource = (List<Imagen>)Session["NuevasImagenes"];
                    dgv_nuevasImg.DataBind();
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