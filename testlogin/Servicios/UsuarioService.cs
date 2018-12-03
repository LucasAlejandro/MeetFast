using MeetFastGit.Controllers;
using MeetFastGit.Models;
using MeetFastGit.Servicios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MeetFastGit.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        ConexionBD conexion = new ConexionBD();
        public void addAmigo(long ID, UsuarioModelo amigo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into UsuarioAmigo (ID_Usu, ID_Amigo) values ('{0}','{1}')",
                ID, amigo.getID(), conexion.ObtenerConexion()));
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

        public void addUsuario(UsuarioModelo usuario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into Usuario (Nombre, contraseña, FechaNacimiento, Foto, localidad, telefono) values ('{0}','{1}','{2}', '{3}', '{4}', '{5}')",
                usuario.getNombre(), usuario.getContraseña(), usuario.getFechaDeNacimiento(), usuario.getFotoUI(), usuario.getLocalidad(), usuario.getTelefono(), conexion.ObtenerConexion()));

                MySqlCommand BuscaID = new MySqlCommand(String.Format(
                  "SELECT MAX(ID) FROM Usuario", conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaID.ExecuteReader();

                _reader.Read();
                usuario.setID(_reader.GetInt32(0));

                MySqlCommand comandoEmail = new MySqlCommand(string.Format("Insert into UsuarioEmail (email, ID) values ('{0}','{1}')",
                    usuario.getEmail(), usuario.getID(), conexion.ObtenerConexion()));
                comando.ExecuteNonQuery();
                comandoEmail.ExecuteNonQuery();
            }
            catch(MySqlException e)
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
                MySqlCommand comando = new MySqlCommand(string.Format("delete from UsuarioAmigo where ID_Usu ='{0}' and ID_Amigo ='{1}",
                ID, amigo.getID(), conexion.ObtenerConexion()));
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

        public void removeUsuario(UsuarioModelo usuario)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("delete from Usuario where ID_Usu ='{0}'",
                usuario.getID(), conexion.ObtenerConexion()));
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

        public List<UsuarioModelo> todosAmigos(long ID)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, Foto, ID FROM Usuario where ID_Usu EXISTS (Select ID_Amigo From UsuarioAmigo Where ID_Usuario ='{0}')", ID, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read()) { 
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2));
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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
            
        public List<UsuarioModelo> todosAmigosEdad(long ID, int edadMinima, int? edadMaxima)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo;
                if(edadMaxima != null)
                {
                    BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, FotoUI, ID FROM Usuario where ID EXISTS (Select ID_Amigo From UsuarioAmigo Where ID_Usu ='{0}') and FechaNacimiento>(NOW()-'{1}') and FechaNacimiento<(NOW()-'{2}') ", ID, edadMinima, edadMaxima, conexion.ObtenerConexion()));
                }
                else
                {
                    BuscaAmigo = new MySqlCommand(String.Format(
                 "SELECT Nombre, FotoUI, ID FROM Usuario where ID EXISTS (Select ID_Amigo From UsuarioAmigo Where ID_Usu ='{0}') and FechaNacimiento>(NOW()-'{1}') ", ID, edadMinima, conexion.ObtenerConexion()));
                }
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2));
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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

        public List<UsuarioModelo> todosAmigosEvento(long id_usu, long idEvento)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT ID, Nombre, Foto FROM Usuario  where Usuario.ID EXISTS (Select ID_Amigo FROM UsuarioAmigo wherer UsuarioAmigo.ID_Usu ='{0}') and ID EXISTS (Select ID_Usu from EventoAsistencia where ID_Evento ='{1}')", id_usu, idEvento, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setID(_reader.GetInt32(0));
                    aux.setNombre(_reader.GetString(1));
                    aux.setFotoUI(_reader.GetString(2));
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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
        public List<UsuarioModelo> todosAmigosLocalidad(long ID, string localidad)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, Foto, ID FROM Usuario where ID_Usu EXISTS(Select ID_Amigo From UsuarioAmigo Where ID_Usu ='{0}') and localidad ='{1}'", ID, localidad, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2));
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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

        public List<UsuarioModelo> todosAmigosNombre(long ID, string nombre)
        {
            List<UsuarioModelo> listaAmigos = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, Foto, ID FROM Usuario  where ID EXISTS (Select ID_Amigo From UsuarioAmigo Where ID_Usu ='{0}') and Nombre LIKE('%{1}%')", ID, nombre, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2)); ;
                    listaAmigos.Add(aux);
                }

                return listaAmigos;
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

        public List<UsuarioModelo> todosUsuarios()
        {
            List<UsuarioModelo> listaUsuaios = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo = new MySqlCommand(String.Format(
                  "SELECT Nombre, Foto, ID FROM Usuario", conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2)); ;
                    listaUsuaios.Add(aux);
                }

                return listaUsuaios;
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

        public List<UsuarioModelo> todosUsuariosEdad(int edadMinima, int? edadMaxima)
        {
            List<UsuarioModelo> listaUsuarios = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaAmigo;
                if (edadMaxima!=null)
                {
                   BuscaAmigo = new MySqlCommand(String.Format(
                 "SELECT Nombre, Foto, ID FROM Usuario Where FechaNacimiento>(NOW()-'{0}') and FechaNacimiento<(NOW()-'{1}')", edadMinima, edadMaxima, conexion.ObtenerConexion()));                   
                }
                else
                {
                    BuscaAmigo = new MySqlCommand(String.Format(
                 "SELECT Nombre, Foto, ID FROM Usuario Where FechaNacimiento>(NOW()-'{0}'))",edadMinima, conexion.ObtenerConexion()));                   
                }

                MySqlDataReader _reader = BuscaAmigo.ExecuteReader();
                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setNombre(_reader.GetString(0));
                    aux.setFotoUI(_reader.GetString(1));
                    aux.setID(_reader.GetInt32(2)); ;
                    listaUsuarios.Add(aux);
                }

                return listaUsuarios;
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

        public List<UsuarioModelo> todosUsuariosEvento(long idEvento)
        {
            List<UsuarioModelo> listaUsuarios = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaUsuario = new MySqlCommand(String.Format(
                  "SELECT ID, Nombre, Foto FROM Usuario where Usuario.ID EXISTS (Select ID_Usu FROM EventoAsistencia where ID_Evento ='{0}')", idEvento, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaUsuario.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setID(_reader.GetInt32(0));
                    aux.setNombre(_reader.GetString(1));
                    aux.setFotoUI(_reader.GetString(2));
                    listaUsuarios.Add(aux);
                }

                return listaUsuarios;
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

        public List<UsuarioModelo> todosUsuariosInteres(List<InteresModelo> interes)
        {
            List<UsuarioModelo> listaUsuarios = new List<UsuarioModelo>();
            try
            {
                string interesTipo = "";
                MySqlCommand BuscaUsuario;
                bool unico = true;
                foreach (var item in interes)
                {
                    interesTipo = item.getTipo();
                    BuscaUsuario = new MySqlCommand(String.Format(
                  "SELECT ID, Nombre, Foto FROM Usuario where Usuario.ID EXISTS (Select ID_Usu FROM UsuarioInteres where ID_Interes ='{0}')", interesTipo, conexion.ObtenerConexion()));
                    MySqlDataReader _reader = BuscaUsuario.ExecuteReader();
                    while (_reader.Read())
                    {
                        foreach (var ids in listaUsuarios)
                        {
                            if(ids.getID() == _reader.GetInt32(0))
                            {
                                unico = false;
                                break;
                            }
                        }
                        if (unico)
                        {
                            UsuarioModelo aux = new UsuarioModelo();
                            aux.setID(_reader.GetInt32(0));
                            aux.setNombre(_reader.GetString(1));
                            aux.setFotoUI(_reader.GetString(2));
                            listaUsuarios.Add(aux);
                        }
                        unico = true;   
                    }
                }

                return listaUsuarios;
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

        public List<UsuarioModelo> todosUsuariosLocalidad(string localidad)
        {
            List<UsuarioModelo> listaUsuarios = new List<UsuarioModelo>();
            try
            {
                MySqlCommand BuscaUsuario = new MySqlCommand(String.Format(
                  "SELECT ID, Nombre, Foto FROM Usuario where localidad ='{0}'", localidad, conexion.ObtenerConexion()));
                MySqlDataReader _reader = BuscaUsuario.ExecuteReader();

                while (_reader.Read())
                {
                    UsuarioModelo aux = new UsuarioModelo();
                    aux.setID(_reader.GetInt32(0));
                    aux.setNombre(_reader.GetString(1));
                    aux.setFotoUI(_reader.GetString(2));
                    listaUsuarios.Add(aux);
                }

                return listaUsuarios;
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

        public void updateFotoUsuario(long id, string fotoUI)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Usuario SET Foto = '{0}' WHERE ID_Usu == '{1}';)",
                fotoUI, id, conexion.ObtenerConexion()));
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

        public void updateContraseñaUsuario(long id, string contraseña)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Usuario SET contraseña = '{0}' WHERE ID_Usu == '{1}';)",
                contraseña, id, conexion.ObtenerConexion()));
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

        public void updateLocalidadUsuario(long id, string localidad)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Usuario SET localidad = '{0}' WHERE ID_Usu == '{1}';)",
                localidad, id, conexion.ObtenerConexion()));
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

        public void updateTelefonoUsuario(long id, string telefono)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Usuario SET telefono = '{0}' WHERE ID_Usu == '{1}';)",
                telefono, id, conexion.ObtenerConexion()));
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

        public void updateNombreUsuario(long id, string nombre)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("UPDATE Usuario SET Nombre = '{0}' WHERE ID_Usu == '{1}';)",
                nombre, id, conexion.ObtenerConexion()));
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