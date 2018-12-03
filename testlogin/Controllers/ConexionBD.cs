using MySql.Data.MySqlClient;

namespace MeetFastGit.Controllers
{
    public class ConexionBD
    {
        /// <summary>
        /// Establece conexión con la base de datos
        /// </summary>
        MySqlConnection conectar = new MySqlConnection("server=db4free.net; database=meetfast; Uid=meetfast_admin; pwd=Contraseña1;");
        public MySqlConnection ObtenerConexion()
        {
            conectar.Open();
            return conectar;
        }

        /// <summary>
        /// Cierra la conexión con la base de datos
        /// </summary>
        public void CerrarConexion()
        {
            conectar.Close();
        }
    }
}