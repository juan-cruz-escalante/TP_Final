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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Productos"] != null)
            {
                ListaArticulo = (List<Articulos>)Session["Productos"];
            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulo = negocio.listar();
                Session.Add("Productos", ListaArticulo);
            }
        }
    }
}