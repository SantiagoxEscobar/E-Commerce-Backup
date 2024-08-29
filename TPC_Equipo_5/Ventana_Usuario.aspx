<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="~/Ventana_Usuario.aspx.cs" Inherits="TPC_Equipo_5.Ventana_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylePaginaWeb.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%//MODAL BIENVENIDA %>
    <div class="modal fade" id="ModalBienvenida" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Te has logueado exitosamente</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Bienvenido!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade align-content-center" id="RecuperarContraseña" style="border-color: red;" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog ">
            <div class="modal-content " style="background-color: whitesmoke">
                <div class="modal-header">
                    <h5 class="modal-title text-black fs-5">Recuperar contraseña</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body text-black">
                    Ingrese su email para continuar con la recuperacion de tu cuenta!                     
                    <div class="input-group mt-1">
                        <div class="input-group-text " style="background-color: #c32a2a; color: whitesmoke; width: 5.3rem">
                            <label>Email</label>
                        </div>
                        <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Email" />
                        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="Txt_Email" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                            runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnOlvidemipass" runat="server" Text="Enviar email" CssClass="btn btn-danger" OnClick="btnOlvidemipass_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow p-3 mb-5 mt-5 bg-body-tertiary rounded  bg-white p-5 rounded-5 text-secondary" style="width: 25rem; border-color: #c32a2a; height: 30rem;">
            <div class="d-flex justify-content-center">
                <%--hay que cambiar imagen --%>
            </div>
            <div class="text-center fs-1 fw-bold">
                <img style="height: 50px" src="https://i.imgur.com/9E31weS.png" alt="OverCloaked">
                Login
            </div>
            <div class="input-group mt-4">
                <div class="input-group-text " style="background-color: #c32a2a">
                    <img src="/assets/person.svg"
                        alt="usurname-icon"
                        style="height: 1rem;" />
                </div>
                <asp:TextBox ID="TxtUser" CssClass="form-control" type="text" runat="server" placeholder="nombre de usuario"></asp:TextBox>
            </div>
            <div class="input-group mt-1">
                <div class="input-group-text" style="background-color: #c32a2a">
                    <img src="/assets/key.svg"
                        alt="usurname-icon"
                        style="height: 1rem;" />
                </div>
                <asp:TextBox ID="TxtPass" CssClass="form-control" type="password" placeholder="Clave" runat="server"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-around mt-1">
                <div class="nav-item pt-1">
                    <button type="button" class="nav-link " style="color: red;" data-bs-toggle="modal" data-bs-target="#RecuperarContraseña">
                        Forgot your password
                    </button>
                </div>
            </div>
            <div>
                <asp:Button class="btn text-white w-100 mt-4" ID="Btn_loguearse" Style="background-color: #c32a2a" Text="Login" runat="server" OnClick="Btn_login_Click" />

            </div>
            <div class="d-flex gap-1 justify-content-center mt-1">
                <div>No tenes cuenta?</div>
                <a href="RegistroUsuario.aspx" class="text-decoration-none  fw-semibold" style="color: #c32a2a">Crear cuenta</a>
            </div>
        </div>
    </div>
</asp:Content>
