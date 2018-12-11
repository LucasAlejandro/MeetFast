using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class HistoriaService : IHistoriaService
    {
        ConexionBD conexion = new ConexionBD();

        public void addHistoria(HistoriaModelo historia, long usuario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Historia (ID_Usu, Cotenido, hora) values ('{0}','{1}', '{2}')",
                usuario, historia.getContenido(), historia.getHora(), conexion.ObtenerConexion()));
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

        public void removeHistoria(HistoriaModelo historia, long usuario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Historia where ID_Usu ='{0}' and hora ='{1}'",
                usuario, historia.getHora(), conexion.ObtenerConexion()));
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

        public List<HistoriaModelo> todasHistorias(long usuario)
        {
            List<HistoriaModelo> listaHistorias = new List<HistoriaModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, Foto, ID FROM Usuario where ID_Usu EXISTS (Select Contenido, hora From Historia Where ID_Usuario ='{0}')", usuario, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    HistoriaModelo aux = new HistoriaModelo();
                    aux.setContenido(_reader.GetString(0));
                    aux.setHora(_reader.GetDateTime(1));
                    listaHistorias.Add(aux);
                }

                return listaHistorias;
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