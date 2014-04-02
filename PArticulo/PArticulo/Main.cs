using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;" +
									"Database=dbrepaso;" +
									"User ID=root;" +
									"Password=sistemas");
			mySqlConnection.Open ();
			
			MySqlCommand updateMySqlCommand = mySqlConnection.CreateCommand ();
			updateMySqlCommand.CommandText = "update articulo set nombre=:nombre where id=1";
			
			updateMySqlCommand.ExecuteNonQuery ();
			
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "Select * from articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
			while(mySqlDataReader.Read ()){
				Console.WriteLine("id={0} nombre={1}", mySqlDataReader["id"], mySqlDataReader["nombre"]);
			}
			mySqlDataReader.Close ();
			mySqlConnection.Close ();
		}
	}
}
