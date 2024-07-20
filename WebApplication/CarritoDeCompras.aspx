<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="WebApplication.CarritoDeCompras" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater runat="server" ID="Repetidor">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card h-100 text-center" style="width: 18rem;">
                                    <img src='<%# Eval("ImagenUrl") %>' title="Imagen del producto" class="card-img-top" alt="Imagen no encontrada"
                                         onerror="this.onerror=null; this.src='https://www.italfren.com.ar/images/catalogo/imagen-no-disponible.jpeg';">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                        <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                        <div class="btn-group" role="group" aria-label="Basic example">
                                            <asp:Button Text="+" CssClass="btn btn-outline-success" runat="server" ID="AgregarArticulo" CommandArgument='<%# Eval("IdArticulo") %>'
                                                        CommandName="IdArt" OnClick="AgregarArticulo_Click" />
                                            <div class="btn btn-success" style="width: 6rem;">
                                                Cantidad: <%# Eval("contador") %>
                                            </div>
                                            <asp:Button Text="-" CssClass="btn btn-outline-danger" runat="server" ID="RestarButton" CommandArgument='<%# Eval("IdArticulo") %>'
                                                        CommandName="RestarArticulo" OnClick="RestarArticulo_Click" />
                                        </div>
                                        <br /><br />
                                        <asp:Button Text="Eliminar del carrito" CssClass="btn btn-danger" runat="server" ID="EliminarArticulo" CommandArgument='<%# Eval("IdArticulo") %>'
                                                    CommandName="IdArt" OnClick="EliminarArticulo_Click" />
                                        <br /><br /><br /><br />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                 <!-- Panel para mostrar el total -->

                <% if (total != 0 && Session["usuario"] != null)
                    { %>
                <asp:Panel ID="divTotal" runat="server" Visible="true">
                    <div class="row mt-4">
                        <div class="col text-center">
                            <div class="btn btn-info">
                                <h4>Total: $<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h4>
                                <asp:Button Text="Finalizar compra" CssClass="btn btn-primary btn-lg" runat="server" ID="Finalizar"
                                    CommandArgument='<%# Eval("IdArticulo") %>' CommandName="IdArt" OnClick="Finalizar_Click" />
                            </div>
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
