using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Serpis.ad
{
	public class PConexion
	{
		public PConexion ()
		{
			MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;" +
									"Database=dbrepaso;" +
									"User ID=root;" +
									"Password=sistemas");
		}
	}
}

