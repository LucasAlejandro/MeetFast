using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetFastGit.Models;

namespace MeetFastGit.Models
{
    public class EventoModel
    {
        private long id;
        private string tematica;
        private bool privado;
        private DateTime fechaCreacion;
        private DateTime fechaEvento;
        private long latitud;
        private long longitud;
        private List<ComentarioModel> comentarios;
        private List<UsuarioModelo> asistentes;
        private long idCreador;
        private string nombre;
        
        public EventoModel(string nombre, string tematica, bool privado, DateTime fCreacion, DateTime fEvento, long latitud, long longitud, long idCreador)
        {
            this.nombre = nombre;
            this.tematica = tematica;
            this.privado = privado;
            this.fechaCreacion = fCreacion;
            this.fechaEvento = fEvento;
            this.latitud = latitud;
            this.idCreador = idCreador;
            this.longitud = longitud;
        }

        public EventoModel()
        {

        }

        public void setID(long id)
        {
            this.id = id;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void setCreador(long id)
        {
            this.idCreador = id;
        }

        public void setLatitud(long latitud)
        {
            this.latitud = latitud;
        }

        public void setLongitud(long longitud)
        {
            this.longitud = longitud;
        }
        public void setTematica(string tematica)
        {
            this.tematica = tematica;
        }

        public void setPrivado(bool privado)
        {
            this.privado = privado;
        }

        public void setFechaCreacion(DateTime FCreacion)
        {
            this.fechaCreacion = FCreacion;
        }

        public void setFechaEvento(DateTime FEvento)
        {
            this.fechaCreacion = FEvento;
        }

        public void setComentarios(List<ComentarioModel> comentarios)
        {
            this.comentarios = comentarios;
        }

        public void setAsistentes(List<UsuarioModelo> asistentes)
        {
            this.asistentes = asistentes;
        }

        public long getID()
        {
            return this.id;
        }

        public string getTematica()
        {
            return this.tematica;
        }

        public bool getPrivado()
        {
            return this.privado;
        }

        public DateTime getFechaCreacion()
        {
            return this.fechaCreacion;
        }

        public DateTime getFechaEvento()
        {
            return this.fechaEvento;
        }

        public long getLatitud()
        {
            return this.latitud;
        }

        public long getLongitud()
        {
            return this.longitud;
        }

        public List<ComentarioModel> getComentarios()
        {
            return this.comentarios;
        }

        public List<UsuarioModelo> getAsistentes()
        {
            return this.asistentes;
        }

        public void añadirComentario(ComentarioModel comentario)
        {
            this.comentarios.Add(comentario);
        }

        public void añadirAsistente(UsuarioModelo asistente)
        {
            this.asistentes.Add(asistente);
        }

        public string getNombre()
        {
            return this.nombre;
        }
        
    }
}