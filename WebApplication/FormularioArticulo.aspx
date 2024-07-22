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
                            <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg" runat="server" ID="imgArticulo" Style="max-width: 100%; height: auto;" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <!-- Guardar o volver -->
        <div class="row mt-4">
            <div class="col-md-12 d-flex justify-content-center">
                <div>
                    <asp:Button Text="Guardar" CssClass="btn btn-danger btn-lg me-2" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                    <a href="ArticulosAdmin.aspx" class="btn btn-success">Volver</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>