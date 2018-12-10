using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testlogin.datos;

namespace mapsAPI.Controllers
{
    public class GeoController : Controller
    {
        meetfastEntitiesEvento context = new meetfastEntitiesEvento();
        // GET: Geo
        public ActionResult InfoWindow()
        {
            return View();
        }
        public ActionResult InfoWindow_bbdd()
        {
            return View();
        }
        public ActionResult Autocomplete()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GeoCoder()
        {
            return View();
        }
        public ActionResult MarkerCluster()
        {
            return View();
        }

        public JsonResult GetAllLocation() {
            var data = context.Evento.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}