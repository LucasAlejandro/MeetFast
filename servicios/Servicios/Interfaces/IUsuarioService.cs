using Infraestructura.Models;
using System.Collections.Generic;

namespace servicios.Interfaces.Servicios
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Añade un usuario a la bbdd
        /// </summary>
        /// <param name="usuario"></param>
        void addUsuario(UsuarioModelo usuario);

        /// <summary>
        /// Actualiza el telefono del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="telefono"></param>
        void updateTelefonoUsuario(long id, string telefono);

        /// <summary>
        /// Actualiza el nombre del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        void updateNombreUsuario(long id, string nombre);

        /// <summary>
        /// Elimina un usuario de la bbdd
        /// </summary>
        /// <param name="usuario"></param>
        void removeUsuario(UsuarioModelo usuario);

        /// <summary>
        /// Añade un amigo a la lista
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="amigo"></param>
        void addAmigo(long ID, UsuarioModelo amigo);

        /// <summary>
        /// Elimina un amigo de la lista
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="amigo"></param>
        void removeAmigo(long ID, UsuarioModelo amigo);

        /// <summary>
        /// Lista de amigos con un nombre determinado
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nombre"></param>
        /// <returns>Lista de amigos con el nombre indicado</returns>
        List<UsuarioModelo> todosAmigosNombre(long ID, string nombre);
    }
}
