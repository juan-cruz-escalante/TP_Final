<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplication.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="row">
        <div class="col">
            <asp:GridView ID="dgvUsuarios" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-bordered">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Usuario" DataField="User" />
                    <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
                    <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
                    <asp:CheckBoxField HeaderText="Administrador" DataField="admin" />
                </Columns>
            </asp:GridView>


            <%--                public int Id { get; set; }
                public string User { get; set; }
                public string Pass { get; set; }
                public string Nombres { get; set; }
                public string Apellidos { get; set; }
                public DateTime FechaNacimiento { get; set; }
                public string ImagenUrl { get; set; }
                public bool admin { get; set; }--%>
        </div>
    </div>
</asp:Content>
