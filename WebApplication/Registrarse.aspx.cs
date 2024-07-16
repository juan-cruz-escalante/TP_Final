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
            Usuario usuario;
            try
            {
                string email = txtEmail.Text;
                string _pass = txtPassword.Text;

                    if (!email.Contains("@") || !email.Contains("."))
                {
                    lblErrorMail.Text = "Correo electrónico inválido";
                    lblErrorMail.Visible = true;
                    return;
                }

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                user.User = email;
                user.Pass = _pass;
                user.Id = negocio.insertarNuevo(user);

                if (user.Id > 0)
                {
                    emailService.armarCorreo(user.User, "Bienvenida", "Hola, ¡bienvenido a nuestra aplicación!");
                    emailService.enviarEmail();
                    lblDatosVacios.Text = "¡Ya estás registrado! Se ha enviado un correo de confirmación.";
                    lblDatosVacios.Visible = true;
                    usuario = new Usuario(email, _pass);
                    Session.Add("usuario", usuario);
                    Response.Redirect("Inicio.aspx", false);
                }
                else
                {
                    lblDatosVacios.Visible = false;
                    throw new Exception("Error al insertar usuario en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                lblErrorIngreso.Text = "Ocurrió un error al intentar registrarse: " + ex.Message;
                lblErrorIngreso.Visible = true;
            }
        }
    }
}