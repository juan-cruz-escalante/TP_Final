using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class PersonaNegocio
    {
        public List<Persona> listar()
        {
            List<Persona> lista = new List<Persona>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select P.Apellidos, P.Nombres, P.Nacimiento, P.Celular, P.Domicilio, P.Localidad, P.Pais, P.Adm From Persona P inner join Usuarios U On U.ID = P.ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.IdCategoria = (int)datos.Lector["ID"];
                    aux.DescripcionCategoria = (string)datos.Lector["Nombre"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["Nacimiento"];
                    aux.Celular = (string)datos.Lector["Celular"];
                    aux.Domicilio = (string)datos.Lector["Domicilio"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Pais = (string)datos.Lector["Pais"];
                    aux.Adm = (bool)datos.Lector["Adm"];

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
