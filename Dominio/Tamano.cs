﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tamano
    {
        public int IdTamanio { get; set; }
        public string Tamanio { get; set; }
        public override string ToString()
        {
            return Tamanio;
        }
    }
}
