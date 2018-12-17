using servicios.Servicios;
using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace testlogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexMeet()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        EventoService context = new EventoService();
        public ActionResult InsertarEvento(EventoModel evento)
        {
            Console.WriteLine(evento.ToString());
            context.addEvento(evento,1);

            return RedirectToAction("Contact");
        }

    }
}