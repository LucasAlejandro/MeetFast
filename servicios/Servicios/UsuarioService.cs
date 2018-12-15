using MeetFastGit.Controllers;
using Infraestructura.Models;
using servicios.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace servicios.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        ConexionBD conexion = new ConexionBD();
        public void addAmigo(long ID, UsuarioModelo amigo)
        {
            try
            {
                var con = conexion.ObtenerConexion();

                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("Insert Into Amigo (IdUsuario, IdAmigo) Values('{0}', '{1}')", ID, amigo.getID());
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
        
        public void addUsuario(UsuarioModelo usuario)
        {
            try
            {
                var con = conexion.ObtenerConexion();

                SqlCommand query = con.CreateCommand();
                SqlCommand queryCorreo = con.CreateCommand();
                query.CommandType = CommandType.Text;

                if(usuario.getTelefono() is null)
                {
                    query.CommandText = string.Format("Insert into Usuario (NombreUsuario, Contraseña, Email) values ('{0}','{1}','{2}')", usuario.getNombre(), usuario.getContraseña(), usuario.getEmail());
                    query.ExecuteNonQuery();
                }
                else
                {
                    query.CommandText = string.Format("Insert into Usuario (NombreUsuario, Contraseña, Email, Telefono) values ('{0}','{1}','{2}','{3}')", usuario.getNombre(), usuario.getContraseña(), usuario.getEmail(), usuario.getTelefono());
                    query.ExecuteNonQuery();
                }


            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        

        public void removeAmigo(long ID, UsuarioModelo amigo)
        {
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("Delete From Amigo Where (IdUsuario = '{0}' or IdUsuario = '{1}') and (IdAmigo = '{1}' or IdAmigo = '{0}'))", ID, amigo.getID());
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

        public void removeUsuario(UsuarioModelo usuario)
        {
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand comando = con.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = string.Format("delete from Usuario where ID_Usu = '{0}'", usuario.getID());
                comando.ExecuteNonQuery();
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

        public List<UsuarioModelo> todosAmigos(UsuarioModelo usu, long ID)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                SqlCommand queryAux = con.CreateCommand();
                query.CommandType = CommandType.Text;
                queryAux.CommandType = CommandType.Text;
                query.CommandText = string.Format("Select Distintc IdUsuario From Amigo Where(IdUsuario = '{0}' or IdUsuario = '{1}') and(IdAmigo = '{1}' or IdAmigo = '{0}')", ID, usu.getID());
                var _reader = query.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo amigo = new UsuarioModelo();
                    queryAux.CommandText = string.Format("Select Id, NombreUsuario From Usuario Where Id = '{0}'", _reader.GetInt32(0));
                    var _readerAux = queryAux.ExecuteReader();
                    _readerAux.Read();
                    amigo.setID(_readerAux.GetInt32(0));
                    amigo.setNombre(_readerAux.GetString(1));
                    listaAmigos.Add(amigo);
                }            

                return listaAmigos;
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

        public List<UsuarioModelo> todosAmigosEvento(long id_usu, long idEvento)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                SqlCommand queryAux = con.CreateCommand();
                query.CommandType = CommandType.Text;
                queryAux.CommandType = CommandType.Text;
                query.CommandText = string.Format("Select IdUsuario, IdAmigo From Amigo Where IdUsuario = '{0}' or IdAmigo = '{0}')", id_usu);
                var _reader = query.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo amigo = new UsuarioModelo();
                    queryAux.CommandText = string.Format("Select IdUsuario From EventoUsuario Where (IdUsuario = '{0}' ir IdUsuario = '{1}') and IdEvento = '{2}'", _reader.GetInt32(0), _reader.GetInt32(1), idEvento);
                    var _readerAux = queryAux.ExecuteReader();
                    _readerAux.Read();
                    amigo.setID(_readerAux.GetInt32(0));
                    amigo.setNombre(_readerAux.GetString(1));
                    listaAmigos.Add(amigo);
                }

                return listaAmigos;
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

        public List<UsuarioModelo> todosAmigosNombre(long ID, string nombre)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("SELECT Id, NombreUsuario, FROM Usuario  where Id EXISTS (Select ID_Amigo From UsuarioAmigo Where ID_Usu ='{0}') or " +
                  "(Select ID_Usu From UsuarioAmigo Where ID_Amigo ='{0}') and NombreUsuario LIKE('%{1}%')", ID, nombre);
                var _reader = query.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    
                    aux.setNombre(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(0)); ;
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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
        
        public void updateTelefonoUsuario(long id, string telefono)
        {
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("UPDATE Usuario SET Telefono = '{0}' WHERE Id = '{1}')", telefono, id);

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

        public void updateNombreUsuario(long id, string nombre)
        {
            try
            {
                var con = conexion.ObtenerConexion();
                SqlCommand query = con.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = string.Format("UPDATE Usuario SET NombreUsuario = '{0}' WHERE Id = '{1}')", nombre, id);

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