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
                string email = txtEmail.Text;

                if (!email.Contains("@") && !email.Contains(".com"))
                {
                    lblErrorMail.Text = "No se pudo registrar, correo electrónico inválido";
                    lblErrorMail.Visible = true;
                    return;
                }
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                user.User = email;
                user.Pass = txtPassword.Text;
                int id = negocio.insertarNuevo(user);

                if (id > 0)
                {
                    lblDatosVacios.Text = "¡Ya estás registrado!";
                    lblDatosVacios.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblErrorIngreso.Text = "Ocurrió un error al intentar registrarse.";
                lblErrorIngreso.Visible = true;
            }
        }
    }
}