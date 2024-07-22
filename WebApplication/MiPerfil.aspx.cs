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
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        txtUser.Text = aux.User;
                        txtPass.Text = aux.Pass;
                        txtApellidos.Text = aux.Apellidos;
                        txtNombres.Text = aux.Nombres;
                        txtFechaNacimiento.Text = aux.FechaNacimiento.ToString("yyyy-MM-dd");
                    }

                    if (!string.IsNullOrEmpty(aux.ImagenUrl))
                    {
                        imgNuevoPerfil.ImageUrl = "~/Images/" + aux.ImagenUrl;
                    }
                    else
                    {
                        imgNuevoPerfil.ImageUrl = "https://cdn.icon-icons.com/icons2/3298/PNG/512/ui_user_profile_avatar_person_icon_208734.png";
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
                Usuario aux = (Usuario)Session["usuario"];

                string ruta = Server.MapPath("./Images/");

                // Verificar si se ha seleccionado un archivo para la imagen
                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    // Guardar el archivo de imagen
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + aux.Id + ".png");
                    aux.ImagenUrl = "perfil-" + aux.Id + ".png";
                }

                // Actualizar otros campos del usuario
                aux.Pass = txtPass.Text;
                aux.Nombres = txtNombres.Text;
                aux.Apellidos = txtApellidos.Text;
                aux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                negocio.Actualizar(aux);
                // Opcional: Mostrar mensaje de éxito
                lblMensaje.Text = "Usuario actualizado con éxito.";
                lblMensaje.CssClass = "text-success";
                lblMensaje.Visible = true;

                // Actualizar la imagen en la página maestra
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + aux.ImagenUrl;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}