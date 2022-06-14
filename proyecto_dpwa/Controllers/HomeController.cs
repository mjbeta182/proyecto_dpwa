using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_dpwa.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult DeleteLogin()
        {
           
            return View();
        }

        public ActionResult RecuperarContra()
        {
            return View();
        }

        public ActionResult Carrito()
        {
            return View();
        }
        public ActionResult RptProductos()
        {  
            return View();
        }
        public ActionResult VerRptProductos()
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/RptProductos.rpt");
            //conexion para el reporte
            var coninfo = new ConnectionInfo { ServerName = "DESKTOP-A07QJG6", DatabaseName = "proyecto_dpwa", IntegratedSecurity = true };
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            Tables tables;
            tables = reporte.Database.Tables;
            foreach (Table item in tables)
            {
                logoninfo = item.LogOnInfo;
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream =
            reporte.ExportToStream(ExportFormatType.PortableDocFormat);
            return new FileStreamResult(stream, "application/pdf");
        }

        public ActionResult RptProductosCategoria()
        {
            return View();
        }

        public ActionResult VerRptProductosCategoria(string parametro)
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/rptProductosCategoria.rpt");
            //ESTABLECIENDO UN PARAMETRO AL REPORTE
            reporte.SetParameterValue("paramCategorias", parametro);
            //conexion para el reporte
            var coninfo = new ConnectionInfo { ServerName = "DESKTOP-A07QJG6", DatabaseName = "neptuno", IntegratedSecurity = true };
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            Tables tables;
            tables = reporte.Database.Tables;
            foreach (Table item in tables)
            {
                logoninfo = item.LogOnInfo;
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream =
            reporte.ExportToStream(ExportFormatType.PortableDocFormat);
            return new FileStreamResult(stream, "application/pdf");

        }

    }
}