using MeetFastGit.Models;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IInteresService
    {
        /// <summary>
        /// Añade un interes a la bbdd
        /// </summary>
        /// <param name="interes"></param>
        void addInteres(InteresModelo interes);

        /// <summary>
        /// Actualiza un interes de la bbdd
        /// </summary>
        /// <param name="interes"></param>
        void updateInteres(InteresModelo interes);

        /// <summary>
        /// Devuelve todos los intereses de un determinado tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        List<InteresModelo> todosInteresTipo(string tipo);

        /// <summary>
        /// Busca un interés por el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Lista de intereses con un determinado nombre</returns>
        List<InteresModelo> interesNombre(string nombre);

        /// <summary>
        /// Elimina un interes de la bbdd
        /// </summary>
        /// <param name="interes"></param>
        void deleteInteres(InteresModelo interes);

        /// <summary>
        /// Busca todos los tipos de interes
        /// </summary>
        /// <returns>Lista de todos los tipos de intereses</returns>
        List<string> todosTipos();
    }
}
