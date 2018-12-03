using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetFastGit.Models
{
    public class MensajeModel
    {
        private long id_Emisor;
        private long id_Receptor;
        private DateTime fecha;
        private string mensaje;

        public MensajeModel()
        {

        }

        public MensajeModel(long idEmisor, long idReceptor, DateTime fecha, string mensaje)
        {
            this.id_Emisor = idEmisor;
            this.id_Receptor = idReceptor;
            this.fecha = fecha;
            this.mensaje = mensaje;
        }

        public void setEmisor(long id)
        {
            this.id_Emisor = id;
        }

        public void setReceptor(long id)
        {
            this.id_Receptor = id;
        }

        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }

        public void setMensaje(string mensaje)
        {
            this.mensaje = mensaje;
        }

        public long getEmisor()
        {
            return id_Emisor;
        }

        public long getReceptor()
        {
            return id_Receptor;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public string getMensaje()
        {
            return mensaje;
        }

    }
}