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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario.User = inputEmail.Text;
                usuario.Pass = inputPassword.Text;
                int id = negocio.insertarNuevo(usuario);
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void btnRegistrarse_Click1(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario.User = inputEmail.Text;
                usuario.Pass = inputPassword.Text;
                int id = negocio.insertarNuevo(usuario);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}