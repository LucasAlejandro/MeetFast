using Infraestructura.Models;
using System.Collections.Generic;

namespace servicios.Interfaces.Servicios
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
        /// Busca eventos
        /// </summary>
        /// <returns>Lista de los eventos</returns>
        List<EventoModel> getEventos();

        /// <summary>
        /// Busca eventos con cierta tematica
        /// </summary>
        /// <returns>Lista de los eventos de la temática indicada</returns>
        List<EventoModel> eventosTematica(string tematica);

    }
}
