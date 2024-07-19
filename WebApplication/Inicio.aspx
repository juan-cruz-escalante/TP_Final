<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="carouselExampleCaptions" class="carousel slide">
          <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
          </div>
          <div class="carousel-inner">
            <div class="carousel-item active">
                <a href="Productos.aspx?opcion=6">
                  <img src="Contenido/11.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5 style="color:black">Desata la Potencia de la PlayStation 5</h5>
                    <p style="color:black">Experimenta juegos como nunca antes con la consola PlayStation 5. Disfruta de gráficos impresionantes, velocidad de carga ultrarrápida 
                        y una inmersión total en cada partida. Consigue la tuya y lleva tu experiencia de juego al siguiente nivel.</p>
                  </div>
                </a>
            </div>
            <div class="carousel-item">
                <a href="Productos.aspx?opcion=2">
                  <img src="Contenido/22.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>El Poder del iPhone 15 Pro en tus Manos</h5>
                    <p>Descubre el futuro con el iPhone 15 Pro: un diseño elegante, rendimiento sin igual y la cámara más avanzada que jamás hayas visto. Con tecnología de vanguardia y capacidades 
                        impresionantes, este es el smartphone que redefine lo posible. Consíguelo hoy y experimenta la excelencia en cada detalle.</p>
                  </div>
                </a>
            </div>
            <div class="carousel-item">
              <a href="Productos.aspx?opcion=1">
                  <img src="Contenido/33.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5 style="color:black">Sumérgete en el Entretenimiento con el Samsung Smart TV</h5>
                    <p style="color:black">Disfruta de una experiencia visual envolvente con el Samsung Smart TV de 43 pulgadas. Con resolución Full HD, tecnología de imagen avanzada y acceso a tus aplicaciones favoritas, cada película, serie y 
                        videojuego cobra vida en una pantalla vibrante y nítida. Dale un upgrade a tu sala de estar con la calidad que solo Samsung puede ofrecer.</p>
                  </div>
              </a>
            </div>
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>
    <br /><br /><br />
</asp:Content>