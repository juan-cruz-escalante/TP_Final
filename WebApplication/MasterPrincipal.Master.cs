using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        Usuario user = new Usuario();
        public int Cantidad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                imgPerfil.ImageUrl = ((Dominio.Usuario)Session["usuario"]).ImagenUrl;
            }
            else
            {
                imgPerfil.ImageUrl = "https://img.freepik.com/vector-premium/icono-perfil-usuario-estilo-plano-ilustracion-vector-avatar-miembro-sobre-fondo-aislado-concepto-negocio-signo-permiso-humano_157943-15752.jpg";
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