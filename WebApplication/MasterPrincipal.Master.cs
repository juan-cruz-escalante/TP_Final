using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebApplication
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        Usuario user = new Usuario();
        public int Cantidad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    if (!string.IsNullOrEmpty(usuario.ImagenUrl))
                    {
                        imgPerfil.ImageUrl = "~/Images/" + usuario.ImagenUrl;
                    }
                    else
                    {
                        imgPerfil.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxOX4mkcW8pH9FbpI9rTBkokiMxSY2GJ3eyw&s";
                    }

                    if (!string.IsNullOrEmpty(usuario.Nombres) && !string.IsNullOrEmpty(usuario.Apellidos))
                    {
                        txtUser.Text = usuario.Nombres + " " + usuario.Apellidos;
                    }
                    else
                    {
                        txtUser.Text = usuario.User;
                    }
                }
            }

            if (Session["Carrito"] != null)
            {
                List<Articulos> carrito = (List<Articulos>)Session["Carrito"];
                int numeroDeRegistros = carrito.Sum(a => a.contador);
                Cantidad = numeroDeRegistros;
            }
            else
            {
                Cantidad = 0;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx");
        }

    }
}