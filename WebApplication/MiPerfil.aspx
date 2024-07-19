<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="WebApplication.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <h2 class="text-center">Mi perfil</h2>
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Usuario</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" />
                </div>
                <div class="mb-3">
                    <label type="password" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellidos</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidos" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombres</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombres" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
                </div>
            </div>

            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
                    runat="server" CssClass="img-fluid mb-3" Width="350" />
            </div>

            <div class="col-md-8">
                <div class="row justify-content-center">
                    <div class="col-md-4">
                        <asp:Button Text="Guardar" CssClass="btn btn-danger btn-lg me-2" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                        <a href="Inicio.aspx" class="btn btn-success" >Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
