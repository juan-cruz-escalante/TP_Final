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
                datos.setearConsulta("SELECT A.ID, A.Nombre, A.Descripcion, C.ID IDCategoria, C.Nombre Categoria, M.ID IDMarca, M.Nombre Marca, A.Precio, A.ImagenUrl, A.Disponible, A.Stock FROM Articulos A, Categoria C, Marca M WHERE A.IdCategoria = C.ID AND A.IdMarca = M.ID");
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
    }
}
