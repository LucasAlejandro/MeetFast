using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models
{
    public class EventoModel
    {
        private long id;
        public string tematica;
        private bool privado;
        //private DateTime fechaCreacion;
        public DateTime fechaEvento;
        public float latitud;
        public float longitud;
        //private List<ComentarioModel> comentarios;
        //private List<UsuarioModelo> asistentes;
        private long idCreador;
        public string nombre;
        public string descripcion;

        public EventoModel(string nombre, string tematica, bool privado, DateTime fCreacion, DateTime fEvento, float latitud, float longitud, long idCreador)
        {
            this.nombre = nombre;
            this.tematica = tematica;
            this.privado = privado;
            //this.fechaCreacion = fCreacion;
            this.fechaEvento = fEvento;
            this.latitud = latitud;
            this.idCreador = idCreador;
            this.longitud = longitud;
        }

        public EventoModel()
        {

        }

        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string getDescripcion()
        {
            return this.descripcion;
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

        public void setLatitud(float latitud)
        {
            this.latitud = latitud;
        }

        public void setLongitud(float longitud)
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

        //public void setFechaCreacion(DateTime FCreacion)
        //{
        //    this.fechaCreacion = FCreacion;
        //}

        public void setFechaEvento(DateTime FEvento)
        {
            this.fechaEvento = FEvento;
        }

        //public void setComentarios(List<ComentarioModel> comentarios)
        //{
        //    this.comentarios = comentarios;
        //}

        //public void setAsistentes(List<UsuarioModelo> asistentes)
        //{
        //    this.asistentes = asistentes;
        //}

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

        //public DateTime getFechaCreacion()
        //{
        //    return this.fechaCreacion;
        //}

        public DateTime getFechaEvento()
        {
            return this.fechaEvento;
        }

        public float getLatitud()
        {
            return this.latitud;
        }

        public float getLongitud()
        {
            return this.longitud;
        }

        //public List<ComentarioModel> getComentarios()
        //{
        //    return this.comentarios;
        //}

        //public List<UsuarioModelo> getAsistentes()
        //{
        //    return this.asistentes;
        //}

        //public void añadirComentario(ComentarioModel comentario)
        //{
        //    this.comentarios.Add(comentario);
        //}

        //public void añadirAsistente(UsuarioModelo asistente)
        //{
        //    this.asistentes.Add(asistente);
        //}

        public string getNombre()
        {
            return this.nombre;
        }

    }
}
