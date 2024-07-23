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
    public partial class EditarArticulo : System.Web.UI.Page
    {
    public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> marcas = marcaNegocio.listar();
                    CategoriaNegocio catNegocio = new CategoriaNegocio();
                    List<Categoria> categorias = catNegocio.listar();


                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Nombre";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();

                    int id;
                    if (int.TryParse(Request.QueryString["ID"], out id))
                    {
                        Articulos articuloActual = negocio.obtenerPorId(id);
                        if (articuloActual != null)
                        {
                            CargarDatosArticulo(articuloActual);
                            Session["ArticulosID"] = id;
                        }
                        else
                        {
                            lblMensaje.Text = "Artículo no encontrado.";
                            lblMensaje.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "ID inválido.";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Session.Add("Error", ex);
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                int id = (int)Session["ArticulosID"];
                Articulos articulo = negocio.obtenerPorId(id);

                if (articulo != null)
                {

                    // Actualizar otros campos del usuario
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Categoria.Id = !string.IsNullOrEmpty(ddlCategoria.SelectedValue) ? Convert.ToInt32(ddlCategoria.SelectedValue) : 0;
                    articulo.Marca.Id = !string.IsNullOrEmpty(ddlMarca.SelectedValue) ? Convert.ToInt32(ddlMarca.SelectedValue) : 0;
                    articulo.Precio = float.Parse(txtPrecio.Text);
                    articulo.ImagenUrl = txtUrl.Text;
                    articulo.Stock = int.Parse(txtPrecio.Text);

                    negocio.ActualizarArt(articulo);

                    lblMensaje.Text = "Usuario actualizado con éxito.";
                    lblMensaje.CssClass = "text-success";
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "Usuario no encontrado para la actualización.";
                    lblMensaje.Visible = true;
                }

                Response.Redirect("ArticulosAdmin.aspx", false);
            }
            catch (Exception ex)
            {
                //Session.Add("Error", ex);
                throw ex;
            }
        }

        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrl.Text;
        }

        private void CargarDatosArticulo(Articulos articulo)
        {
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
            ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
            txtPrecio.Text = articulo.Precio.ToString();
            txtUrl.Text = articulo.ImagenUrl;
            txtStock.Text = articulo.Stock.ToString();

            imgArticulo.ImageUrl = articulo.ImagenUrl;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    if (negocio.eliminar((int)Session["ArticulosID"]))
                    {
                        lblMensaje.Text = "Artículo eliminado";
                        lblMensaje.Visible = true;
                        Response.Redirect("FormularioArticulo.aspx?msg=eliminado");
                        Response.AppendHeader("Refresh", "2;url=ArticulosAdmin.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Error al eliminar el registro.";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }
    }
}