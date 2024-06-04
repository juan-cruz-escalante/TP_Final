using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLLab3; database=TP_Final; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.ID,a.nombre, a.Descripcion,C.Nombre,T.Tamano,A.Precio, a.ImagenUrl, a.Disponible  from Articulos A inner join Categoria C On C.ID = A.IdCategoria inner join Tamano T On T.ID = A.IdCategoria";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)lector["ID"];

                    if (!(lector["Nombre"] is DBNull))
                        aux.Nombre = (string)lector["Nombre"];

                    if (!(lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)lector["Descripcion"];

                    aux.IdCategoria = (int)lector["IdCategoria"];
                    aux.Categoria = new Categoria();
                    if (!(lector["Categoria"] is DBNull))
                        aux.Categoria.DescripcionCategoria = (string)lector["Categoria"];

                    aux.IdTamanio = (int)lector["Tamano"];
                    aux.Categoria = new Categoria();
                    if (!(lector["Tamano"] is DBNull))
                        aux.Categoria.DescripcionCategoria = (string)lector["Tamano"];


                    if (!(lector["Precio"] is DBNull))
                        aux.Precio = (float)(decimal)lector["Precio"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}