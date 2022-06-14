using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_dpwa.Models
{
    public class CategoriaModel
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public CategoriaModel()
        {
        }

        public CategoriaModel(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}