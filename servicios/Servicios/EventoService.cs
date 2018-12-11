using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class EventoService : IEventoService
    {
        ConexionBD conexion = new ConexionBD();
        public void addAsistente(UsuarioModelo asistente, long IdEvento)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into EventoAsistencia (ID_Usu, ID_Evento) values ('{0}','{1}')",
                asistente.getID(), IdEvento, conexion.ObtenerConexion()));
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

        public void addEvento(EventoModel evento, long creador)
        {
            try
            {
                string visibilidad = "";
                if (evento.getPrivado())
                {
                    visibilidad = "Privado";
                }
                else
                {
                    visibilidad = "Publico";
                }
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Evento (FechaEvento, ID_Creador, TipoEvento, Visibilidad) values ('{0}','{1}', '{2}', '{3}')",
                evento.getFechaEvento(), creador, evento.getTematica(), visibilidad, conexion.ObtenerConexion()));
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

        public List<EventoModel> eventosCercanos(long latitud, long longitud, int distancia)
        {
            List<EventoModel> listaEventos = new List<EventoModel>();
            try
            {
                MySqlCommand BuscaUsuario = new MySqlCommand(String.Format(
                  "SELECT ID, ID_Creador, TipoEvento, FechaEvento, Nombre FROM Evento where latitud BETWEEN ('{0}'-'{2}') AND ('{0}'+'{2}') and longitud BETWEEN ('{1}'-'{2}') AND ('{1}'+'{2}') and Visibilidad ='Publico';", latitud, longitud, distancia, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaUsuario.ExecuteReader();

                while (_reader.Read())
                {
                    EventoModel aux = new EventoModel();
                    aux.setID(_reader.GetInt32(0));
                    aux.setCreador(_reader.GetInt32(1));
                    aux.setTematica(_reader.GetString(2));
                    aux.setFechaEvento(_reader.GetDateTime(3));
                    aux.setNombre(_reader.GetString(4));
                    listaEventos.Add(aux);
                }

                return listaEventos;
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

        public List<EventoModel> eventosTematica(long latitud, long longitud, string tematica, int distancia)
        {
            List<EventoModel> listaEventos = new List<EventoModel>();
            try
            {
                MySqlCommand BuscaUsuario = new MySqlCommand(String.Format(
                  "SELECT ID, ID_Creador, FechaEvento, Nombre FROM Evento where latitud BETWEEN ('{0}'-'{2}') AND ('{0}'+'{2}') and longitud BETWEEN ('{1}'-'{2}') AND ('{1}'+'{2}') and Visibilidad ='Publico' and TipoEvento ='{3}';", latitud, longitud, distancia, tematica, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaUsuario.ExecuteReader();

                while (_reader.Read())
                {
                    EventoModel aux = new EventoModel();
                    aux.setID(_reader.GetInt32(0));
                    aux.setCreador(_reader.GetInt32(1));
                    aux.setFechaEvento(_reader.GetDateTime(2));
                    aux.setNombre(_reader.GetString(3));
                    listaEventos.Add(aux);
                }

                return listaEventos;
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

        public void removeAsistente(UsuarioModelo asistente, long id)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from EventoAsistencia where ID_Usu ='{0}' and ID_Evento='{1}'",
                asistente.getID(), id, conexion.ObtenerConexion()));
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

        public void removeEvento(EventoModel evento)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Evento where ID ='{0}'",
                evento.getID(), conexion.ObtenerConexion()));
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

        public void updateDescripcion(EventoModel evento)
        {
            throw new NotImplementedException();
        }

        public void updateNombre(EventoModel evento)
        {
            throw new NotImplementedException();
        }

        public void updateUbicacion(EventoModel evento)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Evento SET Latitud = '{0}', Longitud ='{1}' WHERE ID == '{2}';)",
                evento.getLatitud(), evento.getLongitud(), evento.getID(), conexion.ObtenerConexion()));
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

        public void updateVisibilidad(EventoModel evento)
        {
            try
            {
                string visibilidad = "";
                if (evento.getPrivado())
                {
                    visibilidad = "Privado";
                }
                else
                {
                    visibilidad = "Publico";
                }

                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Evento SET Visibilidad = '{0}' WHERE ID == '{1}';)",
                visibilidad, evento.getID(), conexion.ObtenerConexion()));
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

        public void updateFecha(EventoModel evento)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Evento SET FechaEvento = '{0}' WHERE ID == '{1}';)",
                 evento.getFechaEvento(), evento.getID(), conexion.ObtenerConexion()));
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

        public void updateTematica(EventoModel evento)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Evento SET TipoEvento = '{0}' WHERE ID == '{1}';)",
                 evento.getTematica(), evento.getID(), conexion.ObtenerConexion()));
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