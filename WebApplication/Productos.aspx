<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApplication.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>

    <!-- Menu de articulos -->

    <%if (opcion == 0) { %>
    <br/>
        <div class="container text-center">
            <div class="row align-items-start">
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn1" runat="server" ImageUrl="Contenido/1.png" CssClass="imageButton" OnClick="btn1_Click" />
                </div>
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn2" runat="server" ImageUrl="Contenido/2.png" CssClass="imageButton" OnClick="btn2_Click" />
                </div>
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn3" runat="server" ImageUrl="Contenido/3.png" CssClass="imageButton" OnClick="btn3_Click" />
                </div>
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn4" runat="server" ImageUrl="Contenido/4.png" CssClass="imageButton" OnClick="btn4_Click" />
                </div>
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn5" runat="server" ImageUrl="Contenido/5.png" CssClass="imageButton" OnClick="btn5_Click" />
                </div>
                <div class="col-6 col-md-4">
                    <asp:ImageButton ID="btn6" runat="server" ImageUrl="Contenido/6.png" CssClass="imageButton" OnClick="btn6_Click" />
                </div>
            </div>
        </div>
    <br/>
     <% } %>

    <!-- Tipo de articulo seleccionado -->
    <!-- Seccion filtro y boton de volver -->
    
    <% if (opcion != 0) { %>
    <div class="position-relative">
        <!-- boton de volver -->
        <div class="position-absolute top-0 start-0">
            <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-danger" OnClick="btnRegresar_Click">
                <i class="fa-solid fa-arrow-left"></i> Volver
            </asp:LinkButton>
        </div>
        <!-- Filtro -->
        <div class="position-absolute top-0 end-0">
            <asp:TextBox ID="tbxFiltro" placeholder="Buscar" OnTextChanged="tbxFiltro_TextChanged" runat="server" > </asp:TextBox>
            <i class="fa-solid fa-magnifying-glass"></i>
        </div>
    </div>
    <br/><br/><br/>

    <!-- Listado del tipo de producto seleccionado -->

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% foreach (Dominio.Articulos art in ListaArticulo) {
                if (art.Categoria.Id == opcion) { %>
                  <div class="col">
                    <div class="card h-100">
                      <img src="<%: art.ImagenUrl %>" title="Imagen del producto" class="card-img-top" alt="Imagen no encontrada"
                           onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
                      <div class="card-body">
                        <h5 class="card-title"><%: art.Nombre %></h5>
                        <p class="card-text">Precio: $<%: art.Precio %></p>
                          <a href="CarritoDeCompras.aspx?id=<%: art.IdArticulo %>" class="btn btn-success">Agregar al carrito</a>
                      </div>
                    </div>
                  </div>
             <% } %>
        <% } %>
    <% } %>
    </div>
    <br/><br/><br/>
</asp:Content>