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
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                int id = negocio.obtenerUltimoIdArticulos();


                nuevo.User = txtUser.Text;
                nuevo.Pass = txtPass.Text;
                nuevo.Nombres = txtNombres.Text;
                nuevo.Apellidos = txtApellidos.Text;
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                string ruta = Server.MapPath("~/Images/");

                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + id + ".png");
                    nuevo.ImagenUrl = "perfil-" + nuevo.Id + ".png";
                }
                negocio.agregar(nuevo);
                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {
                //Session.Add("Error", ex);
                throw ex;
            }
        }
    }
}
