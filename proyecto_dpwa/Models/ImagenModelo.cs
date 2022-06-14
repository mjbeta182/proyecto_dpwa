using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_dpwa.Models
{
    public class ImagenModelo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int producto_id { get; set; }
    }
}