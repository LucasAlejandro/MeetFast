using MeetFastGit.Models;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IComentarioService
    {
        /// <summary>
        /// Añade un comentario
        /// </summary>
        /// <param name="comentario"></param>
        void addComentario(ComentarioModel comentario);

        /// <summary>
        /// Elimina un comentario
        /// </summary>
        /// <param name="comentario"></param>
        void removeComentario(ComentarioModel comentario);

        /// <summary>
        /// Edita un comentario
        /// </summary>
        /// <param name="comentario"></param>
        void editComentario(ComentarioModel comentario);

        /// <summary>
        /// Busca comentarios que contentan un texto determinada
        /// </summary>
        /// <param name="idEvento"></param>
        /// <param name="contenido"></param>
        /// <returns>Los comentarios de un evento que contentan una cadena determinada</returns>
        List<ComentarioModel> buscarComentarioContenido(long idEvento, string contenido);

        /// <summary>
        /// Busca comentarios por fecha
        /// </summary>
        /// <param name="idEvento"></param>
        /// <param name="fecha"></param>
        /// <returns>Los comentarios de un evento en una fecha determinada</returns>
        List<ComentarioModel> buscarComentarioFecha(long idEvento, DateTime fecha);

        /// <summary>
        /// Busca los comentarios de un usuario dado
        /// </summary>
        /// <param name="IdEvento"></param>
        /// <param name="id">ID del usuario</param>
        /// <returns>Los comentarios de un evento hechos por un usuario</returns>
        List<ComentarioModel> buscarComentarioUsuario(long IdEvento, long id);
    }
}
