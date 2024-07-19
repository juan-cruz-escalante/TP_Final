<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="WebApplication.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-4">
        <div class="row">
            <div class="col-md-6 text-center">
                <img src="<%: ArticuloDetalle.ImagenUrl %>" class="imagen-detalle" alt="Imagen del producto" onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
            </div>
            <div class="col-md-6">
                <h1 class="fs-1"><%: ArticuloDetalle.Nombre %></h1>
                <p class="fs-4">Descripción: <%: ArticuloDetalle.Descripcion %></p>
                <p class="fs-4">Marca: <%: ArticuloDetalle.Marca%></p>
                <p class="fs-4">Precio: $<%: String.Format("{0:N2}", ArticuloDetalle.Precio) %></p>
                <asp:Button Text="Añadir al carrito" CssClass="btn btn-success" runat="server" ID="AgregarCarrito" CommandArgument='<%: ArticuloDetalle.IdArticulo%>' CommandName="IdArt" OnClick="AgregarCarrito_Click" />
                <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                <br />
                <br />
                <a href="Productos.aspx" class="btn btn-success">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>
