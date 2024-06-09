<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="WebApplication.InicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <%--                <h2 class="text-center mb-4">Inicio de Sesión</h2>--%>
                <form>
                    <div class="form-group">
                        <label for="inputEmail">Correo Electrónico</label>
                        <asp:TextBox ID="inputEmail" runat="server" CssClass="form-control" placeholder="Ingrese su correo electrónico"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="inputPassword">Contraseña</label>
                        <asp:TextBox ID="inputPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
                    </div>
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" class="btn btn-primary" Text="Iniciar Sesion" />
                    </div>
                    <br />
                    <div class="text-center mt-3">
                        <asp:Label ID="lblErrorMail" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                        <asp:Label ID="lblErrorIngreso" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                        <asp:Label ID="lblDatosVacios" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>
                </form>
                <div class="text-center mt-3">
                    <a href="#">¿Olvidó su contraseña?</a>
                </div>
                <div class="text-center mt-3">
                    ¿No tienes una cuenta? <a href="#">Regístrate</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
