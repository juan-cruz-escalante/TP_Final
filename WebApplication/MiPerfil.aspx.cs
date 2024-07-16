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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}