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
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("Select ID, Usuario, Pass, Apellidos, Nombres, Nacimiento, Adm, ImagenUrl from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.User = (string)datos.Lector["Usuario"];
                    aux.Pass = (string)datos.Lector["Pass"];
                    if (!(datos.Lector["Apellidos"] is DBNull))
                    {
                        aux.Apellidos = (string)datos.Lector["Apellidos"];
                    }
                    if (!(datos.Lector["Nombres"] is DBNull))
                    {
                        aux.Nombres = (string)datos.Lector["Nombres"];
                    }
                    if (!(datos.Lector["Nacimiento"] is DBNull))
                    {
                        aux.FechaNacimiento = Convert.ToDateTime(datos.Lector["Nacimiento"]);
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
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
                datos.setearConsulta("UPDATE Usuarios SET Pass = @pass, Apellidos = @apellidos, Nombres = @nombres, ImagenUrl = @imagen, Nacimiento = @nacimiento WHERE ID = @id");
                datos.setearParametro("@pass", string.IsNullOrEmpty(user.Pass) ? (object)DBNull.Value : user.Pass);
                datos.setearParametro("@apellidos", string.IsNullOrEmpty(user.Apellidos) ? (object)DBNull.Value : user.Apellidos);
                datos.setearParametro("@nombres", string.IsNullOrEmpty(user.Nombres) ? (object)DBNull.Value : user.Nombres);
                datos.setearParametro("@imagen", string.IsNullOrEmpty(user.ImagenUrl) ? (object)DBNull.Value : user.ImagenUrl);
                datos.setearParametro("@nacimiento", user.FechaNacimiento == DateTime.MinValue ? (object)DBNull.Value : user.FechaNacimiento);
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
        public Usuario obtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = null;

            try
            {
                datos.setearConsulta("SELECT ID, Usuario, Pass, Apellidos, Nombres, Nacimiento, Adm, ImagenUrl FROM Usuarios WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.User = (string)datos.Lector["Usuario"];
                    usuario.Pass = (string)datos.Lector["Pass"];
                    usuario.Apellidos = datos.Lector["Apellidos"] == DBNull.Value ? string.Empty : (string)datos.Lector["Apellidos"];
                    usuario.Nombres = datos.Lector["Nombres"] == DBNull.Value ? string.Empty : (string)datos.Lector["Nombres"];
                    usuario.FechaNacimiento = datos.Lector["Nacimiento"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(datos.Lector["Nacimiento"]);
                    usuario.ImagenUrl = datos.Lector["ImagenUrl"] == DBNull.Value ? string.Empty : (string)datos.Lector["ImagenUrl"];
                    usuario.admin = (bool)datos.Lector["Adm"];
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

            return usuario;
        }

        public bool eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Usuarios where ID = @id");
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
