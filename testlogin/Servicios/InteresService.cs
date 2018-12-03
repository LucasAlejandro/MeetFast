using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class InteresService : IInteresService
    {
        ConexionBD conexion = new ConexionBD();
        public void addInteres(InteresModelo interes)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Interes (Nombre, Tipo) values ('{0}','{1}')",
                interes.getNombre(), interes.getTipo(), conexion.ObtenerConexion()));
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

        public void deleteInteres(InteresModelo interes)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Interes where ID ='{0}'",
                interes.getID(), conexion.ObtenerConexion()));
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

        public List<InteresModelo> interesNombre(string nombre)
        {
            List<InteresModelo> listaIntereses = new List<InteresModelo>();
            try
            {
                MySqlCommand BuscaInteres = new MySqlCommand(String.Format(
                  "SELECT Nombre, Tipo, ID FROM Interes where Nombre LIKE('%{0}%')", nombre, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaInteres.ExecuteReader();

                while (_reader.Read())
                {
                    InteresModelo aux = new InteresModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setTipo(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2));
                    listaIntereses.Add(aux);
                }

                return listaIntereses;
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

        public List<InteresModelo> todosInteresTipo(string tipo)
        {
            List<InteresModelo> listaIntereses = new List<InteresModelo>();
            try
            {
                MySqlCommand BuscaInteres = new MySqlCommand(String.Format(
                  "SELECT Nombre, ID FROM Interes where Tipo ='{0}'", tipo, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaInteres.ExecuteReader();

                while (_reader.Read())
                {
                    InteresModelo aux = new InteresModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setID(_reader.GetInt32(1));
                    aux.setTipo(tipo);
                    listaIntereses.Add(aux);
                }

                return listaIntereses;
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

        public List<string> todosTipos()
        {
            List<string> listaTipos = new List<string>();
            try
            {
                MySqlCommand BuscaInteres = new MySqlCommand(String.Format(
                  "SELECT DISTINCT Tipo FROM Interes", conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaInteres.ExecuteReader();

                while (_reader.Read())
                { 
                    listaTipos.Add(_reader.GetString(0));
                }

                return listaTipos;
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

        public void updateInteres(InteresModelo interes)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Interes SET Nombre ='{0}', Tipo = '{1}' WHERE ID == '{2}';",
                interes.getNombre(), interes.getTipo(), interes.getID(), conexion.ObtenerConexion()));
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