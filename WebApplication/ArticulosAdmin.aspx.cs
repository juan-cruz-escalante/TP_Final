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
    public partial class ArticulosAdmin : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["listaUsuarios"] == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulos = negocio.listarConSP();
                    Session["listaArticulos"] = listaArticulos;
                }
                else
                {
                    listaArticulos = (List<Articulos>)Session["listaArticulos"];
                }
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();
            }
        }
        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> Lista = (List<Articulos>)Session["listaArticulos"];
            listaArticulos = Lista.FindAll(x => x.Nombre.ToUpper().Contains(tbxFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaArticulos;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?ID=" + id);
        }
    }
}