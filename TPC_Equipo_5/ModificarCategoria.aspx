<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/siteAdmin.Master" CodeBehind="ModificarCategoria.aspx.cs" Inherits="TPC_Equipo_5.ModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 615px">
        <div class="row g-3">
            <div class="">
                <label id="lblCategoria" for="txtCategoria">* Nombre de la categoria</label>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" required="true" placeholder="Nombre de la categoria"></asp:TextBox>
            </div>
            <div class="col ">
                <label class="form-check-label">Activo</label>
                <asp:CheckBox ID="ckbActivo" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" formnovalidate="true"/>
            </div>
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnAgregar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="btnModificar_Click" />
            </div>
           <%-- <div class="col m-2 p-lg-4">
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
            </div>--%>
        </div>
        <div style="padding: 100px 10px;">
        </div>
    </div>
</asp:Content>
