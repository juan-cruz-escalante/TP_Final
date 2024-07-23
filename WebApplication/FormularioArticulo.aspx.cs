using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
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
                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Precio = int.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtUrl.Text;
                nuevo.Stock = int.Parse(txtStock.Text);

                negocio.agregarconSP(nuevo);
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
    }
}