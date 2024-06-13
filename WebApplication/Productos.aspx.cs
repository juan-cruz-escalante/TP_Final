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
        public int opcion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                opcion = 0;
            }
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

        protected void btn1_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 1;
        }

        protected void btn2_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 2;
        }

        protected void btn3_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 3;
        }

        protected void btn4_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 4;
        }

        protected void btn5_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 5;
        }

        protected void btn6_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 6;
        }

        protected void btn7_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 7;
        }

        protected void btn8_Click(object sender, ImageClickEventArgs e)
        {
            opcion = 8;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            opcion = 0;
        }
    }
}