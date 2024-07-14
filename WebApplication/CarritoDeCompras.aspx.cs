using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApplication
{
    public partial class CarritoDeCompras : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Productos"] == null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listarConSP();
                Session.Add("Productos", listaArticulos);
            }
            dgvArticulos.DataSource = Session["Productos"];
            dgvArticulos.DataBind();
        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("CarritoDeCompras.aspx?id=" + id);
        }
    }
}