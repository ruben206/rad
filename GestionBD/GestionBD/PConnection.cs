using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace GestionBD
{
	public class PConnection
	{
		private MySqlConnectionStringBuilder con;
		
		public PConnection()
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

