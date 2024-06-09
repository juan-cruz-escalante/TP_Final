using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            string email = inputEmail.Text;
            string _pass = inputPassword.Text;

            try
            {
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(_pass))
                {
                    lblDatosVacios.Text = "No ha ingresado ningún dato";
                    lblDatosVacios.Visible = true;
                    return;
                }
                if (!email.Contains("@"))
                {
                    lblErrorMail.Text = "Por favor ingrese un correo electrónico válido.";
                    lblErrorMail.Visible = true;
                    return;
                }
                usuario = new Usuario(email, _pass, true);
                if(negocio.Loguear(usuario)) 
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    if (lblDatosVacios.Visible == false)
                    {
                        lblErrorIngreso.Text = "Usuario o Contraseña incorrectos.";
                        lblErrorIngreso.Visible = true;
                    }
                }
            }
            catch (Exception ex) 
            { 
                Session.Add("Error",ex.ToString());
            }
        }
    }
}