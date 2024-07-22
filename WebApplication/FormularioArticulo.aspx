<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="WebApplication.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <!-- Primera columna -->
                <div class="mb-3 form-floating">
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Style="width: 100%; max-width: 100%;" placeholder=" "></asp:TextBox>
                    <label for="txtNombre">Nombre del artículo</label>
                </div>
                <div class="mb-3 form-floating">
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" Style="width: 100%; max-width: 100%;" placeholder=" "></asp:TextBox>
                    <label for="txtDescripcion">Descripción</label>
                </div>
                <div class="mb-3 form-floating">
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
                    <label for="ddlCategoria">Categoría</label>
                </div>
                <div class="mb-3 form-floating">
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                    <label for="ddlMarca">Marca</label>
                </div>
                <div class="mb-3 form-floating">
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Style="width: 100%; max-width: 100%;" placeholder=" "></asp:TextBox>
                    <label for="txtPrecio">Precio</label>
                </div>
                <div class="mb-3 form-floating">
                    <asp:TextBox runat="server" ID="txtStock" CssClass="form-control" Style="width: 100%; max-width: 100%;" placeholder=" "></asp:TextBox>
                    <label for="txtStock">Stock</label>
                </div>
            </div>
            <div class="col-md-6">
                <!-- Segunda columna -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3 form-floating">
                            <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control" Style="width: 100%; max-width: 100%;" placeholder=" " AutoPostBack="true" OnTextChanged="txtUrl_TextChanged"></asp:TextBox>
                            <label for="txtUrl">URL Imagen</label>
                        </div>
                        <div class="mb-3 form-floating">
                            <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg" runat="server" ID="imgArticulo" CssClass="img-fluid mb-3" Style="max-width: 100%; height: auto;" />
                        </div>
                        <asp:Button Text="Eliminar" ID="Button2" OnClick="btnEliminar_Click" CssClass="btn btn-danger float-end mb-3" runat="server" />
                        <% if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <!-- Guardar o volver -->
        <div class="row mt-4">
            <div class="col-md-6 d-flex justify-content-start">
                <div>
                    <asp:Button Text="Guardar" CssClass="btn btn-danger btn-lg me-2" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                    <a href="ArticulosAdmin.aspx" class="btn btn-success">Volver</a>
                </div>
            </div>
            <asp:Label ID="lblMensaje" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
