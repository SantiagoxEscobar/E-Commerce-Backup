<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="PerfilDetalle.aspx.cs" Inherits="TPC_Equipo_5.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        label {
            color: white;
        }
    </style>
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <asp:Label ID="lblUsuario" runat="server" CssClass="h1 p-2"></asp:Label>
        </div>
        <div class="container" style="background-color: #1b1f23; padding-top: 10px; padding-bottom: 10px; border-radius: 10px; width: 95%;">
            <div class="form-group row p-1 h5">
                <label for="TxtMail" class="col-sm-2 col-form-label">Correo</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TxtMail" ReadOnly="true" Type="mail" CssClass="form-control h5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row p-1 h5">
                <label for="TxtNombre" class="col-sm-2 col-form-label">Nombre</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TxtNombre" ReadOnly="true" runat="server" type="text" class="form-control h5"></asp:TextBox>
                </div>
                <label for="TxtApellido" class="col-sm-2 col-form-label">Apellido</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TxtApellido" ReadOnly="true" type="text" class="form-control h5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row p-1 h5">
                <label for="txtProvincia" class="col-sm-2 col-form-label">Provincia</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtProvincia" ReadOnly="true" Type="text" CssClass="form-control h5" runat="server"></asp:TextBox>
                </div>
                <label for="txtCiudad" class="col-sm-2 col-form-label">Ciudad</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtCiudad" ReadOnly="true" Type="text" CssClass="form-control h5" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="form-group row p-1 h5">
                <label for="TxtTelefono" class="col-sm-2 col-form-label">Telefono</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TxtTelefono" ReadOnly="true" Type="text" CssClass="form-control h5" runat="server"></asp:TextBox>
                </div>
                <label for="TxtDireccion" class="col-sm-2 col-form-label">Direccion</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TxtDireccion" ReadOnly="true" Type="text" CssClass="form-control h5" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row pt-4">
            <asp:GridView ID="dgvPedidos" runat="server" DataKeyNames="id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvPedidos_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="N° Pedido" DataField="id" />
                    <asp:BoundField HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" DataField="fecha" />
                    <asp:BoundField HeaderText="Método de pago" DataField="metodoPago.nombre" />
                    <asp:BoundField HeaderText="Estado" DataField="estadoPedido.nombre" />
                    <asp:CommandField SelectText="Ver detalles" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
