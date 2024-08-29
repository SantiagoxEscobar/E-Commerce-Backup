<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="pedidosAdmin.aspx.cs" Inherits="TPC_Equipo_5.pedidosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div class="col-md-12">
                <h1 class="text-center">LISTA DE PEDIDOS</h1>
            </div>
        </div>
        <div class="row" style="padding: 30px 10px; align-items: end;">
            <div class="col-6">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar por nombre" Style="background-color: #1b1f23; color: white;"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnBusqueda" runat="server" Text="Buscar" CssClass="btn btn-outline-light" OnClick="btnBusqueda_Click" />
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="dropdown text-end">
                    <asp:CheckBox ID="ChkEnProceso" runat="server" Text="Filtrar en proceso" Style="margin-right: 20px;" OnCheckedChanged="ChkEnProceso_CheckedChanged" AutoPostBack="true" />
                    <asp:DropDownList ID="ddlOrdenar" runat="server" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged" AutoPostBack="true"
                        aria-label="Por defecto" CssClass="btn dropdown-menu-end btn-dark"
                        Style="background-color: #1b1f23; width: 30%;">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col">
                    <asp:RadioButtonList ID="rblFiltroBusqueda" runat="server" RepeatColumns="3">
                        <asp:ListItem Text="N° Pedido" style="margin-right: 20px;" />
                        <asp:ListItem Text="Cliente" style="margin-right: 20px;" />
                        <asp:ListItem Text="Fecha" style="margin-right: 20px;" />
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="dgvPedidos" runat="server" DataKeyNames="id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvPedidos_PageIndexChanging" >
                    <Columns>
                        <asp:BoundField HeaderText="N° Pedido" DataField="id" />
                        <asp:BoundField HeaderText="Cliente" DataField="usuario.usuario" />
                        <asp:BoundField HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" DataField="fecha" />
                        <asp:BoundField HeaderText="Método de pago" DataField="metodoPago.nombre" />
                        <asp:BoundField HeaderText="Estado" DataField="estadoPedido.nombre" />
                        <asp:CommandField SelectText="Ver detalles" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
