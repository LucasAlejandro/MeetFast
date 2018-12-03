using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class MensajeService : IMensajeService
    {
        ConexionBD conexion = new ConexionBD();
        public void addMensaje(MensajeModel mensaje)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Mensaje (ID_Emisor, ID_Receptor, Texto) values ('{0}','{1}','{2}')",
                mensaje.getEmisor(), mensaje.getReceptor(), mensaje.getMensaje(), conexion.ObtenerConexion()));
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

        public List<MensajeModel> buscaMensajesContenidoUsuario(long ID, long usuario, string contenido)
        {
            List<MensajeModel> listaMesajes = new List<MensajeModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Fecha, Texto FROM Mensaje where ID_Emisor='{0}' and Texto like ='%{1}%' and ID_Receptor ='{2}'", ID, contenido, usuario, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    MensajeModel aux = new MensajeModel();
                    aux.setReceptor(usuario);
                    aux.setFecha(_reader.GetDateTime(0));
                    aux.setMensaje(_reader.GetString(1));
                    aux.setEmisor(ID);
                    listaMesajes.Add(aux);
                }

                return listaMesajes;
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

        public List<MensajeModel> buscarMensajeContenido(long ID, string contenido)
        {
            List<MensajeModel> listaMesajes = new List<MensajeModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT ID_Receptor, Fecha, Texto FROM Mensaje where ID_Emisor='{0}' and Texto like ='%{1}%'", ID, contenido, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    MensajeModel aux = new MensajeModel();
                    aux.setReceptor(_reader.GetInt32(0));
                    aux.setFecha(_reader.GetDateTime(1));
                    aux.setMensaje(_reader.GetString(2));
                    aux.setEmisor(ID);
                    listaMesajes.Add(aux);
                }

                return listaMesajes;
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

        public void removeMensaje(MensajeModel mensaje)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Mensaje where ID_Emisor ='{0}' and ID_Receptor ='{1}' and Fecha ='{2}' and Texto ='{3}' ",
                mensaje.getEmisor(), mensaje.getReceptor(), mensaje.getFecha(), mensaje.getMensaje(), conexion.ObtenerConexion()));
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

        public List<MensajeModel> todosMensajesConUsuario(long ID, long usuario)
        {
            List<MensajeModel> listaMesajes = new List<MensajeModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Fecha, Texto FROM Mensaje where ID_Emisor='{0}' and ID_Receptor ='{1}'", ID, usuario, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    MensajeModel aux = new MensajeModel();
                    aux.setReceptor(usuario);
                    aux.setFecha(_reader.GetDateTime(0));
                    aux.setMensaje(_reader.GetString(1));
                    aux.setEmisor(ID);
                    listaMesajes.Add(aux);
                }

                return listaMesajes;
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

        public List<MensajeModel> todosMensajesConUsuarioFecha(long ID, long usuario, DateTime fecha)
        {
            List<MensajeModel> listaMesajes = new List<MensajeModel>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Texto FROM Mensaje where ID_Emisor='{0}' and ID_Receptor ='{1}' and Fecha ='{2}'", ID, usuario, fecha, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    MensajeModel aux = new MensajeModel();
                    aux.setReceptor(usuario);
                    aux.setFecha(fecha);
                    aux.setMensaje(_reader.GetString(0));
                    aux.setEmisor(ID);
                    listaMesajes.Add(aux);
                }

                return listaMesajes;
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
    }
}