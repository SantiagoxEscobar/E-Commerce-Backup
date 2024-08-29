<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Equipo_5.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container cuerpo" id="containerPrincipal">

        <%if (listaProductos.Count() < 1)
          { %>

            <div style="height:600px">
                <hr />
                <h1>parece que no obtuvimos productos para mostrarte 🤕 🤕 🤕</h1>
                <hr />
                <h4>prueba con otra busqueda</h4>
            </div>
        <%} %>
        <%if (listaProductos.Count < 4)
            { %>
            <div class="row row-cols-1 row-cols-md-3 g-1 d-flex justify-content-center p-3"  style="height: 600px">
        <%}
            else
            {%>
                <div class="row row-cols-1 row-cols-md-3 g-1 d-flex justify-content-center p-3">
          <%} %>
        
        <asp:Repeater ID="RepeaterProducto" runat="server">
            <ItemTemplate>
                <div class="col d-flex justify-content-center">
                    <div class="card shadow p-3 mb-5 mt-5 bg-body-tertiary rounded" style="width: 18rem;">

                        <img src="<%#Eval("imagenPrincipal") %>" class="w-100 h-70 object-fit-cover" alt="..." onerror="this.src='https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png'">
                        <div class="card-body" style="position: relative;">
                            <asp:LinkButton ID="LinkButton" runat="server" CssClass="text-decoration-none" CommandArgument='<%#Eval("ID") %>' CommandName="IDProducto" OnClick="LinkButton_Click"> 
                        <h5 class="card-title m-2 text-center fw-bolder"><%#Eval("nombre") %></h5>
                            </asp:LinkButton>
                            <h5 class="card-subtitle m-1 p-0 text-body-secondary text-end" style="position: absolute; bottom: 0; right: 0; margin-bottom: 0.5rem;">$<%#Eval("precio") %></h5>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </div>
</asp:Content>
