using MySql.Data.MySqlClient;

namespace MeetFastGit.Controllers
{
    public class ConexionBD
    {
        /// <summary>
        /// Establece conexión con la base de datos
        /// </summary>
        MySqlConnection conectar = new MySqlConnection("Server=tcp:meetfast.database.windows.net,1433;Initial Catalog=meetfast;Persist Security Info=False;User ID={meetfast_admin@meetfast};Password={Carlos3proyecto};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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