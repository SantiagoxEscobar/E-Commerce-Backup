<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="productosAdmin.aspx.cs" Inherits="TPC_Equipo_5.productosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="row">
            <div class="col-12">
                <h1 class="text-center">LISTA DE PRODUCTOS</h1>
            </div>
        </div>
        <div class="form-check">
            <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro Avanzado"></asp:Label>
            <asp:CheckBox ID="chk_FiltroAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chk_FiltroAvanzado_CheckedChanged" />
        </div>
        <%if (filtroAvanzado)
            {  %>
        <div class="row" style="padding: 30px 10px; align-items: end;">
            <div class="col-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList ID="ddl_campo" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_campo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Producto" />
                    <asp:ListItem Text="Descripcion" />
                    <asp:ListItem Text="Precio"/>
                    <asp:ListItem Text="Stock" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
                <asp:Label ID="lblAvisoCampo" runat="server" Text="" CssClass="form-label"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="lblCriterio" runat="server" Text="Criterio"></asp:Label>
                <asp:DropDownList ID="ddl_criterio" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:Label ID="lblAvisoCriterio" runat="server" Text="" CssClass="form-label"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="lblAvisoFiltro" runat="server" Text="" CssClass="form-label"></asp:Label>
                <asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddl_estado" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:Label ID="lblAvisoEstado" runat="server" Text="" CssClass="form-label"></asp:Label>
            </div>

        </div>
        <div class="row mx-auto p-2">
            <asp:Button ID="btnAccionarFiltroAvanzado" runat="server" Text="Filtrar" CssClass="btn btn-outline-light" OnClick="btnAccionarFiltroAvanzado_Click" />
        </div>
        <%} %>
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
                    <asp:DropDownList ID="ddlOrdenar" runat="server" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged" AutoPostBack="true"
                        aria-label="Por defecto" CssClass="btn dropdown-menu-end btn-dark"
                        Style="background-color: #1b1f23; width: 30%;">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">

                <asp:GridView ID="dgvProductos" DataKeyNames="id" runat="server" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvProductos_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="id" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="Precio" DataFormatString="$ {0:N2}" DataField="precio" />
                        <asp:BoundField HeaderText="Stock" DataField="stock" />
                        <asp:TemplateField HeaderText="Marca">
                            <ItemTemplate>
                                <%# Eval("marca.nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Categoria">
                            <ItemTemplate>
                                <%# Eval("categoria.nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField HeaderText="Activo" DataField="estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Detalle"/>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row" style="padding: 20px 10px;">
            <div class="col text-end">
                <asp:Button ID="btnAgregarProducto" type="button" runat="server" Text="Agregar Producto" class="btn btn-outline-light" OnClick="btnAgregarProducto_Click" />
            </div>
        </div>

    </div>


</asp:Content>
