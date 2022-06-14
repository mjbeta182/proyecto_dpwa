using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_dpwa.Models
{
    public class ProductoModel
    {
        public int id {  get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string categoria { get; set; } // This should be a Category model
        public string[] images { get; set; }

        public ProductoModel(int id, string descripcion, double precio, string categoria, string[] images)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
            this.images = images;
        }
    }
}