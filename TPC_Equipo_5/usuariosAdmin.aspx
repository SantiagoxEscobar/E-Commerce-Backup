<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="usuariosAdmin.aspx.cs" Inherits="TPC_Equipo_5.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div class="col-12">
                <h1 class="text-center">LISTA DE USUARIOS</h1>
            </div>
        </div>
        <div class="row" style="padding: 30px 10px;">
            <asp:GridView ID="dgv_usuarios" DataKeyNames="id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" runat="server" OnPageIndexChanging="dgv_usuarios_PageIndexChanging" OnSelectedIndexChanged="dgv_usuarios_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id" />
                    <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <%# Eval("dato.nombre") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <%# Eval("dato.apellido") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField HeaderText="Admin" DataField="admin" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver Usuario" HeaderText="Detalle" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
