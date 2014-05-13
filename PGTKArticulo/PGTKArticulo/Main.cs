using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionstring = "Server=localhost;" +
									"Database=dbrepaso;" +
									"User ID=root;" +
									"Password=sistemas";
			App.Instance.DbConnection = new MySqlConnection(connectionstring);
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			
			App.Instance.DbConnection.Close();
		}
	}
}
