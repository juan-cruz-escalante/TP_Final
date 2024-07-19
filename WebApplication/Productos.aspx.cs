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
        public int opcion
        {
            get { return ViewState["opcion"] != null ? (int)ViewState["opcion"] : 0; }
            set { ViewState["opcion"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Leer el parámetro de la URL
                string opcionQueryString = Request.QueryString["opcion"];
                if (int.TryParse(opcionQueryString, out int opcionId))
                {
                    opcion = opcionId;
                }
                else
                {
                    opcion = 0; // Valor predeterminado si no se proporciona un parámetro válido
                }
            }

            // Cargar los productos desde la sesión o la base de datos
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
        protected void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> Lista = (List<Articulos>)Session["Productos"];
            ListaArticulo = Lista.FindAll(x => x.Nombre.ToUpper().Contains(tbxFiltro.Text.ToUpper()));
        }
        protected void btn1_Click(object sender, ImageClickEventArgs e) { opcion = 1; }
        protected void btn2_Click(object sender, ImageClickEventArgs e) { opcion = 2; }
        protected void btn3_Click(object sender, ImageClickEventArgs e) { opcion = 3; }
        protected void btn4_Click(object sender, ImageClickEventArgs e) { opcion = 4; }
        protected void btn5_Click(object sender, ImageClickEventArgs e) { opcion = 5; }
        protected void btn6_Click(object sender, ImageClickEventArgs e) { opcion = 6; }
        protected void btnRegresar_Click(object sender, EventArgs e) { opcion = 0; }
    }
}