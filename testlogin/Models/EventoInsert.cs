using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testlogin.Models
{
    public class EventoInsert
    {



        public int TipoEvento { get; set; }



        public double Lat { get; set; }
        public double Long { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }

        public Nullable<System.DateTime> Fecha_Evento { get; set; }
        public int Creador { get; set; }

    }
}