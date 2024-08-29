<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/siteAdmin.Master" CodeBehind="AgregarMarca.aspx.cs" Inherits="TPC_Equipo_5.AgregarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 615px">
        <div class="row g-3">
            <div class=" mb-3 col">
                <label id="lblMarca" for="txtNombre" class="form-label">* Nombre de la marca</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" minlength="1" MaxLength="80" required="true" placeholder="Nombre de la marca"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" formnovalidate="true" />
            </div>
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click"></asp:Button>
            </div>
        </div>
    </div>
</asp:Content>
