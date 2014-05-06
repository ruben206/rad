using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Serpis.ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			PConexion mySqlConnection = new PConexion();
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
			
//			MySqlCommand deletemySqlCommand = new MySqlCommand("DELETE FROM articulo WHERE ID = 1");
//			MySqlDataAdapter delete = new MySqlDataAdapter();
//			delete.DeleteCommand = deletemySqlCommand;
//			delete.DeleteCommand.ExecuteNonQuery();
			
			mySqlDataReader.Close ();
			mySqlConnection.Close ();
			
			
			//Arreglar el Delete y hacer un metodo para que 
			//funcionen los parametros sin tener que declararlos, tambien hacer un metodo para la conexion.
			//Proyecto nuevo con GTK PGTKArticulo -> Realizaremos lo mismo que en PArticulo pero visualizando 
			//la base de datos en una rejilla.(listStore,treview)
	
		}
	}
}
