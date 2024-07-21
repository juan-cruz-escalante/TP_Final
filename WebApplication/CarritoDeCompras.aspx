<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="WebApplication.CarritoDeCompras" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container mt-5">
    <div class="row">
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <div class="col-12 mb-3">
                    <div class="card h-100 position-relative">
                        <div class="row g-0">
                            <div class="col-md-2">
                                <img src='<%# Eval("ImagenUrl") %>' title="Imagen del producto" class="img-fluid img-thumbnail" 
                                 alt="Imagen no encontrada"
                                 style="max-height: 150px; object-fit: cover;"
                                 onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
                            </div>
                            <div class="col-md-7">
                                <div class="card-body">
                                    <h5 class="card-title"><strong><%# Eval("Nombre") %></strong></h5>
                                    <p class="card-text"><strong>Marca: </strong><%# Eval("Marca") %></p>
                                    <p class="card-text" style="color: green"><strong>Precio: </strong>$<%# string.Format("{0:N2}", Eval("Precio")) %></p>
                                </div>
                            </div>
                            <div class="col-md-3 d-flex flex-column justify-content-center align-items-center">
                                <div class="btn-group mb-2" role="group" aria-label="Basic example">
                                    <asp:LinkButton CssClass="btn btn-outline-success" runat="server" ID="AgregarArticulo" CommandArgument='<%# Eval("IdArticulo") %>' CommandName="IdArt" OnClick="AgregarArticulo_Click">
                                        <i class="fa-solid fa-plus"></i>
                                    </asp:LinkButton>
                                    <div class="btn btn-success" style="width: 3rem;"><%# Eval("contador") %></div>
                                    <asp:LinkButton CssClass="btn btn-outline-danger" runat="server" ID="RestarButton" CommandArgument='<%# Eval("IdArticulo") %>' CommandName="RestarArticulo" OnClick="RestarArticulo_Click">
                                        <i class="fa-solid fa-minus"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <asp:LinkButton CssClass="btn btn-danger position-absolute top-0 end-0 m-2" runat="server" ID="EliminarArticulo" CommandArgument='<%# Eval("IdArticulo") %>'
                                        CommandName="IdArt" OnClick="EliminarArticulo_Click">
                            <i class="fa-regular fa-trash-can"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>


                 <!-- Panel para mostrar el total -->
                <% if (total != 0)
                { %>
                <div class="container text-center mt-4">
                    <div class="alert alert-light d-inline-flex align-items-center p-3 rounded border-secondary" role="alert">
                        <i class="fa-solid fa-tag me-2"></i> <!-- Icono opcional -->
                        <h4 class="mb-0">Total: $<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h4>
                    </div>
                </div>

                <%}%>
                <% if (total != 0 && Session["usuario"] != null)
                    { %>
                <asp:Panel ID="divTotal" runat="server" Visible="true">
                    <div class="row mt-4">
                        <div class="col text-center">
                                <asp:Button Text="Finalizar compra" CssClass="btn btn-success" runat="server" ID="Finalizar" CommandArgument='<%# Eval("IdArticulo") %>' CommandName="IdArt" OnClick="Finalizar_Click" />
                        </div>
                    </div>
                </asp:Panel>
                <% }
                    else
                    {
                        if (Session["usuario"] == null)
                        { %>
                <div class="col text-center">
                    <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                    <br /><br />
                    <a href="IniciarSesion.aspx" class="btn btn-dark">Inicar Sesion</a>
                    <a href="Registrarse.aspx" class="btn btn-dark">Registrarse</a>
                    <a href="Productos.aspx" class="btn btn-dark">Volver</a>
                </div>
                <% }
                    else if(total !=0)
                    { %>
                <br />
                <div class="col text-center">
                    <h1 id="H1" class="btn btn-info">El carrito esta vacio</h1>
                </div>
                <%}
                    }%>
                <br />

                    <!-- Contenedor para el botón de pago de Mercado Pago -->
                    <div id="wallet_container"></div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
    <br />
    <br />

    <script src="https://sdk.mercadopago.com/js/v2"></script>
    <script>
        const mp = new MercadoPago('TEST-225d3c05-2356-46c7-9814-f115312ab0ab');
        
        function initializeCheckout(preferenceId) {
            if (preferenceId) {
                mp.bricks().create("wallet", "wallet_container", {
                    initialization: {
                        preferenceId: preferenceId
                    },
                    customization: {
                        texts: {
                            valueProp: 'smart_option',
                        },
                    },
                });
            } else {
                console.error("No se ha proporcionado un ID de preferencia.");
            }
        }

        // Manejador de evento para el botón "Finalizar compra"
        document.getElementById('<%= Finalizar.ClientID %>').addEventListener('click', function() {
            const preferenceId = '<%= Session["preferenceId"] %>';
            initializeCheckout(preferenceId);
        });
    </script>
</asp:Content>
