using servicios.Servicios;
using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testlogin.Models;

namespace testlogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            meetfastEntities2 db = new meetfastEntities2();
            List<TipoEvento> list = db.TipoEvento.ToList();
            ViewBag.TipoEventoLista = new SelectList(list, "Id", "Nombre");
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
        public ActionResult GuardarEvento(Models.EventoInsert model)
        {

            try
            {
                meetfastEntities2 db = new meetfastEntities2();
                Evento evento = new Evento();

                // evento.Id = 12;
                evento.Lat = (model.Lat);
                evento.Long = model.Long;
                evento.Name = model.Name;
                evento.Descripcion = model.Descripcion;
                //por defecto 3 probando
                evento.Creador = 3;
                evento.TipoEvento = model.TipoEvento;
                evento.Fecha_Evento = model.Fecha_Evento;
                Console.WriteLine(evento);
                db.Evento.Add(evento);
                db.SaveChanges();
                ;
            }

            catch (Exception ex)
            {
                throw ex;

            }


            return RedirectToAction("Index");
        }

    }
}