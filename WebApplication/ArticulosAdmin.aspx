<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ArticulosAdmin.aspx.cs" Inherits="WebApplication.ArticulosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <!-- Filtro de búsqueda -->
        <div class="row mb-4">
            <div class="col-12">
                <div class="input-group">
                    <asp:TextBox ID="tbxFiltro" placeholder="Buscar" CssClass="form-control" OnTextChanged="tbxFiltro_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                    <span class="input-group-text">
                        <i class="fa-solid fa-magnifying-glass"></i>
                    </span>
                </div>
            </div>
        </div>
        <!-- Tabla de artículos -->
        <div class="table-responsive">
            <asp:GridView ID="dgvArticulos" DataKeyNames="IdArticulo" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <asp:Image runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' AlternateText="Imagen del Artículo" Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Stock" DataField="Stock" />
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="Select" CommandArgument='<%# Eval("IdArticulo") %>' CssClass="btn btn-outline-primary btn-sm">
                                <i class="fa-solid fa-pen-to-square"></i>
                                <span class="visually-hidden">Editar</span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Borrar">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="Select" CommandArgument='<%# Eval("IdArticulo") %>' CssClass="btn btn-outline-danger btn-sm">
                                <i class="fa-solid fa-trash-can"></i>
                                <span class="visually-hidden">Borrar</span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <!-- Botón de agregar -->
        <div class="text-end mb-4">
            <a href="No se como lo haras pero lo pense como un link" class="btn btn-success btn-lg">
                <i class="fa-solid fa-plus"></i>
            </a>
        </div>
    </div>
</asp:Content>
