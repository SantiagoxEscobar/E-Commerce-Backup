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
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Pedido> listaLecturaPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            LecturaUsuario lecturaUsuario = new LecturaUsuario();
            int id = int.Parse(Request.QueryString["id"].ToString());
            Usuario usuario = lecturaUsuario.listar(id);
            cargardatos(id);
            if(!IsPostBack)
            {
                lblUsuario.Text = "Usuario: " + usuario.usuario;
                TxtMail.Text = usuario.dato.email;
                TxtNombre.Text = usuario.dato.nombre;
                TxtApellido.Text = usuario.dato.apellido;
                txtProvincia.Text = usuario.dato.ciudad.provincia.nombre != null ? usuario.dato.ciudad.provincia.nombre : "";
                txtCiudad.Text = usuario.dato.ciudad.nombre != null ? usuario.dato.ciudad.nombre : "";
                TxtTelefono.Text = usuario.dato.telefono;
                TxtDireccion.Text = usuario.dato.direccion;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuariosAdmin.aspx", false);
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        public void cargardatos(int id)
        {
            try
            {
                LecturaPedido lecturaPedido = new LecturaPedido();
                listaLecturaPedido = lecturaPedido.listarxUsuario(id);
                dgvPedidos.DataSource = listaLecturaPedido;
                dgvPedidos.DataBind();
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string seleccionado = dgvPedidos.SelectedDataKey.Value.ToString();
                Response.Redirect("DetallePedidoAdmin.aspx?id=" + seleccionado, false);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("usuariosAdmin.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvPedidos.PageIndex = e.NewPageIndex;
                dgvPedidos.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }
        }
    }
}