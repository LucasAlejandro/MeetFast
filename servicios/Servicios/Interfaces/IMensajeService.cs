using MeetFastGit.Models;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IMensajeService
    {
        /// <summary>
        /// Añade un mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        void addMensaje(MensajeModel mensaje);

        /// <summary>
        /// Elimina un mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        void removeMensaje(MensajeModel mensaje);

        /// <summary>
        /// Busca todos los mensajes con un determinado usuario
        /// </summary>
        /// <param name="ID">Emisor</param>
        /// <param name="usuario">Receptor</param>
        /// <returns>Lista de mensajes con un usuario</returns>
        List<MensajeModel> todosMensajesConUsuario(long ID, long usuario);

        /// <summary>
        /// Busca todos los mensajes con un determinado usuario en una fecha concreta
        /// </summary>
        /// <param name="ID">Emisor</param>
        /// <param name="usuario">Receptor</param>
        /// <param name="fecha"></param>
        /// <returns>Lista de mensajes con un usuario en una fecha determinada</returns>
        List<MensajeModel> todosMensajesConUsuarioFecha(long ID, long usuario, DateTime fecha);

        /// <summary>
        /// Busca los mensajes que contengan una determinada cadena
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="contenido"></param>
        /// <returns>Lista de mensajes que contenga una cadena determinada</returns>
        List<MensajeModel> buscarMensajeContenido(long ID, string contenido);

        /// <summary>
        /// Busca los mensajes con un usuario con una determinada cadena
        /// </summary>
        /// <param name="ID">Emisor</param>
        /// <param name="usuario">Receptor</param>
        /// <param name="contenido"></param>
        /// <returns>Lista de mensajes con un usuario que contenga una cadena determinada</returns>
        List<MensajeModel> buscaMensajesContenidoUsuario(long ID, long usuario, string contenido);
    }
}
