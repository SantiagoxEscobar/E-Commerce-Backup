<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="TPC_Equipo_5.RegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow p-3 mb-5 mt-5 bg-body-tertiary rounded  bg-white p-5 rounded-5 text-secondary" style="width: auto; border-color: #c32a2a; height: auto;">
            <div class="text-center fs-1 fw-bold">
                <img style="height: 50px" src="https://i.imgur.com/9E31weS.png" alt="OverCloaked">
                Crear cuenta
            </div>
            <div class="container">
                <hr />
                <div class="text-center fw-bold mt-3" style="font-size: 0.8rem;">
                    Datos Personales
                </div>
                <div>
                    <div class="input-group mt-2">

                        <div class="input-group-text " style="background-color: #c32a2a; color: whitesmoke">
                            <label>Nombre</label>
                        </div>
                        <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Nombre" />
                        <asp:RequiredFieldValidator Style="color: red;" CssClass="validation" ErrorMessage="Campo requerido" ControlToValidate="Txt_Nombre" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="formato incorrecto" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'.-]+$" ControlToValidate="Txt_Nombre" runat="server" />
                    </div>
                    <div class="input-group mt-1">
                        <div class="input-group-text" style="background-color: #c32a2a; color: whitesmoke">
                            <label>Apellido</label>
                        </div>
                        <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Apellido" />
                        <asp:RequiredFieldValidator Style="color: red;" CssClass="validation" ErrorMessage="Campo requerido" ControlToValidate="Txt_Apellido" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'.-]+$" ControlToValidate="Txt_Apellido" runat="server" />
                    </div>
                </div>
                <hr />
                <div class="input-group mt-1">
                    <div class="input-group-text" style="background-color: #c32a2a; color: whitesmoke; width: 5.3rem">
                        <label>Email</label>
                    </div>
                    <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Email" />
                    <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="Txt_Email" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                        runat="server" />
                </div>
                <div class="input-group mt-4">

                    <div class="input-group-text " style="background-color: #c32a2a; color: whitesmoke; width: 6.5rem">
                        <label>Usuario</label>
                    </div>

                    <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Usuario" />
                    <asp:RequiredFieldValidator Style="color: red;" CssClass="validation" ErrorMessage="Campo requerido" ControlToValidate="Txt_Usuario" runat="server" />
                </div>
                <div class="input-group mt-1">

                    <div class="input-group-text " style="background-color: #c32a2a; color: whitesmoke">
                        <label>Contraseña</label>
                    </div>
                    <asp:TextBox CssClass="form-control" Style="flex: none; width: 40%;" runat="server" ID="Txt_Password" type="password" />
                    <asp:RequiredFieldValidator Style="color: red;" CssClass="validation" ErrorMessage="Campo requerido" ControlToValidate="Txt_Password" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Tu contraseña debe tener al menos: 1 Mayuscula - 1 minuscula - 1 número - 8 caracteres Minimo" ControlToValidate="Txt_Password" runat="server" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" />
                </div>
                <hr />
                <div class="d-flex gap-1 justify-content-center mt-5">
                    <div>
                        <asp:Button ID="Btn_CrearCuenta" Text="Crear Cuenta" CssClass="btn btn-primary" BackColor="#c32a2a" OnClick="Btn_CrearCuenta_Click" runat="server" />
                    </div>
                </div>
                <div class="d-flex gap-1 justify-content-center mt-1">
                    <div>ya tenes cuenta?</div>
                    <a href="Ventana_Usuario.aspx" class="text-decoration-none  fw-semibold" style="color: #c32a2a">Ingresa aca</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
