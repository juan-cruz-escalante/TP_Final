using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.ID, A.Nombre, A.Descripcion, C.Nombre Categoria, T.Tamano, A.Precio, A.ImagenUrl, A.Disponible, T.ID IDTamanio, C.ID IDCategoria FROM Articulos A, Categoria C, Tamano T WHERE A.IdCategoria = C.ID AND A.IdTamano = T.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Tamanio = new Tamano();
                    aux.Tamanio.Tamanio = (string)datos.Lector["Tamano"];
                    aux.Tamanio.IdTamanio = (int)datos.Lector["IDTamanio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    aux.Categoria.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
