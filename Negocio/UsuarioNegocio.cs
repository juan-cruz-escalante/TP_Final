using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Usuario, Pass, TipoUsuario from Usuarios Where Usuario = @user AND Pass = @pass");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["ID"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 1 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
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
