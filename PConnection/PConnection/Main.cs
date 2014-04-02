using System;
using MySql.Data.MySqlClient;

namespace Serpis.ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString="Server=localhost;" +
									"Database=dbrepaso;" +
									"User ID=root;" +
									"Password=sistemas";

			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();

			MySqlCommand mySqlCommand= mySqlConnection.CreateCommand();
			mySqlCommand.CommandText= "select * from categoria";

			MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();

			Console.WriteLine (string.Join(" ",dinamicGetColumNamess(mySqlDataReader)));
		

		while(mySqlDataReader.Read())

			mySqlDataReader.Close();
			mySqlConnection.Close ();

		}
	}
}
