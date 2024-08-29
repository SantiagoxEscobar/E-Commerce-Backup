<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="categoriasAdmin.aspx.cs" Inherits="TPC_Equipo_5.categoriasAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div class="col-md-12">
                <h1 class="text-center">CATEGORÍAS</h1>
            </div>
        </div>
        <div class="row" style="padding: 30px 10px; align-items: end;">
            <div class="col-6">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtBuscarCategoria" runat="server" CssClass="form-control" placeholder="Buscar por nombre" Style="background-color: #1b1f23; color: white;"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnBusquedaCategoria" runat="server" Text="Buscar" CssClass="btn btn-outline-light" OnClick="btnBusquedaCategoria_Click" />
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="dropdown text-end">
                    <asp:DropDownList ID="ddlOrdenarCategoria" runat="server" OnSelectedIndexChanged="ddlOrdenarCategoria_SelectedIndexChanged" AutoPostBack="true"
                        aria-label="Por defecto" CssClass="btn dropdown-menu-end btn-dark"
                        Style="background-color: #1b1f23; width: 30%;">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvCategorias" runat="server" DataKeyNames="ID" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvCategorias_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="id" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:CheckBoxField HeaderText="Estado" DataField="estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Detalle" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row" style="padding: 20px 10px;">
            <div class="col text-end">
                <asp:Button ID="btnAgregarCategoría" runat="server" Text="Agregar Categoría" CssClass="btn btn-outline-light" OnClick="btnAgregarCategoría_Click" />
            </div>
        </div>
    </div>
</asp:Content>
