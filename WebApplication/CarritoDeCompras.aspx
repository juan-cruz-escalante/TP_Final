<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="WebApplication.CarritoDeCompras" %>

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
                                <div class="card h-100 text-center">
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
                <% if(total != 0) { %>
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
                <% } else { %>
                <br />
                    <div class="col text-center">
                        <h1 class="btn btn-info">El carrito esta vacio</h1>
                    </div>
                <br />
                <% } %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br /><br /><br /><br />
</asp:Content>
