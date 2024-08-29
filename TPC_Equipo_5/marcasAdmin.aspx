<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="marcasAdmin.aspx.cs" Inherits="TPC_Equipo_5.marcasAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div class="col-md-12">
                <h1 class="text-center">MARCAS</h1>
            </div>
        </div>
        <div class="row" style="padding: 30px 10px; align-items: end;">
            <div class="col-6">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtBuscarMarca" runat="server" CssClass="form-control" placeholder="Buscar por nombre" Style="background-color: #1b1f23; color: white;"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnBusquedaMarca" runat="server" Text="Buscar" CssClass="btn btn-outline-light" OnClick="btnBusquedaMarca_Click" />
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="dropdown text-end">
                    <asp:DropDownList ID="ddlOrdenarMarca" runat="server" OnSelectedIndexChanged="ddlOrdenarMarca_SelectedIndexChanged" AutoPostBack="true"
                        aria-label="Por defecto" CssClass="btn dropdown-menu-end btn-dark"
                        Style="background-color: #1b1f23; width: 30%;">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="dgvMarcas" runat="server" DataKeyNames="ID" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvMarcas_PageIndexChanging">
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
                <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar Marca" CssClass="btn btn-outline-light" OnClick="btnAgregarMarca_Click" />
            </div>
        </div>
    </div>
</asp:Content>
