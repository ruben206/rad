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
			updateMySqlCommand.CommandText = "UPDATE articulo SET nombre = @nombre WHERE ID = 1";
			MySqlParameter mySqlParameter = updateMySqlCommand.CreateParameter();
			mySqlParameter.ParameterName = "nombre";
			mySqlParameter.Value = DateTime.Now.ToString();
			updateMySqlCommand.Parameters.Add (mySqlParameter);
			
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
