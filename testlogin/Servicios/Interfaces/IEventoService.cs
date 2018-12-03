using MeetFastGit.Models;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IEventoService
    {
        /// <summary>
        /// Añade un evento
        /// </summary>
        /// <param name="evento"></param>
        /// <param name="creador">ID del creador del evento</param>
        void addEvento(EventoModel evento, long creador);

        /// <summary>
        /// Actualiza la descripción de un evento
        /// </summary>
        /// <param name="evento"></param>
        void updateDescripcion(EventoModel evento);

        /// <summary>
        /// Actualiza el nombre del evento
        /// </summary>
        /// <param name="evento"></param>
        void updateNombre(EventoModel evento);

        /// <summary>
        /// Actualiza la ubicación del evento
        /// </summary>
        /// <param name="evento"></param>
        void updateUbicacion(EventoModel evento);
        
        /// <summary>
        /// Actualiza la visibilidad del evento
        /// </summary>
        /// <param name="evento"></param>
        void updateVisibilidad(EventoModel evento);

        /// <summary>
        /// Actualiza la fecha en la que tendrá lugar el evento
        /// </summary>
        /// <param name="evento"></param>
        void updateFecha(EventoModel evento);

        /// <summary>
        /// Actualiza la temática del evento
        /// </summary>
        /// <param name="evento"></param>
        void updateTematica(EventoModel evento);

        /// <summary>
        /// Elimina un evento
        /// </summary>
        /// <param name="evento"></param>
        void removeEvento(EventoModel evento);

        /// <summary>
        /// Añade un asistente
        /// </summary>
        /// <param name="asistente"></param>
        /// <param name="IdEvento"></param>
        void addAsistente(UsuarioModelo asistente, long IdEvento);

        /// <summary>
        /// Elimina un asistente
        /// </summary>
        /// <param name="asistente"></param>
        /// <param name="id"></param>
        void removeAsistente(UsuarioModelo asistente, long id);

        /// <summary>
        /// Busca eventos cercanos
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="distancia"></param>
        /// <returns>Lista de los eventos a la distancia indicada</returns>
        List<EventoModel> eventosCercanos(long latitud, long longitud, int distancia);

        /// <summary>
        /// Busca eventos cercanos con cierta tematica
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="tematica"></param>
        /// <param name="distancia"></param>
        /// <returns>Lista de los eventos de la temática indicada en la distancia indicada</returns>
        List<EventoModel> eventosTematica(long latitud, long longitud, string tematica, int distancia);

    }
}
