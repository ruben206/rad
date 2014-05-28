using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace GestionBD
{
	public class PConexion
	{
		//La clase PConexion la utilizaremos para la conexion a la base de datos
		//definiendo la ip de servidor, nombre usuario, nombre de BD y la contraseña
		private MySqlConnectionStringBuilder con;
		
		public PConexion()
		{
			con = new MySqlConnectionStringBuilder();
		}
		public string BuildConnection(){
			con.Server = "localhost";
			con.UserID = "root";
			con.Database = "clientes";
			con.Password = "sistemas";
			
			return con.ConnectionString;
		}
	}
}
