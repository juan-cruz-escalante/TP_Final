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
            if ((Page is CarritoDeCompras))
            {
                if (!(Seguridad.sesionActiva(Session["usuario"])))
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    imgPerfil.ImageUrl = "~/Images/" + usuario.ImagenUrl;

                    if (!string.IsNullOrEmpty(usuario.Nombres) && !string.IsNullOrEmpty(usuario.Apellidos))
                    {
                        txtUser.Text = usuario.Nombres + " " + usuario.Apellidos;
                    }
                    else
                    {
                        txtUser.Text = usuario.User;
                    }
                }
                else
                {
                    imgPerfil.ImageUrl = "https://cdn.icon-icons.com/icons2/3298/PNG/512/ui_user_profile_avatar_person_icon_208734.png";
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