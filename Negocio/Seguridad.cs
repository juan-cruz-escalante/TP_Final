using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuario aux = user != null ? (Usuario)user : null;
            if (aux != null && aux.Id != 0)
                return true;
            else 
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario aux = user != null ? (Usuario)user : null;
            return aux.admin;
        }
    }
}
