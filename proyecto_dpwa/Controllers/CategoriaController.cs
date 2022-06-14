using proyecto_dpwa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_dpwa.Controllers
{
    public class CategoriaController : Controller
    {
        proyecto_dpwaEntities contexto = new proyecto_dpwaEntities();
        public JsonResult GetCategoria()
        {
            var categoria = contexto.categoria.Select(x => x.nombre).ToList();
            categoria.Sort();
            return Json(new { resultado = categoria }, JsonRequestBehavior.AllowGet);
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }
    }
}