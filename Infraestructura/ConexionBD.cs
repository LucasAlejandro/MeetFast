﻿using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MeetFastGit.Controllers
{
    public class ConexionBD
    {
        SqlConnection con = new SqlConnection("Server=tcp:meetfast.database.windows.net,1433;Initial Catalog=meetfast;Persist Security Info=False;User ID={meetfast_admin@meetfast};Password={Carlos3proyecto};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        public SqlConnection ObtenerConexion()
        {
            con.Open();
            return con;
        }

        public void CerrarConexion()
        {
            con.Close();
        }
        /*
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
        */
    }
}