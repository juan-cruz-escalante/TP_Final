using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class TamanoNegocio
    {
        public List<Tamano> listar()
        {
            List<Tamano> lista = new List<Tamano>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, Tamano from Tamano");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tamano aux = new Tamano();
                    aux.IdTamanio = (int)datos.Lector["ID"];
                    aux.Tamanio = (string)datos.Lector["Tamano"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
