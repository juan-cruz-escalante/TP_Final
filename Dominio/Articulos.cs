using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulos
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdTamanio { get; set; }
        public Tamano Tamanio { get; set; }
        public string ImagenUrl { get; set; }
        public float Precio { get; set; }
        public bool Disponible { get; set; }
    }
}
