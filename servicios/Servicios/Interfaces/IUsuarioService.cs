using MeetFastGit.Models;
using System.Collections.Generic;

namespace MeetFastGit.Servicios.Interfaces
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Añade un usuario a la bbdd
        /// </summary>
        /// <param name="usuario"></param>
        void addUsuario(UsuarioModelo usuario);

        /// <summary>
        /// Actualiza la foto de una usuario en la bbdd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fotoUI"></param>
        void updateFotoUsuario(long id, string fotoUI);

        /// <summary>
        /// Actualiza la contraseña del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contraseña"></param>
        void updateContraseñaUsuario(long id, string contraseña);

        /// <summary>
        /// Actualiza la localidad del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="localidad"></param>
        void updateLocalidadUsuario(long id, string localidad);

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
        /// Lista de todos los usuarios
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
        List<UsuarioModelo> todosUsuarios();

        /// <summary>
        /// Lista de los usuarios de determinado rango de edad
        /// </summary>
        /// <param name="edadMinima"></param>
        /// <param name="edadMaxima"></param>
        /// <returns>Lista de los usuarios comprendidos entre dos edades</returns>
        List<UsuarioModelo> todosUsuariosEdad(int edadMinima, int? edadMaxima);

        /// <summary>
        /// Busca usuarios que tengan unos intereses determinados
        /// </summary>
        /// <param name="interes"></param>
        /// <returns>Lista de los usuarios que tengan al menos un interés de la lista</returns>
        List<UsuarioModelo> todosUsuariosInteres(List<InteresModelo> interes);

        /// <summary>
        /// Busca usuarios en una determinada localidad
        /// </summary>
        /// <param name="localidad"></param>
        /// <returns>Lista de los usuarios de una localidad</returns>
        List<UsuarioModelo> todosUsuariosLocalidad(string localidad);

        /// <summary>
        /// Lista de usuarios asistentes a un evento determinado
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns>Lista de los usuarios asistentes a una evento</returns>
        List<UsuarioModelo> todosUsuariosEvento(long idEvento);

        /// <summary>
        /// Lista de amigos completa
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Lista de amigos</returns>
        List<UsuarioModelo> todosAmigos(long ID);

        /// <summary>
        /// Lista de amigos por rango de edad
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="edadMinima"></param>
        /// <param name="edadMaxima"></param>
        /// <returns>Lista de amigos comprendidos entre dos edades</returns>
        List<UsuarioModelo> todosAmigosEdad(long ID, int edadMinima, int? edadMaxima);

        /// <summary>
        /// Lista de amigos en una localidad concreta
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="localidad"></param>
        /// <returns>Lista de amigos residentes en una localidad</returns>
        List<UsuarioModelo> todosAmigosLocalidad(long ID, string localidad);

        /// <summary>
        /// Lista de amigos que asisten a un evento determinado
        /// </summary>
        /// <param name="id_usu"></param>
        /// <param name="idEvento"></param>
        /// <returns>Lista de amigos asistentes al evento</returns>
        List<UsuarioModelo> todosAmigosEvento(long id_usu, long idEvento);

        /// <summary>
        /// Lista de amigos con un nombre determinado
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nombre"></param>
        /// <returns>Lista de amigos con el nombre indicado</returns>
        List<UsuarioModelo> todosAmigosNombre(long ID, string nombre);
    }
}
