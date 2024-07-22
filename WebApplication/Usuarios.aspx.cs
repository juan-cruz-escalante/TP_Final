using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["listaUsuarios"] == null)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    listaUsuarios = negocio.listar();
                    Session["listaUsuarios"] = listaUsuarios;
                }
                else
                {
                    listaUsuarios = (List<Usuario>)Session["listaUsuarios"];
                }
                dgvUsuarios.DataSource = listaUsuarios;
                dgvUsuarios.DataBind();
            }
        }
        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("EditarUsuario.aspx?ID=" + id);
        }
    }
}