using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LecturaDatos;
using Dominio;
using Dominio.Usuarios;
using Dominio.Productos;
using System.Web.Routing;
using System.Runtime.InteropServices.WindowsRuntime;
using Dominio.Pedidos;

namespace TPC_Equipo_5
{
    public partial class VentanaCompra : System.Web.UI.Page
    {
        public Pedido pedido;
        public LecturaPedido lecturaPedido;

        public List<ProductosPedido> productosPedido;

        public Usuario usuario;
        public int Pagina = 1;

        public ServiceEmail email;
        bool Transferenciabool = false;

        public LecturaDatosUsuario LecturaDatosUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["pag"] == null)
                {
                    Pagina = 1;
                    Session.Add("pag", Pagina);
                }
                else
                { 
                    Pagina = (int)Session["pag"]; 
                }

                if (!IsPostBack)
                {
                    Pagina = 1;
                    Session.Add("pag", Pagina);
                    
                    if (Session["usuario"]!=null)
                    {
                        usuario = (Usuario)Session["usuario"];
                        Txt_Email.Text = usuario.dato.email;
                        Txt_Calle_R.Text = usuario.dato.direccion;
                    }

                    if (Session["Carrito"] != null)
                    {
                        productosPedido = (List<ProductosPedido>)Session["Carrito"];
                    }

                    repCarrito.DataSource = productosPedido;
                    repCarrito.DataBind();

                    decimal totalCarrito = CalcularTotal(productosPedido);
                    lblTotalCompra.Text = "Total: $" + (totalCarrito).ToString("0.00");
                    
                    Txt_Calle_R.Enabled = false;
                    Txt_Email.Enabled = false;


                }

            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message;
                Response.Redirect("error.aspx", false);
            }

        }
        private decimal CalcularTotal(List<Producto> productos)
        {
            decimal total = 0;

            foreach (var producto in productos)
            {
                total += (decimal)producto.precio;
            }

            return total; ;
        }
        protected void btnconfirmarOpcional_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["transferencia"] != null)
                {
                    pedido = new Pedido();
                    lecturaPedido = new LecturaPedido();
                    productosPedido = (List<ProductosPedido>)Session["Carrito"];

                    pedido.usuario = (Usuario)Session["usuario"];

                    Transferenciabool = (bool)Session["transferencia"];

                    if (Transferenciabool == true)
                        pedido.metodoPago.id = 1;
                    else
                        pedido.metodoPago.id = 2;

                    lecturaPedido.agregar(pedido);

                    pedido = lecturaPedido.listar().Last();
                    pedido.usuario = (Usuario)Session["usuario"];

                    //Agregar Cada Producto y su cantidad a la base de datos
                    foreach (ProductosPedido ProductoPedido in productosPedido)
                    {
                        ProductoPedido.pedido.id = pedido.id;
                        LecturaProductosPedido lecturaProductosPedido = new LecturaProductosPedido();
                        lecturaProductosPedido.agregar(ProductoPedido);
                    }

                    Session["Carrito"] = null;

                    //envio de mail
                    email = new ServiceEmail();
                    string correodestino = pedido.usuario.dato.email;
                    string asunto = "OverCloacked: Tu compra ha sido Exitosa";
                    string cuerpo = "Tu compra fue realizada con exito! pronto nos pondremos en contacto";
                    email.armarcorreo(correodestino, asunto, cuerpo);
                    email.enviarEmail();

                    Response.Redirect("default.aspx", false);
                    Session["listaArticulosEnCarrito"] = null;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx",false);
            }

        }
        //protected void btnconfirmar_Click(object sender, EventArgs e)
        //{
        //    if (Session["transferencia"] != null)
        //    {
        //        pedido = new Pedido();
        //        lecturaPedido = new LecturaPedido();
        //        productosPedido = new List<ProductosPedido>();
        //        List<Producto> listaProductos = new List<Producto>();
        //        listaProductos = (List<Producto>)Session["listaArticulosEnCarrito"];

        //        pedido.usuario = (Usuario)Session["usuario"];
        //        if (Transferencia.Checked)
        //            pedido.metodoPago.id = 3;
        //        else
        //            pedido.metodoPago.id = 4;

        //        lecturaPedido.agregar(pedido);
        //        pedido = lecturaPedido.listar().Last();

        //        //Pasar del carrito a una lista sin objetos repetidos
        //        List<Producto> listaProductosDistinct = listaProductos.Distinct().ToList();

        //        foreach (Producto producto in listaProductosDistinct)
        //        {
        //            ProductosPedido aux = new ProductosPedido();
        //            aux.producto = producto;
        //            productosPedido.Add(aux);

        //        }
        //        //Contar cuanta cantidad habia sido requerida en la lista original
        //        foreach (ProductosPedido ProductoPedido in productosPedido)
        //        {
        //            ProductoPedido.cantidad = listaProductos.FindAll(x => x == ProductoPedido.producto).Count();
        //            ProductoPedido.pedido.id = pedido.id;
        //        }
        //        //Agregar Cada Producto y su cantidad a la base de datos
        //        foreach (ProductosPedido ProductoPedido in productosPedido)
        //        {
        //            LecturaProductosPedido lecturaProductosPedido = new LecturaProductosPedido();
        //            lecturaProductosPedido.agregar(ProductoPedido);
        //        }

        //        //envio de mail
        //        email = new ServiceEmail();
        //        string correodestino = "gemasaxlrose@gmail.com";
        //        string asunto = "OverCloacked: Tu compra ha sido Exitosa";
        //        string cuerpo = "Tu compra fue realizada con exito! pronto nos pondremos en contacto";
        //        email.armarcorreo(correodestino, asunto, cuerpo);
        //        email.enviarEmail();

        //        Response.Redirect("default.aspx", false);
        //        Session["listaArticulosEnCarrito"] = null;
        //    }
        //    else
        //    {

        //    }

        //}
        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            ////Terminar 
            //if (FileUpload1.HasFile)
            //{
            //    //string ext = System.IO.Path.GetExtension(FileUpload1.FileName);

            //    //int tam = FileUpload1.PostedFile.ContentLength;
            //    //Response.Write(ext + ", " + tam);
            //    //if (ext == ".png" && tam <= 1048576)
            //    //{
            //    //    FileUpload1.SaveAs(Server.MapPath("D:\\COSAS MARIANO\\UNI\\UNI\\Prog 3\\TPC\\TPC_Equipo_5\\BD\\Comprobantes" + FileUpload1.FileName));
            //    //    Response.Write("Se subio el archivo");
            //    //}
            //}
            //else
            //{
            //    Response.Write("Selleciona un archivo a subir");
            //}
        }
        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (Pagina < 3)
            {
                if (string.IsNullOrEmpty(Txt_Calle_R.Text) || Txt_Calle_R.Text == "Debo ser completado")
                {
                    Txt_Calle_R.Text = "Debo ser completado  ⛔";
                    LinkPerfil.Visible = true;
                    LinkPerfil.Text = "Click aqui para modificar mis datos";
                    LinkPerfil.NavigateUrl = "VentanaPerfilUsuario.aspx";
                    return;
                }      
                if(Pagina == 2 && !(Transferencia.Checked) && !(Mp.Checked))
                {
                        lblValidarMetodoPago.Text = "Definir un metodo de pago es requisito obligatorio para continuar ⛔";
                        return ;

                }

                Pagina++;
                Session.Add("pag", Pagina);

            }
        }
        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            if (Pagina > 1 && Pagina < 4)
            {
                Pagina--;
                Session.Add("pag", Pagina);
            }
        }
        protected void Transferencia_CheckedChanged(object sender, EventArgs e)
        {
            if(Transferencia.Checked) 
            { 
                Transferenciabool = true;
                Session.Add("transferencia", Transferenciabool);
            }
            else {
                Transferenciabool = false;
                Session.Add("transferencia", Transferenciabool);
            }
        }
        private decimal CalcularTotal(List<ProductosPedido> productos)
        {
            decimal total = 0;

            foreach (var producto in productos)
            {
                total += (decimal)producto.producto.precio * producto.cantidad;
            }

            return total;
        }
    }
}

