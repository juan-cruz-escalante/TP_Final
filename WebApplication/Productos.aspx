<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row row-cols-1 row-cols-md-3 g-4">
    <% foreach (Dominio.Articulos art in ListaArticulo) { %>
      <div class="col">
        <div class="card h-100">
          <img src="<%: art.ImagenUrl %>" title="Imagen del producto" class="card-img-top" alt="Imagen no encontrada"
               onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
          <div class="card-body">
            <h5 class="card-title"><%: art.Nombre %></h5>
            <p class="card-text">Precio: $<%: art.Precio %></p>
          </div>
        </div>
      </div>
    <% } %>
</div>
</asp:Content>