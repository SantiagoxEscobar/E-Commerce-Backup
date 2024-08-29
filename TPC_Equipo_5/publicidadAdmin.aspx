<%@ Page Title="" Language="C#" MasterPageFile="~/siteAdmin.Master" AutoEventWireup="true" CodeBehind="publicidadAdmin.aspx.cs" Inherits="TPC_Equipo_5.publicidadAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row">
            <div>
                <h1 class="text-center">PUBLICIDAD</h1>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <h3>Pantalla Principal (Se recomienda usar un tamaño de 1600 x 580 px)</h3>
            </div>
            <div class="col text-end">
                <asp:Button ID="btnModalAgregar" runat="server" Text="Agregar Publicidad" CssClass="btn btn-success" OnClick="btnModalAgregar_Click" />
            </div>
        </div>
        <div class="row" style="display: flex; justify-content: center;">
            <asp:Repeater ID="RepPublicidad" runat="server">
                <ItemTemplate>
                    <div class="card" style="max-width: 85%; background-color: #1b1f23; margin: 15px; padding-top: 10px; padding-bottom: 10px; border-radius: 10px;">
                        <div class="row">
                            <div class="col-md-7 align-content-center">
                                <asp:Image runat="server" CssClass="img-thumbnail" Style="padding: 0px; border: hidden;" ImageUrl='<%# Eval("imagenUrl") %>' />
                            </div>
                            <div class="col-md-5 text-white">
                                <div class="card-body align-items-end">
                                    <div class="row" style="padding-top: 10px;">
                                        <h6>URL Imagen publicitaria</h6>
                                        <asp:TextBox runat="server" CssClass="form-control h-75" Text='<%# Eval("imagenUrl") %>' ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 20px;">
                                        <asp:Button ID="btnModalCambiar" runat="server" Text="Cambiar" CssClass="btn btn-success" OnClick="btnModalCambiar_Click" CommandArgument='<%# Eval("id") %>' CommandName="IdPublicidad" />
                                    </div>
                                    <div class="row" style="padding-top: 10px;">
                                        <asp:Button ID="btnModalEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnModalEliminar_Click" CommandArgument='<%# Eval("id") %>' CommandName="IdPublicidad" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="modal fade" id="modalAgregar" tabindex="-1" aria-labelledby="darkModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-dark">
                <div class="modal-content bg-dark">
                    <div class="modal-header">
                        <h5 class="modal-title text-white fs-5">¿Está seguro de que desea agregar la imagen?</h5>
                    </div>
                    <div class="modal-body text-white">
                        <div class="row">
                            <asp:TextBox ID="txtAgregarUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAgregarUrl_TextChanged"></asp:TextBox>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <asp:Image ID="imgAgregar" runat="server" CssClass="img-thumbnail" Style="padding: 0px; border: hidden;" />
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <p>La imagen publicitaria se agregara y el cambio se reflejará en la web.</p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-secondary"></asp:Button>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalCambiar" tabindex="-1" aria-labelledby="darkModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-dark">
                <div class="modal-content bg-dark">
                    <div class="modal-header">
                        <h5 class="modal-title text-white fs-5">¿Está seguro de que desea cambiar la imagen?</h5>
                    </div>
                    <div class="modal-body text-white">
                        <div class="row">
                            <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"></asp:TextBox>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <asp:Image ID="imgPublicidad" runat="server" CssClass="img-thumbnail" Style="padding: 0px; border: hidden;" />
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <p>La imagen publicitaria se actualizará y el cambio se reflejará en la web.</p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-secondary"></asp:Button>
                        <asp:Button ID="btnActualizar" runat="server" Text="Cambiar" CssClass="btn btn-success" OnClick="btnActualizar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalEliminar" tabindex="-1" aria-labelledby="darkModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-dark">
                <div class="modal-content bg-dark">
                    <div class="modal-header">
                        <h5 class="modal-title text-white fs-5">¿Está seguro de que desea eliminar la imagen?</h5>
                    </div>
                    <div class="modal-body text-white">
                        Esta acción quitara la imagen publicitaria de la web.
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-secondary"></asp:Button>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
