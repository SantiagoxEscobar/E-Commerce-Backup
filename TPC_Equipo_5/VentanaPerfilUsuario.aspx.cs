using Dominio.Pedidos;
using Dominio.Usuarios;
using LecturaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public partial class VentanaPerfilUsuario : System.Web.UI.Page
    {
        protected ScriptManager ScriptManager1;

        Provincia provincia;
        List<Provincia> ListaProvincias;
        LecturaProvincia lecturaProvincias;

        Usuario usuariologeado;

        public List<Pedido> listaLecturaPedido;
        Usuario listaLecturaUsuario = new Usuario();
        DatosUsuario listaLecturaDatosUsuario = new DatosUsuario();
        LecturaProvincia lecturaProvincia = new LecturaProvincia();
        LecturaCiudad lecturaCiudad = new LecturaCiudad();
        int idUsuario = 0;
        int idDatosPersonales = 0;
        string seleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((Usuario)Session["usuario"] != null)
                    {
                        if (((Usuario)Session["usuario"]).dato.ciudad.id == -1)
                        {
                            ddlCargar();
                        }
                        else
                        {
                            ddlCargar();
                            lecturaProvincia = new LecturaProvincia();
                            ddlProvincia.SelectedIndex = lecturaProvincia.listarlistarporidciudad(((Usuario)Session["usuario"]).dato.ciudad.id) - 1;

                            ddlCiudad.SelectedIndex = ((Usuario)Session["usuario"]).dato.ciudad.id - 1;
                            ddlProvincia.DataBind();
                            ddlCiudad.DataBind();
                        }
                        idUsuario = ((Usuario)Session["usuario"]).id;
                        idDatosPersonales = ((Usuario)Session["usuario"]).dato.id;
                        cargarDatos();
                        LblBienvenidaUsuario.Text = "Bienvenido " + listaLecturaDatosUsuario.nombre + " " + listaLecturaDatosUsuario.apellido;

                        LecturaPedido lecturaPedido = new LecturaPedido();
                        listaLecturaPedido = lecturaPedido.listarxUsuario(idUsuario);
                        dgvPedidosUsuario.DataSource = listaLecturaPedido;
                        dgvPedidosUsuario.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvPedidosUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seleccionado = dgvPedidosUsuario.SelectedDataKey.Value.ToString();
                Response.Redirect("DetallePedido.aspx?id=" + seleccionado, false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }


        protected void cargarDatos()
        {
            LecturaUsuario lecturaUsuario = new LecturaUsuario();
            listaLecturaUsuario = lecturaUsuario.listar(idUsuario);
            LecturaDatosUsuario lecturaDatosUsuario = new LecturaDatosUsuario();
            listaLecturaDatosUsuario = lecturaDatosUsuario.listar(idDatosPersonales);

            txtNombres.Text = listaLecturaDatosUsuario.nombre.ToString();
            txtApellidos.Text = listaLecturaDatosUsuario.apellido;
            txtEmail.Text = listaLecturaDatosUsuario.email;
            txtTelefono.Text = listaLecturaDatosUsuario.telefono;

            txtUsuario.Text = listaLecturaUsuario.usuario;
            txtPassword.Text = listaLecturaUsuario.password;

            txtDireccion.Text = listaLecturaDatosUsuario.direccion;


        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("error", false);
            }

        }


        protected void ddlCargar()
        {

            lecturaProvincias = new LecturaProvincia();
            List<Provincia> listaprovincia = lecturaProvincias.listar();
            LecturaCiudad lecturaciudad = new LecturaCiudad();
            List<Ciudad> listaciudad = lecturaciudad.listar();


            ddlProvincia.DataSource = listaprovincia;
            ddlProvincia.DataValueField = "ID";
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataBind();

            ddlCiudad.DataSource = listaciudad;
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataBind();
        }





        protected void btnModificardatosPersonales_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if(!Page.IsValid) { return; }              
                DatosUsuario datosUsuario = new DatosUsuario();

                datosUsuario.id = ((Usuario)Session["usuario"]).id;
                datosUsuario.nombre = txtNombres.Text;
                datosUsuario.apellido = txtApellidos.Text;
                datosUsuario.email = txtEmail.Text;
                datosUsuario.telefono = txtTelefono.Text;

                LecturaDatosUsuario lecturaDatosUsuario = new LecturaDatosUsuario();
                lecturaDatosUsuario.modificarDatos(datosUsuario);

                Response.Redirect("VentanaPerfilusuario.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnModificarMiCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid){return;}
                                
                    Usuario usuario = new Usuario();

                    usuario.id = ((Usuario)Session["usuario"]).id;
                    usuario.usuario = txtUsuario.Text;
                    usuario.password = txtPassword.Text;

                    LecturaUsuario lecturaUsuario = new LecturaUsuario();
                    lecturaUsuario.modificarDatos(usuario);

                    Response.Redirect("VentanaPerfilusuario.aspx", false);
               
                
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LecturaCiudad lecturaciudad = new LecturaCiudad();
            List<Ciudad> listaciudad = new List<Ciudad>();
            int id = int.Parse(ddlProvincia.SelectedItem.Value);
            listaciudad = lecturaciudad.listarPorProvincia(id);
            ddlCiudad.DataSource = listaciudad;
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataBind();

        }

        protected void BtnModificarMiDireccion_Click1(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) { return; }
                DatosUsuario datosUsuario = new DatosUsuario();

                datosUsuario.id = ((Usuario)Session["usuario"]).id;
                datosUsuario.direccion = txtDireccion.Text;
                datosUsuario.ciudad.nombre = ddlCiudad.Text;
                datosUsuario.ciudad.provincia.id = int.Parse(ddlProvincia.Text);


                LecturaDatosUsuario lecturaDatosUsuario = new LecturaDatosUsuario();
                lecturaDatosUsuario.modificarDireccion(datosUsuario);
                              
                usuariologeado = (Usuario)Session["usuario"];
                usuariologeado.dato.direccion = datosUsuario.direccion;
                usuariologeado.dato.ciudad.id = datosUsuario.ciudad.id;
                Session.Add("usuario", usuariologeado);

                Response.Redirect("VentanaPerfilusuario.aspx", false);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}