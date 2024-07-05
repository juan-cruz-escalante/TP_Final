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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulos> Carrito;
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new List<Articulos>();
            }

            Carrito = (List<Articulos>)Session["Carrito"];
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int id))
            {
                if (Session["Productos"] != null)
                {
                    List<Articulos> SeccionProductos = (List<Articulos>)Session["Productos"];
                    Articulos seleccionado = SeccionProductos.Find(x => x.IdArticulo == id);

                    if (seleccionado != null && !Carrito.Any(x => x.IdArticulo == id))
                    {
                        Carrito.Add(seleccionado);
                        Session["Carrito"] = Carrito;
                    }
                }
            }
            dgvCarrito.DataSource = Carrito;
            dgvCarrito.DataBind();
        }
    }
}