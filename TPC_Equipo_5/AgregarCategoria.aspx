<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/siteAdmin.Master" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPC_Equipo_5.AgregarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 615px">
        <div class="row g-3">
            <div class=" mb-3 col">
                <label class="form-label" for="txtCategoria">* Nombre de la categoria</label>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" type="text" minlength="1" MaxLength="80" required="true" placeholder="Nombre de la categoria"></asp:TextBox>
                </div>
            </div>
        <div class="row">
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnCancelarProducto" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarProducto_Click" formnovalidate="true" />
            </div>
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregarProducto_Click"></asp:Button>
            </div>
        </div>
    <div style="padding: 100px 10px;">
    </div>
        </div>
</asp:Content>