using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MeetFastGit.Servicios
{
    public class EventoService : IEventoService
    {
        ConexionBD conexion = new ConexionBD();
        public void addAsistente(UsuarioModelo asistente, long IdEvento)
        {
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();

                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("Insert into UsuarioEvento (IdUsuario, IdEvento) Values('{0}', '{1}')", asistente.getID(), IdEvento);
                query.ExecuteNonQuery();

            }
            catch (SqlException e)
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


                var con = conexion.ObtenerConexion();

                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;

                query.CommandText = string.Format("Insert into Evento (TipoEvento, Lat, Long, Name, Descripcion, Fecha_Evento, Visibilidad, Creador) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                    evento.getTematica(), evento.getLatitud(), evento.getLongitud(), evento.getNombre(), evento.getDescripcion(), evento.getFechaEvento(), visibilidad, creador );
                query.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<EventoModel> getEventos()
        {
            List<EventoModel> listaEventos = new List<EventoModel>();
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;

                query.CommandText = string.Format("Select * From eventos Where Fecha_Evento < Now()");
                var _reader = query.ExecuteReader();
                while (_reader.Read())
                {
                    EventoModel aux = new EventoModel();
                    aux.setID(_reader.GetInt32(0));
                        SqlCommand queryTematica = new SqlCommand();
                        queryTematica.CommandType = CommandType.Text;
                        queryTematica.CommandText = string.Format("Select Nombre From TipoEvento Where Id ='{1}'", _reader.GetInt16(1));
                        var _readerTematica = queryTematica.ExecuteReader();
                        _readerTematica.Read();
                    aux.setTematica(_readerTematica.GetString(0));
                    aux.setLatitud((long)_reader.GetFloat(2));
                    aux.setLongitud((long)_reader.GetFloat(3));
                    aux.setNombre(_reader.GetString(4));
                    aux.setDescripcion(_reader.GetString(5));
                    aux.setFechaCreacion(_reader.GetDateTime(6));
                    aux.setFechaEvento(_reader.GetDateTime(7));
                    aux.setPrivado(_reader.GetString(8) == "Publico" ? false : true);
                    aux.setCreador(_reader.GetInt32(9));
                    listaEventos.Add(aux);
                }

                return listaEventos;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<EventoModel> eventosTematica(string tematica)
        {
            List<EventoModel> listaEventos = new List<EventoModel>();
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;

                    SqlCommand queryTematica = new SqlCommand();
                    queryTematica.CommandType = CommandType.Text;

                    queryTematica.CommandText = string.Format("Select Id From TipoEvento Where Nombre = '{0}'", tematica);
                    var _readerTematica = queryTematica.ExecuteReader();
                    _readerTematica.Read();


                query.CommandText = string.Format("Select * From eventos Where Fecha_Evento < Now() and TipoEvento = '{0}'", _readerTematica.GetInt32(0));
                var _reader = query.ExecuteReader();
                while (_reader.Read())
                {
                    EventoModel aux = new EventoModel();
                    aux.setID(_reader.GetInt32(0));
                    aux.setTematica(tematica);
                    aux.setLatitud((long)_reader.GetFloat(2));
                    aux.setLongitud((long)_reader.GetFloat(3));
                    aux.setNombre(_reader.GetString(4));
                    aux.setDescripcion(_reader.GetString(5));
                    aux.setFechaCreacion(_reader.GetDateTime(6));
                    aux.setFechaEvento(_reader.GetDateTime(7));
                    aux.setPrivado(_reader.GetString(8) == "Publico" ? false : true);
                    aux.setCreador(_reader.GetInt32(9));
                    listaEventos.Add(aux);
                }

                return listaEventos;
            }
            catch (SqlException e)
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
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format(("delete from Usuario where IdUsuario ='{0}' and IdEvento='{1}'"), asistente.getID(), id);
                query.ExecuteNonQuery();
            }
            catch (SqlException e)
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
                var con = conexion.ObtenerConexion();

                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;

                query.CommandText = string.Format("Delete from Evento where Id ='{0}'",
                evento.getID());

                query.ExecuteNonQuery();

            }
            catch (SqlException e)
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