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
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + aux.Id + ".png");

                aux.Pass = txtPass.Text;
                aux.Nombres = txtNombres.Text;
                aux.Apellidos = txtApellidos.Text;
                aux.ImagenUrl = "perfil-" + aux.Id + ".png";
                aux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                negocio.Actualizar(aux);

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