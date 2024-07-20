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
          <div class="carousel-inner" data-bs-ride="carousel">
            <div class="carousel-item active">
                <a href="Productos.aspx?opcion=2">
                  <img src="Contenido/10.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>Encuentra tu Smartphone Ideal</h5>
                    <p>Descubre nuestra amplia selección de teléfonos celulares de las mejores marcas. Desde los últimos modelos hasta opciones más económicas, tenemos el dispositivo perfecto para ti. 
                        Navega por nuestras categorías, compara características y encuentra el smartphone que se adapta a tus necesidades y presupuesto. 
                        ¡Aprovecha nuestras ofertas y promociones exclusivas!</p>
                  </div>
                </a>
            </div>
            <div class="carousel-item">
                <a href="Productos.aspx?opcion=2">
                  <img src="Contenido/11.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>Encuentra tu Smartphone Ideal</h5>
                    <p>Descubre nuestra amplia selección de teléfonos celulares de las mejores marcas. Desde los últimos modelos hasta opciones más económicas, tenemos el dispositivo perfecto para ti. 
                        Navega por nuestras categorías, compara características y encuentra el smartphone que se adapta a tus necesidades y presupuesto.
                        ¡Aprovecha nuestras ofertas y promociones exclusivas!</p>
                  </div>
                </a>
            </div>
            <div class="carousel-item">
              <a href="Productos.aspx?opcion=2">
                  <img src="Contenido/12.png" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h5>Encuentra tu Smartphone Ideal</h5>
                    <p>Descubre nuestra amplia selección de teléfonos celulares de las mejores marcas. Desde los últimos modelos hasta opciones más económicas, 
                        tenemos el dispositivo perfecto para ti. Navega por nuestras categorías, compara características y encuentra el smartphone que se adapta a tus necesidades y presupuesto. 
                        ¡Aprovecha nuestras ofertas y promociones exclusivas!</p>
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
    <div id="carouselExampleCaptions2" class="carousel slide">
        <div class="carousel-indicators">
          <button type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
          <button type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide-to="1" aria-label="Slide 2"></button>
          <button type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner" data-bs-ride="carousel">
          <div class="carousel-item active">
              <a href="Productos.aspx?opcion=6">
                <img src="Contenido/20.png" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                  <h5>Consolas de Videojuegos</h5>
                  <p style="color:black">DSumérgete en el mundo del gaming con nuestras consolas de última generación. Ya seas fan de PlayStation o Xbox, encontrarás las mejores ofertas en PS5, Xbox Series X y Series S, junto con una amplia gama de accesorios y juegos. Descubre la mejor experiencia de juego con nuestra selección, 
                      compara especificaciones y elige la consola que elevará tu entretenimiento al siguiente nivel. ¡No te pierdas nuestras promociones exclusivas!</p>
                </div>
              </a>
          </div>
          <div class="carousel-item">
              <a href="Productos.aspx?opcion=6">
                <img src="Contenido/21.png" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                  <h5 style="color:black">Consolas de Videojuegos</h5>
                  <p style="color:black">Sumérgete en el mundo del gaming con nuestras consolas de última generación. Ya seas fan de PlayStation o Xbox, encontrarás las mejores ofertas en PS5, Xbox Series X y Series S, junto con una amplia gama de accesorios y juegos. Descubre la mejor experiencia de juego con nuestra selección, 
                      compara especificaciones y elige la consola que elevará tu entretenimiento al siguiente nivel. ¡No te pierdas nuestras promociones exclusivas!</p>
                </div>
              </a>
          </div>
          <div class="carousel-item">
            <a href="Productos.aspx?opcion=6">
                <img src="Contenido/22.png" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                  <h5>Consolas de Videojuegos</h5>
                  <p>Sumérgete en el mundo del gaming con nuestras consolas de última generación. Ya seas fan de PlayStation o Xbox, encontrarás las mejores ofertas en PS5, Xbox Series X y Series S, junto con una amplia gama de accesorios y juegos. Descubre la mejor experiencia de juego con 
                      nuestra selección, compara especificaciones y elige la consola que elevará tu entretenimiento al siguiente nivel. ¡No te pierdas nuestras promociones exclusivas!</p>
                </div>
            </a>
          </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions2" data-bs-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </button>
      </div>
    <br /><br /><br />
      <div id="carouselExampleCaptions3" class="carousel slide">
      <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleCaptions3" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions3" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions3" data-bs-slide-to="2" aria-label="Slide 3"></button>
      </div>
      <div class="carousel-inner" data-bs-ride="carousel">
        <div class="carousel-item active">
            <a href="Productos.aspx?opcion=5">
              <img src="Contenido/30.png" class="d-block w-100" alt="...">
              <div class="carousel-caption d-none d-md-block">
                <h5>La Notebook perfecta para vos</h5>
                <p>Explora nuestra extensa colección de notebooks de las marcas más reconocidas. Desde modelos ultra portátiles para trabajar en movimiento hasta poderosas máquinas para gaming y diseño gráfico, tenemos la notebook ideal para cada necesidad. Compara características, descubre las últimas novedades y encuentra 
                    la mejor opción para tu estilo de vida. ¡Aprovecha nuestras ofertas y promociones exclusivas para llevarte la notebook de tus sueños al mejor precio!</p>
              </div>
            </a>
        </div>
        <div class="carousel-item">
            <a href="Productos.aspx?opcion=5">
              <img src="Contenido/31.png" class="d-block w-100" alt="...">
              <div class="carousel-caption d-none d-md-block">
                <h5>La Notebook perfecta para vos</h5>
                <p>Explora nuestra extensa colección de notebooks de las marcas más reconocidas. Desde modelos ultra portátiles para trabajar en movimiento hasta poderosas máquinas para gaming y diseño gráfico, tenemos la notebook ideal para cada necesidad. Compara características, descubre las últimas novedades y encuentra la mejor opción para tu estilo de vida. 
                    ¡Aprovecha nuestras ofertas y promociones exclusivas para llevarte la notebook de tus sueños al mejor precio!</p>
              </div>
            </a>
        </div>
        <div class="carousel-item">
          <a href="Productos.aspx?opcion=2">
              <img src="Contenido/32.png" class="d-block w-100" alt="...">
              <div class="carousel-caption d-none d-md-block">
                <h5>La Notebook perfecta para vos</h5>
                <p>DExplora nuestra extensa colección de notebooks de las marcas más reconocidas. Desde modelos ultra portátiles para trabajar en movimiento hasta poderosas máquinas para gaming y diseño gráfico, tenemos la notebook ideal para cada necesidad. Compara características, descubre las últimas novedades y 
                    encuentra la mejor opción para tu estilo de vida. ¡Aprovecha nuestras ofertas y promociones exclusivas para llevarte la notebook de tus sueños al mejor precio!</p>
              </div>
          </a>
        </div>
      </div>
      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions3" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions3" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
<br /><br /><br />
</asp:Content>