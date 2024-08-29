<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="VentanaPerfilUsuario.aspx.cs" Inherits="TPC_Equipo_5.VentanaPerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePerfilUsuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container d-flex justify-content-center" id="containerPrincipal">
        <div class="card shadow p-3 mb-5 mt-5 bg-body-tertiary rounded  bg-white p-5 rounded-5 text-secondary" style="width: 80rem; border-color: #c32a2a;">
            <div class="card-header">
                <div class="row">
                    <div class="col">
                        <h1>Mi Cuenta</h1>
                    </div>
                    <div class="col text-end align-content-center">
                        <asp:Label ID="LblBienvenidaUsuario" runat="server" CssClass="h2" Text="Bienvenido Usuario x"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="card-body" style="min-height: 300px;">
                <div class="d-flex align-items-start">
                    <div class="tab-content col" id="v-pills-tabContent">
                        <div class="align-items-center fade show active" aria-labelledby="v-pills-inicio-tab" tabindex="0">
                            <h2 style="margin-bottom: 20px; text-align: center">Mis pedidos</h2>
                            <% if (listaLecturaPedido != null && listaLecturaPedido.Count() > 0)
                                {%>
                            <asp:GridView ID="dgvPedidosUsuario" runat="server" DataKeyNames="id" CssClass="table table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPedidosUsuario_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="N° Pedido" DataField="id" />
                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Estado" DataField="estadoPedido.nombre" />
                                    <asp:CommandField SelectText="Ver detalles" ShowSelectButton="true" />
                                </Columns>
                            </asp:GridView>
                            <%
                                }
                                else
                                {%>

                            <h4>Todavia no tienes compras hechas para visualizar un pedido.</h4>

                            <%
                                }%>
                            <hr />
                            <h2 style="margin-bottom: 20px; text-align: center">Datos Usuario</h2>
                            <div class="conteiner">
                                <div class="row">
                                    <div class="col">
                                        <h4>Nombres:</h4>
                                    </div>

                                    <div class="col">
                                        <asp:TextBox ID="txtNombres" runat="server" Text="Nombre" CssClass="h4 w-100 text-center "></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="valdatos" ErrorMessage="Formato incorrecto..." ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'.-]+$" ControlToValidate="txtNombres" runat="server" />
                                    </div>

                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                        <h4>Apellidos:</h4>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtApellidos" runat="server" Text="Apellido" CssClass="h4 w-100 text-center "></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="valdatos" ErrorMessage="Formato incorrecto..." ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'.-]+$" ControlToValidate="txtNombres" runat="server" />
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                        <h4>Email:</h4>

                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtEmail" runat="server" Text="Email" CssClass="h4 w-100 text-center" Style="width: stretch"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="valdatos" ErrorMessage="Formato incorrecto..." ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                                            runat="server" />

                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                        <h4>Telefono:</h4>

                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtTelefono" runat="server" Text="Telefono" CssClass="h4 w-100 text-center" Style="width: stretch"></asp:TextBox>
                                        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ValidationExpression="^\+?[\d\s-]+$" ControlToValidate="txtTelefono" runat="server" />

                                    </div>
                                </div>


                                <hr />
                                <div class="row">

                                    <asp:Button type="button" Text="Modificar Mis Datos Personales" runat="server" ID="btnModificardatosPersonales" class="btn btn-dark" Style="margin-top: 10px; width: stretch" OnClick="btnModificardatosPersonales_Click"></asp:Button>
                                </div>
                                <h2 style="margin-top: 20px; text-align: center">Mi Cuenta</h2>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col">
                                        <h4>Usuario:</h4>
                                        <h4>Contraseña:</h4>
                                    </div>
                                    <div class="col">
                                        <div class="row ">
                                            <asp:TextBox ID="txtUsuario" runat="server" Text="Usuario" CssClass="h4 text-center"></asp:TextBox>
                                        </div>
                                        <div class="row">
                                            <asp:TextBox ID="txtPassword" runat="server" Text="******" CssClass="h4 text-center"></asp:TextBox>
                                            <asp:RequiredFieldValidator Style="color: red;" CssClass="validation" ErrorMessage="Campo requerido" ControlToValidate="txtPassword" runat="server" />
                                            <asp:RegularExpressionValidator ValidationGroup="ValCuenta" ErrorMessage="Tu contraseña debe tener almenos 1 Mayuscula, 1 minuscual y 1 numero y almenos 8 caracteres" ControlToValidate="txtPassword" runat="server" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" />
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row">
                                    <asp:Button runat="server" Text="Modificar Mi Cuenta" ID="btnModificarMiCuenta" type="button" class="btn btn-dark" Style="margin-top: 10px; width: stretch" OnClick="btnModificarMiCuenta_Click"></asp:Button>

                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>



                                    <h2 style="margin-bottom: 20px; text-align: center">Mi Dirección</h2>
                                    <div class="row">
                                        <div class="col">
                                            <h4>Dirección:</h4>
                                            <h4>provincia:</h4>
                                            <h4>Ciudad:</h4>
                                        </div>
                                        <div class="col">
                                            <div class="row">
                                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="h4 text-center"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged1" CssClass="btn"></asp:DropDownList>
                                            </div>
                                            <div class="row">
                                                <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="btn"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <hr />
                                    </div>
                                    <div class="row">
                                        <asp:Button runat="server" Text="Modificar Mi Cuenta" ID="BtnModificarMiDireccion" OnClick="BtnModificarMiDireccion_Click1" type="button" class="btn btn-dark" Style="margin-top: 10px"></asp:Button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="card-footer text-end">
                                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#modalCerrarSesion">
                                    Cerrar Sesión
                                </button>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalCerrarSesion" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fs-5">Cerrar Sesión</h5>
                </div>
                <div class="modal-body">
                    ¿Está seguro de que desea cerrar sesión? Se perderá el progreso no guardado.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="btnCerrarSesion_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
