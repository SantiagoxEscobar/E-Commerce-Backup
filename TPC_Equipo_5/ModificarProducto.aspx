<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/siteAdmin.Master" CodeBehind="ModificarProducto.aspx.cs" Inherits="TPC_Equipo_5.ModificarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" id="containerPrincipal" style="color: white; min-height: 600px">
        <div class="row g-3">
            <div class="col">
                <div>
                    <label class="form-check-label">Activo</label>
                    <br />
                    <asp:CheckBox ID="ckbActivo" runat="server" />
                </div>
                <%--Nombre Requerido--%>
                <label class="form-label">* Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" type="text" MaxLength="80" MinLength="1" required="true" placeholder="Nombre"></asp:TextBox>
                <%--Precio Requerido--%>
                <label class="form-label">* Precio</label>
                <div class="input-group">
                    <span class="input-group-text">$</span>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" min="0" required="true" placeholder="0.00"></asp:TextBox>
                </div>
                <%--Descripcion Opcional--%>
                <label class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="Multiline" CssClass="form-control" Rows="5" type="text" MaxLength="160" MinLength="1" placeholder="Descripcion"></asp:TextBox>
                <%--Stock Opcional o 0--%>
                <label class="form-label">* Stock</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" min="0" type="number" step="1" requerid="true" placeholder="0"></asp:TextBox>
                <%--Categoria Requerido--%>
                <asp:Label ID="Label1" runat="server" Text="* Categoría" CssClass="form-label" />
                <asp:DropDownList ID="DDLCategoria" runat="server" CssClass="form-select" aria-label="Default" required="true"></asp:DropDownList>
                <%--Marca Requerido--%>
                <asp:Label ID="Label2" runat="server" Text="* Marca" CssClass="form-label" />
                <asp:DropDownList ID="DDLMarca" runat="server" CssClass="form-select" aria-label="Default" requerid="true"></asp:DropDownList>
                <%--Imagenes Opcional--%>
            </div>
            <div class="col d-flex flex-wrap">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <label class="form-label">Imagen URL</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" placeholder="URL">
                        </asp:TextBox>
                        <asp:Image ID="imgProducto" runat="server" CssClass="img-thumbnail mt-4"
                            ImageUrl="https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png"
                            AutoPostBack="true" />
                        <div class="mt-2">
                            <asp:Button ID="btnAgregarImagen" Text="Agregar Imagen" runat="server" CssClass="btn btn-success" OnClick="btnAgregarImagen_Click" formnovalidate="true" />
                        </div>

                        <div class="m-lg-2">
                            <div cssclass="row">
                                <asp:GridView ID="dgv_ImgProductos" runat="server" DataKeyNames="ID" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnRowDataBound="achicarLinks" OnSelectedIndexChanged="dgv_ImgProductos_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="Imagenes Cargadas" DataField="imagenUrl" />
                                        <asp:CommandField ShowSelectButton="true" SelectText="Quitar" HeaderText="" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div cssclass="row mt-2">
                                <asp:GridView ID="dgv_nuevasImg" runat="server" DataKeyNames="ID" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" OnRowDataBound="achicarLinks" OnSelectedIndexChanged="dgv_nuevasImg_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nuevas Imagenes" DataField="imagenUrl" />
                                        <asp:CommandField ShowSelectButton="true" SelectText="Quitar" HeaderText="" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
        <div class="row">
            <div class="col m-2 p-lg-4">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" formnovalidate="true" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="btnModificar_Click"></asp:Button>
            </div>
            <%-- <div class="col m-2 p-lg-4">
            </div>--%>


            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="col m-2 p-lg-4">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"></asp:Button>
                    </div>
                    <%if (confirmaEliminacion)
                        { %>
                    <div class="col m-2 p-lg-4">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button ID="BtnConfirmarEliminacion" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="BtnConfirmarEliminacion_Click"></asp:Button>
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>
