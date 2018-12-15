using servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testlogin.datos;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace mapsAPI.Controllers
{
    public class GeoController : Controller
    {
        //meetfastEntitiesEvento context = new meetfastEntitiesEvento();
        EventoService context = new EventoService();
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
            try
            {
                var data = context.getEventos();
                string cadena = "{ 'Eventos':[";
                int contador = 0;
                foreach (var probando in data)
                {
                    contador++;
                    var nombre = probando.getNombre();
                    var latitud = probando.getLatitud();
                    var longitud = probando.getLongitud();
                    var descripcion = probando.getDescripcion();
                    var tematica = probando.getTematica();
                    string eventoNuevo = ("{'nombre': " + nombre + ";'latitud': '" + latitud + "';'longitud': '" + longitud + "';'descripcion': '" + descripcion + "';'tematica': '" + tematica + "'}");
                    if (contador < data.Count())
                    {
                        eventoNuevo += "/";
                    }
                    cadena += eventoNuevo;
                }
                cadena += "]}";
                var datos = Json(cadena, JsonRequestBehavior.AllowGet);
                //var datos = Json(data, JsonRequestBehavior.AllowGet);
                var js = new JavaScriptSerializer().Serialize(data);
                return datos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.TargetSite);
                throw;
            }
            
        }

    }
}