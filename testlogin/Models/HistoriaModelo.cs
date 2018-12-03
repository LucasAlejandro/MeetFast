using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetFastGit.Models
{
    public class HistoriaModelo
    {
        private DateTime hora;
        private string contenido;

        public HistoriaModelo(DateTime hora, string contenido)
        {
            this.hora = hora;
            this.contenido = contenido;
        }

        public HistoriaModelo()
        {

        }

        public void setHora(DateTime hora)
        {
            this.hora = hora;
        }

        public void setContenido(string contenido)
        {
            this.contenido = contenido;
        }

        public DateTime getHora()
        {
            return hora;
        }

        public string getContenido()
        {
            return contenido;
        }
    }
}