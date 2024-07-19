using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, Usuario, Pass, TipoUsuario, Apellidos, Nombres, Nacimiento, Adm, ImagenUrl from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.User = (string)datos.Lector["Usuario"];
                    aux.Pass = (string)datos.Lector["Pass"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["Nacimiento"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.admin = (bool)datos.Lector["Adm"];

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

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, Nombres, Apellidos, ImagenUrl, Nacimiento, Adm from Usuarios Where usuario = @user and pass = @pass");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = Convert.ToInt32(datos.Lector["ID"]);
                    usuario.admin = Convert.ToBoolean(datos.Lector["Adm"]);
                    usuario.Apellidos = datos.Lector["Apellidos"] == DBNull.Value ? string.Empty : Convert.ToString(datos.Lector["Apellidos"]);
                    usuario.Nombres = datos.Lector["Nombres"] == DBNull.Value ? string.Empty : Convert.ToString(datos.Lector["Nombres"]);
                    usuario.ImagenUrl = datos.Lector["ImagenUrl"] == DBNull.Value ? string.Empty : Convert.ToString(datos.Lector["ImagenUrl"]);

                    if (!(datos.Lector["Nacimiento"] is DBNull))
                    {
                        usuario.FechaNacimiento = DateTime.Parse(datos.Lector["Nacimiento"].ToString());
                    }
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@user", nuevo.User);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
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

        public void Actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Apellidos = @apellidos, Nombres = @nombres, ImagenUrl, @nacimiento = Nacimiento = @imagen WHERE ID = @id");
                datos.setearParametro("@apellidos", user.Apellidos);
                datos.setearParametro("@nombres", user.Nombres);
                datos.setearParametro("@imagen", user.ImagenUrl);
                datos.setearParametro("@nacimiento", user.FechaNacimiento);
                datos.setearParametro("@id", user.Id);

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
