using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto_dpwa.Models;

namespace proyecto_dpwa.Controllers
{
    public class ProductosController : Controller
    {

        proyecto_dpwaEntities contexto = new proyecto_dpwaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            return View();
        }

        public ActionResult GetProductosPorCategoria()
        {
            ProductoRepository productoRepository = new ProductoRepository();
            string categoria = Request.QueryString["nombre"];
            List<ProductoModel> productos = productoRepository.findByCategoryName(categoria);

            return Json(new { productos }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductos()
        {
            ProductoRepository productsRepository = new ProductoRepository();
            List<ProductoModel> productos = productsRepository.findAll();
            
            return Json(new { productos }, JsonRequestBehavior.AllowGet);
        }
       





    }
}