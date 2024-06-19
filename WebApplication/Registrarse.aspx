<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSinNav.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="WebApplication.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <h2 class="text-center mb-4" style="color: red;">Crea tu cuenta</h2>
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
                    <br />
                    <div class="d-flex justify-content-center">
                        <asp:Button ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click1" class="btn btn-danger me-2" Text="Registrarse" />
                        <%--                        <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" class="btn btn-danger btn-lg me-2" Text="Iniciar Sesion" />--%>
                        <%--                        <asp:Button ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click" class="btn btn-danger me-2" Text="Registrarse" />--%>
                        <a href="Inicio.aspx" style="color: red; display: inline-block; padding: 10px 20px; font-size: 16px; text-align: center; text-decoration: none; background-color: #f8f9fa; border: 1px solid red; border-radius: 5px;">Cancelar</a>
                    </div>
                    <br />
                    <div class="text-center mt-3">
                        <asp:Label ID="lblErrorMail" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                        <asp:Label ID="lblErrorIngreso" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                        <asp:Label ID="lblDatosVacios" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
