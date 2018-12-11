using MeetFastGit.Models;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IHistoriaService
    {
        /// <summary>
        /// Añade una historia
        /// </summary>
        /// <param name="historia"></param>
        /// <param name="usuario"></param>
        void addHistoria(HistoriaModelo historia, long usuario);

        /// <summary>
        /// Elimina una historia
        /// </summary>
        /// <param name="historia"></param>
        /// <param name="usuario"></param>
        void removeHistoria(HistoriaModelo historia, long usuario);

        /// <summary>
        /// Busca todas las historias
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Las historias de un usuario</returns>
        List<HistoriaModelo> todasHistorias(long usuario);
    }
}
