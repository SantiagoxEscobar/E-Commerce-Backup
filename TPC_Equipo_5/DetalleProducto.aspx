<%@ Page Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPC_Equipo_5.DetalleProducto" %>

<%@ MasterType VirtualPath="~/site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal">
        <div class="row" style="height: 600px">
            <div class="col col-lg-2">
                <asp:Button ID="BtnBack" runat="server" Text="Volver" OnClick="Back_Click" formnovalidate="true" CssClass="btn btn-danger btn-sm m-2" />
            </div>
            <div class="col">
                <%if (carrusel)
                    { %>

                <div id="carouselProducto" class="carousel slide">
                    <div class="carousel-inner">
                        <%foreach (Dominio.Productos.Imagen imagen in producto.imagenes)
                            { %>
                        <div class="carousel-item active">
                            <img src="<%=imagen.imagenUrl %>" class="d-block w-100" alt="..." onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'">
                        </div>
                        <%} %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselProducto" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselProducto" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>

                <%}
                    else
                    { %>
                <asp:Image ID="ImagenProducto" runat="server" CssClass="img-fluid" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'" />
                <%} %>
            </div>
            <div class="col">
                <div class="container">
                    <div>
                        <asp:Label ID="lblNombre" runat="server" CssClass="h1"></asp:Label>
                        <br />

                    </div>
                    <div style="margin-top: 15px;">
                        <asp:Label ID="lblPrecio" runat="server" CssClass="h4"></asp:Label>
                    </div>
                    <div>
                        <div class="d-inline-block">
                            <asp:TextBox ID="txtCantidad" runat="server" required="true" Type="number" min="1" max="20" step="1" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-inline-block">
                            <asp:Button ID="BtnAgregarAlCarrito" runat="server" Text="Agregar al Carrito" OnClick="BtnAgregarAlCarritoOpcional_Click" CssClass="btn btn-success m-3" />
                        </div>
                        <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblMarca" runat="server" CssClass="h5"></asp:Label>
                        <asp:Label ID="lblCategoria" runat="server" CssClass="h5"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDescripcion" runat="server" CssClass="p"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
