using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            List<Tipo> lista = new List<Tipo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Select ID, IdCategoria, Tipo from Tipo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IdTipo = (int)datos.Lector["ID"];
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.DescripcionTipo = (string)datos.Lector["Tipo"];

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