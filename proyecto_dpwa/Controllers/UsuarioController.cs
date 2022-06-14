using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto_dpwa.Models;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace proyecto_dpwa.Controllers
{
    public class UsuarioController : Controller
    {
        proyecto_dpwaEntities contexto = new proyecto_dpwaEntities();

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsuario(usuario objUser)
        {

            List<usuario> data = contexto.usuario.ToList();
            {

                var obj = data.Where(a => a.nombre_usuario.Equals(objUser.nombre_usuario) && a.pass.Equals(objUser.pass)).FirstOrDefault();
                if (obj != null)
                {
                    Session["id"] = obj.id.ToString();
                    Session["nombre"] = obj.nombre.ToString();
                    Session["nombre_usuario"] = obj.nombre_usuario.ToString();
                    Session["pass"] = obj.pass.ToString();
                    Session["rol"] = obj.rol.ToString();
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return View(objUser);
        }

        [HttpPost]
        public ActionResult RegistroUsuario(usuario model)
        {
            
                    // Add data to the particular table
                    contexto.usuario.Add(model);
                    // save the changes
                    contexto.SaveChanges();
                    // display the message
                    return Json(new { success = true, message = "Registro Finalizado.Proceda a Iniciar Sesión", JsonRequestBehavior.AllowGet });
            
            //return Json(new { success = false, message = "Ingrese datos Validos" }); 
        }

        public ActionResult IniciarSesion()
        {
           
            return View();
         
        }

        public ActionResult Index()
        {
            return View();
        }
    }
   
   
}