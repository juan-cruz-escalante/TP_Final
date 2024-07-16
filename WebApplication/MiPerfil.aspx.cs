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
            Usuario aux = (Usuario)Session["usuario"];
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (!IsPostBack)
                {
                    if (Session["usuario"] != null)
                    {
                        txtUser.Text = aux.User;
                        txtPass.Text = aux.Pass;
                        txtApellidos.Text = aux.Apellidos;
                        txtNombres.Text = aux.Nombres;
                    }
                }
            } 
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./Images/");
                Usuario aux = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + aux.Id + ".jpg");

                aux.Apellidos = txtApellidos.Text;
                aux.Nombres = txtNombres.Text;
                aux.ImagenUrl = "perfil-" + aux.Id + ".jpg";
                aux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);  

                negocio.Actualizar(aux);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}