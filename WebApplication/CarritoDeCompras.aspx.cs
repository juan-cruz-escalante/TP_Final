using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Threading.Tasks;

namespace WebApplication
{
    public partial class CarritoDeCompras : System.Web.UI.Page
    {
        public List<Articulos> Carrito { get; set; }
        public decimal total { get; set; }

        protected async void Page_Load(object sender, EventArgs e)
        {
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

            if (!IsPostBack)
            {
                Repetidor.DataSource = Carrito;
                Repetidor.DataBind();
                ActualizarTotal();
                await GenerarPreferenceId();

                if (Carrito.Count == 0)
                {
                    divTotal.Visible = false;
                }
            }
        }

        protected void EliminarArticulo_Click(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Articulos articuloAEliminar = Carrito.FirstOrDefault(x => x.IdArticulo == idArticulo);
            if (articuloAEliminar != null)
            {
                Carrito.Remove(articuloAEliminar);
                articuloAEliminar.contador = 1;
                Session["Carrito"] = Carrito;
                Repetidor.DataSource = Carrito;
                Repetidor.DataBind();
                ActualizarTotal();
            }
        }

        protected void AgregarArticulo_Click(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Articulos articulo = Carrito.FirstOrDefault(x => x.IdArticulo == idArticulo);
            if (articulo != null)
            {
                articulo.contador++;
                Session["Carrito"] = Carrito;
                Repetidor.DataSource = Carrito;
                Repetidor.DataBind();
                ActualizarTotal();
            }
        }

        protected void RestarArticulo_Click(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Articulos articulo = Carrito.FirstOrDefault(x => x.IdArticulo == idArticulo);
            if (articulo != null)
            {
                articulo.contador--;
                if (articulo.contador <= 0)
                {
                    Carrito.Remove(articulo);
                    articulo.contador = 1;
                }
                Session["Carrito"] = Carrito;
                Repetidor.DataSource = Carrito;
                Repetidor.DataBind();
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            total = Carrito.Sum(x => (decimal)x.Precio * x.contador);
            lblTotal.Text = total.ToString("N2");
        }

        private async Task GenerarPreferenceId()
        {
            try
            {
                var mpBack = new MercadoPagoBack();
                string preferenceId = await mpBack.CreatePreferenceAsync();
                Session["preferenceId"] = preferenceId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Finalizar_Click(object sender, EventArgs e)
        {
        }
    }
}