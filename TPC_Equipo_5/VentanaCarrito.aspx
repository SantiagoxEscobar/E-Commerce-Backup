<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="VentanaCarrito.aspx.cs" Inherits="TPC_Equipo_5.VentanaCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%  if ((listaProductosPedidos != null && listaProductosPedidos.Count() != 0) && repCarrito.DataSource != null)
        { %>
    <div class="container" id="containerPrincipal">
        <div class="row">
            <asp:Repeater runat="server" ID="repCarrito">
                <ItemTemplate>
                    <div>
                        <div class="container">
                            <div class="row">
                                <div class="col-4">
                                    <img src="<%#Eval("producto.imagenPrincipal")%>" class="card-img-top" alt="Image description" onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'">
                                </div>
                                <div class="col text-start p-md-5">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col">
                                                <div>
                                                    <label>Articulo: <%#Eval("producto.nombre")%> </label>
                                                </div>
                                                <div>
                                                    <label>Descripcion: <%#Eval("producto.descripcion")%> </label>

                                                </div>
                                                <div>
                                                    <label>Precio: $ <%#Eval("producto.precio")%> </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-6">
                                                <div class="d-inline-block">
                                                    <asp:TextBox Enabled="false" CssClass="form-control no-keyboard" ID="txtCantidad" runat="server" type="number" step="1" Min="1" Text='<%# Eval("cantidad").ToString() %>'></asp:TextBox>
                                                </div>
                                                <div class="d-inline-block" style="margin-top: 15px;">
                                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarOpcional_Click" CommandArgument='<%# Eval("producto.id") %>' CommandName="IdArticulo" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="container text-end">
                                        <div class="row">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="width: 90%; margin-inline: 10%;" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <div class="text-start">
            <div class="container" id="containerResumenCompra">
                <div class="row">
                    <div class="col">
                        <h4>Resumen del pedido</h4>
                        <div>
                            <asp:Label ID="lblTotalCompra" runat="server" Text="Total: $xxxx" CssClass="h4" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnComprar" runat="server" Text="Comprar" CssClass="btn  w-75" OnClick="btnComprar_Click" Style="background-color: black; color: white;"></asp:Button>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnContinuarComprando" runat="server" Text="Continuar comprando" CssClass="btn  w-75" OnClick="btnContinuarComprando_Click" Style="background-color: #c02a2a; color: white;" />
                    </div>
                </div>
            </div>
        </div>


        <%   }
            else
            { %>
        <div class="container" id="containerCarritoVacio" style="height: 600px">
            <div class="row">
                <div class="col">
                    <hr />
                    <h1>Carrito vacio</h1>
                    <hr />
                    <h4>No hay productos en el carrito de momento, no te quedes con las ganas! 😁 😁 😁</h4>
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <div class="container text-end">
                                    <div class="row">
                                        <div class="col">
                                            <asp:Button ID="Button2" runat="server" Text="Continuar comprando" CssClass="btn btn-primary" OnClick="btnContinuarComprando_Click" Style="background-color: #c02a2a;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <% }
        %>
    </div>
</asp:Content>
