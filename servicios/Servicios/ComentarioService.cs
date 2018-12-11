using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class ComentarioService : IComentarioService
    {
        ConexionBD conexion = new ConexionBD();
        public void addComentario(ComentarioModel comentario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Comentario (ID_Evento, ID_Usu, Fecha, Contenido) values ('{0}','{1}', '{2}', '{3}')",
                comentario.getIdUsuario(), comentario.getIdEvento(), comentario.getFecha(), comentario.getContenido(), conexion.ObtenerConexion()));
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<ComentarioModel> buscarComentarioContenido(long idEvento, string contenido)
        {
            List<ComentarioModel> listaComentarios = new List<ComentarioModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Contenido, Fecha, ID_Usuario FROM Comentario where ID_Evento ='{0}' and Contenido LIKE('%{1}%')", idEvento, contenido, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    ComentarioModel aux = new ComentarioModel();
                    aux.setContenido(_reader.GetString(0));
                    aux.setFecha(_reader.GetDateTime(1));
                    aux.setIdUsuario(_reader.GetInt32(2));
                    listaComentarios.Add(aux);
                }

                return listaComentarios;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<ComentarioModel> buscarComentarioFecha(long idEvento, DateTime fecha)
        {
            List<ComentarioModel> listaComentarios = new List<ComentarioModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Contenido, ID_Usuario FROM Comentario where ID_Evento ='{0}' and fecha ='{1}'", idEvento, fecha, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    ComentarioModel aux = new ComentarioModel();
                    aux.setContenido(_reader.GetString(0));
                    aux.setFecha(fecha);
                    aux.setIdUsuario(_reader.GetInt32(1));
                    listaComentarios.Add(aux);
                }

                return listaComentarios;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<ComentarioModel> buscarComentarioUsuario(long IdEvento, long id)
        {
            List<ComentarioModel> listaComentarios = new List<ComentarioModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Contenido, fecha FROM Comentario where ID_Evento ='{0}' and ID_Usu ='{1}'", IdEvento, id, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    ComentarioModel aux = new ComentarioModel();
                    aux.setContenido(_reader.GetString(0));
                    aux.setFecha(_reader.GetDateTime(1));
                    listaComentarios.Add(aux);
                }

                return listaComentarios;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        public void editComentario(ComentarioModel comentario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Comentario SET Contenido = '{0}' WHERE ID_Usu ='{1}' and ID_Evento ='{2}' and fecha ='{3}';",
                comentario.getContenido(), comentario.getIdUsuario(), comentario.getIdEvento(), comentario.getFecha(), conexion.ObtenerConexion()));
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void removeComentario(ComentarioModel comentario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Contenido WHERE ID_Usu ='{0}' and ID_Evento ='{1}' and fecha ='{2}' and Contenido ='{3}'",
                comentario.getIdUsuario(), comentario.getIdEvento(), comentario.getFecha(), comentario.getContenido(), conexion.ObtenerConexion()));
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}