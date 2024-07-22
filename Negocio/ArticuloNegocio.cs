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
                datos.setearConsulta("SELECT A.ID AS IDArticulo, A.Nombre, A.Descripcion, C.ID AS IDCategoria, C.Nombre AS Categoria, M.ID AS IDMarca, M.Nombre AS Marca, A.Precio, A.ImagenUrl, A.Disponible, A.Stock FROM Articulos A, Categoria C, Marca M WHERE A.IdCategoria = C.ID AND A.IdMarca = M.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["IDArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IDMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Stock = (int)datos.Lector["Stock"];

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
        public List<Articulos> listarConSP()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.ID, A.Nombre, A.Descripcion, C.ID IDCategoria, C.Nombre Categoria, M.ID IDMarca, M.Nombre Marca, A.Precio, A.ImagenUrl, A.Disponible, A.Stock FROM Articulos A, Categoria C, Marca M WHERE A.IdCategoria = C.ID AND A.IdMarca = M.ID";
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IDMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregarconSP(Articulos art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_Agregar");
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@IdCategoria", art.Categoria.Id);
                datos.setearParametro("@IdMarca", art.Marca.Id);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@ImagenUrl", art.ImagenUrl);
                datos.setearParametro("@Stock", art.Stock);
                datos.ejecutarAccion();
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

        public Articulos obtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulos articulo = null;

            try
            {
                datos.setearConsulta("SELECT A.ID AS IDArticulo, A.Nombre, A.Descripcion, C.ID AS IDCategoria, C.Nombre AS Categoria, M.ID AS IDMarca, M.Nombre AS Marca, A.Precio, A.ImagenUrl, A.Disponible, A.Stock FROM Articulos A INNER JOIN Categoria C ON A.IdCategoria = C.ID INNER JOIN Marca M ON A.IdMarca = M.ID WHERE A.ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector != null && datos.Lector.Read())
                {
                    articulo = new Articulos();
                    articulo.IdArticulo = (int)datos.Lector["IDArticulo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IDMarca"];
                    articulo.Marca.Nombre = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    articulo.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    articulo.Precio = (float)(decimal)datos.Lector["Precio"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Stock = (int)datos.Lector["Stock"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return articulo;
        }

        public bool eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Articulos where ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                return true;
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
