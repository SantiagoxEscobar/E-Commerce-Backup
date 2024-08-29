<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="DetallePedidoAdmin.aspx.cs" Inherits="TPC_Equipo_5.DetallePedidoAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div class="col">
                <asp:Label ID="lblNumeroPedido" runat="server" CssClass="h1" Text="XXXX"></asp:Label>
            </div>
            <div class="col text-end align-content-center">
                <%--<asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />--%>
            </div>
        </div>
        <div class="container" style="background-color: #1b1f23; margin: 15px; padding-top: 10px; padding-bottom: 10px; border-radius: 10px;">
            <div class="row">
                <div class="col">
                    <h5>Nombre de usuario:</h5>
                </div>
                <div class="col">
                    <asp:HyperLink ID="lblUsuario" CssClass="h5" runat="server"></asp:HyperLink>    
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Método de pago:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblMetodoPago" runat="server" CssClass="h5" Text="Forma de pago"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Fecha de pedido:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblFecha" runat="server" CssClass="h5" Text="Fecha del pedido"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Estado del pedido:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblEstado" runat="server" CssClass="h5" Text="Estado del pedido"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container" style="background-color: #1b1f23; margin: 15px; padding-top: 10px; padding-bottom: 10px; border-radius: 10px;">
            <div class="row">
                <div class="col">
                    <h5>Nombres:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblNombre" runat="server" CssClass="h5" Text="Nombre del cliente"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Apellidos:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblApellido" runat="server" CssClass="h5" Text="Apellido del cliente"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Email:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblEmail" runat="server" CssClass="h5" Text="Email del cliente"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Teléfono:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblTelefono" runat="server" CssClass="h5" Text="Telefono del cliente"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h5>Dirección:</h5>
                </div>
                <div class="col">
                    <asp:Label ID="lblDireccion" runat="server" CssClass="h5" Text="Direccion del cliente"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <h2>Lista de Productos:</h2>
            </div>
        </div>
        <div class="container" style="background-color: #1b1f23; margin: 15px; padding-top: 10px; padding-bottom: 10px; border-radius: 10px;">
            <div class="row" style="margin-bottom: 20px; padding: 10px 20px;">
                <div class="col-5">
                    <h5>Producto</h5>
                </div>
                <div class="col-2 text-center">
                    <h5>Marca</h5>
                </div>
                <div class="col text-center">
                    <h5>Cantidad</h5>
                </div>
                <div class="col text-end">
                    <h5>Precio unitario</h5>
                </div>
            </div>
            <asp:Repeater ID="RepProductosxPedido" runat="server">
                <ItemTemplate>
                    <div class="row align-items-center" style="padding: 2px 20px;">
                        <div class="col-5">
                            <h6>- <%#Eval("producto.nombre")%></h6>
                        </div>
                        <div class="col-2 text-center">
                            <h6><%#Eval("producto.marca.nombre")%></h6>
                        </div>
                        <div class="col text-center">
                            <h6><%#Eval("Cantidad")%></h6>
                        </div>
                        <div class="col text-end">
                            <h6>$ <%#Eval("producto.precio")%></h6>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row">
            <div class="col text-end">
                <asp:Label ID="lblTotal" runat="server" CssClass="h2" Text="Total"></asp:Label>
            </div>
        </div>
        <%if (estadoPedido < 3)
            {%>
        <div class="container text-start">
            <h5>Modificar estado del pedido</h5>
            <div class="row" style="margin-top: 20px">
                <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalActualizar">Actualizar Pedido </button>
            </div>
            <div class="row" style="margin-top: 10px">
                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#modalCancelar">Cancelar Pedido </button>
            </div>
        </div>
        <%
            }%>
    </div>

    <div class="modal fade" id="modalActualizar" tabindex="-1" aria-labelledby="darkModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-dark">
            <div class="modal-content bg-dark">
                <div class="modal-header">
                    <h5 class="modal-title text-white fs-5">Actualizar Pedido</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body text-white">
                    ¿Está seguro de que desea actualizar el estado del pedido? El estado del pedido se actualizará y el cambio se reflejará para el cliente.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnActualizar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnActualizar_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalCancelar" tabindex="-1" aria-labelledby="darkModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-dark">
            <div class="modal-content bg-dark">
                <div class="modal-header">
                    <h5 class="modal-title text-white fs-5">Cancelar Pedido</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body text-white">
                    ¿Está seguro de que desea cancelar el pedido? Esta acción cancelará permanentemente el pedido y el cliente será notificado.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnCancelar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
