using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Articulos ArticuloDetalle { get; set; }
        public List<Articulos> Carrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Detalle"] == null)
            {
                Session["Detalle"] = new Articulos();
            }
            ArticuloDetalle = (Articulos)Session["Detalle"];

            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int id))
            {
                if (Session["Productos"] != null)
                {
                    List<Articulos> SeccionProductos = (List<Articulos>)Session["Productos"];
                    Articulos seleccionado = SeccionProductos.Find(x => x.IdArticulo == id);

                    if (seleccionado != null && ArticuloDetalle.IdArticulo != id)
                    {
                        ArticuloDetalle = seleccionado;
                        Session["Detalle"] = ArticuloDetalle;
                    }
                }
            }
        }

        protected void AgregarCarrito_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {

                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = new List<Articulos>();
                }
                Carrito = (List<Articulos>)Session["Carrito"];
                bool existeEnCarrito = Carrito.Any(x => x.IdArticulo == ArticuloDetalle.IdArticulo);

                if (!existeEnCarrito)
                {
                    Carrito.Add(ArticuloDetalle);
                    Session["Carrito"] = Carrito;
                }
                else
                {
                    ArticuloDetalle.contador++;
                    Session["Carrito"] = Carrito;
                }
            }
            else
            {
                lblError.Text = "Para agregar al carrito debe inicar sesion o crear una cuenta";
                lblError.Visible = true;
            }
        }
    }
}
