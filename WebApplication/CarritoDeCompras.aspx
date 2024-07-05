<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="WebApplication.CarritoDeCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col">
            <asp:GridView ID="dgvCarrito" runat="server" CssClass="table table-dark table-bordered text-center"></asp:GridView>
        </div>
    </div>
</asp:Content>
