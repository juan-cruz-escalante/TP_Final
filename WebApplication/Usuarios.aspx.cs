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
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuarios"] == null)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                listaUsuarios = negocio.listar();
                Session.Add("listaUsuarios", listaUsuarios);
            }
            dgvUsuarios.DataSource = Session["listaUsuarios"];
            dgvUsuarios.DataBind();
        }
    }
}