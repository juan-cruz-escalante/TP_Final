using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenUrl { get; set; }
        public bool admin { get; set; }

        public Usuario(string user, string pass) 
        { 
            User = user; 
            Pass = pass;
            Nombres = "Sin datos";
            Apellidos = "Sin datos";
            this.FechaNacimiento = DateTime.MinValue;
            ImagenUrl = "Sin imagen";
        }
        public Usuario()
        {

        }

    }
}
