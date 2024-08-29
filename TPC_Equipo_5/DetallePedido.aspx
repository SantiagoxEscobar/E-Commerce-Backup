<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TPC_Equipo_5.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center" id="containerPrincipal">
        <div class="card shadow p-3 mb-5 mt-5 bg-body-tertiary rounded  bg-white p-5 rounded-5 text-secondary" style="width: 80rem; border-color: #c32a2a;">
            <div class="card-header">
                <div class="row">
                    <div class="col">
                        <h1>Detalles del Pedido</h1>
                    </div>
                    <div class="col text-end align-content-center">
                        <asp:Label ID="LblNumeroPedido" runat="server" CssClass="h2" Text="N°XXXX"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="card-body" style="min-height: 300px;">
                <div class="row">
                    <h2>Información del Pedido</h2>
                    <div class="table-responsive">
                        <table class="table table-striped table-hover">
                            <tbody>
                                <tr>
                                    <th scope="row">Fecha de Pedido</th>
                                    <td>
                                        <asp:Label ID="LblFechaPedido" runat="server" Text="FechaPedido"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th scope="row">Método de pago</th>
                                    <td>
                                        <asp:Label ID="LblMetodoPago" runat="server" Text="MetodoPago"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th scope="row">Estado</th>
                                    <td>
                                        <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <h2>Productos</h2>
                    <div class="table-responsive">
                        <table class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">Producto</th>
                                    <th scope="col">Marca</th>
                                    <th scope="col">Cantidad</th>
                                    <th scope="col">Precio unitario</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepProductos" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("producto.nombre") %></td>
                                            <td><%# Eval("producto.marca.nombre") %></td>
                                            <td><%# Eval("Cantidad") %></td>
                                            <td>$<%# Eval("producto.precio") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-end">
                        <asp:Label ID="lblTotal" runat="server" CssClass="h2" Text="Total"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="card-footer text-end">
                <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-danger" OnClick="BtnVolver_Click" />
            </div>
        </div>
    </div>
</asp:Content>
