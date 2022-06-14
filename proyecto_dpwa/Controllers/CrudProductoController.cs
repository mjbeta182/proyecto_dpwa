using proyecto_dpwa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_dpwa.Controllers
{
    public class CrudProductoController : Controller
    {
        proyecto_dpwaEntities contexto = new proyecto_dpwaEntities();
        struct producto_str
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public Nullable<decimal> precio { get; set; }
            public Nullable<int> categoria_id { get; set; }
            public string imagenes { get; set; }
            public categoria categoria { get; set; }
        }
        // GET: CrudProducto

        [HttpGet]
        public JsonResult GetTabla()
        {
            List<producto> data = contexto.producto.Include("categoria").ToList();
            List<producto_str> data2 = new List<producto_str>();
            foreach (producto item in data)
            {
                producto_str temp = new producto_str();
                temp.id = item.id;
                temp.descripcion = item.descripcion;
                temp.precio = item.precio;
                temp.categoria_id = item.categoria_id;
                temp.imagenes = item.imagenes;
                data2.Add(temp);
            }

            return Json(new { resultado = data2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertarProductos(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);
                file.SaveAs(physicalPath);
                // save the changes
                contexto.SaveChanges();
                producto p = new producto();
                p.descripcion = Request.Form["descripcion"];
                p.precio = decimal.Parse(Request.Form["precio"]);
                p.categoria_id = int.Parse(Request.Form["categoria_id"]);
                p.imagenes = ImageName;
                contexto.producto.Add(p);
                contexto.SaveChanges();

            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult EliminarProductos(producto p)
        {
            try
            {
                contexto.producto.Remove(contexto.producto.FirstOrDefault(x => x.id == p.id));
                contexto.SaveChanges();
                return Json("Registro Eliminado");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult ModificarProductos(HttpPostedFileBase file,producto p)
        {
            try
            {
                if (file != null)
                {
                    producto temporal = contexto.producto.FirstOrDefault(x => x.id == p.id);
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/images/" + ImageName);
                    file.SaveAs(physicalPath);
                    temporal.descripcion = p.descripcion;
                    temporal.precio = p.precio;
                    temporal.categoria_id = p.categoria_id;
                    temporal.imagenes = ImageName;
                    contexto.SaveChanges();
                }
                return Json("Registro Modificado");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Index()
        {
            //para llenar el dropdownlist del formulario
            ViewBag.categoria = contexto.categoria.Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.id.ToString()
            });

            return View();

        }
    }
}