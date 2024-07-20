<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="WebApplication.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerDP" runat="server" />
    <div class="container py-4">
        <asp:UpdatePanel ID="UpdatePanelDP" runat="server">
        <ContentTemplate>
        <div class="row">
            <div class="col-md-6 text-center">
                <img src="<%: ArticuloDetalle.ImagenUrl %>" class="imagen-detalle img-fluid rounded shadow-sm" alt="Imagen del producto" onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
            </div>
            <div class="col-md-6 d-flex flex-column justify-content-center">
                <h1 class="fs-1 text-primary fw-bold mb-3 mt-4"><%: ArticuloDetalle.Nombre %></h1>
                <p class="fs-4 text-muted mb-3"><strong>Descripción:</strong> <%: ArticuloDetalle.Descripcion %></p>
                <p class="fs-4 text-muted mb-3"><strong>Marca:</strong> <%: ArticuloDetalle.Marca %></p>
                <p class="fs-4 text-success mb-4"><strong>Precio:</strong> $<%: String.Format("{0:N}", ArticuloDetalle.Precio) %></p>
                <asp:Button Text="Añadir al carrito" CssClass="btn btn-success btn-lg mb-3" runat="server" ID="AgregarCarrito" CommandArgument='<%: ArticuloDetalle.IdArticulo%>' CommandName="IdArt" OnClick="AgregarCarrito_Click" />
                <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                <a href="Productos.aspx" class="btn btn-outline-secondary btn-lg">Volver</a>
            </div>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
    <br /><br /><br />
</asp:Content>
