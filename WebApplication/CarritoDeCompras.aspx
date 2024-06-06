<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="WebApplication.CarritoDeCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col">
            <asp:GridView ID="dgvArticulos" DataKeyNames="IdArticulo" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" runat="server" CssClass="table table-dark table-bordered text-center" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Tamaño" DataField="Tamanio" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="&#36;{0:N2}" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Agregar" HeaderText="Agregar al carrito" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
