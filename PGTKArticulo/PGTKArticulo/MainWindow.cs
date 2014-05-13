using System;
using Gtk;
using Serpis.Ad;
using System.Data;
using MySql.Data.MySqlClient;
	public partial class MainWindow: Gtk.Window
	{
		private MySqlConnection mySqlConnection;
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			string connectionString="Server=localhost;" +
									"Database=dbrepaso;" +
									"User ID=root;" +
									"Password=sistemas";

			mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();

			MySqlCommand mySqlCommand= mySqlConnection.CreateCommand();
			mySqlCommand.CommandText= "select * from articulo";

			MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();

			for (int index=0; index<mySqlDataReader.FieldCount;index ++)
				treeView.AppendColumn(mySqlDataReader.GetName(index),new CellRendererText(),"text",index);

			int fieldCount = mySqlDataReader.FieldCount;

			ListStore listStore= createListStore(fieldCount);

			while(mySqlDataReader.Read()){

				string []line= new string[mySqlDataReader.FieldCount];
				for (int index=0; index< mySqlDataReader.FieldCount;index++){
						object value= mySqlDataReader.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);

				treeView.Model=listStore;

			}
		mySqlDataReader.Close();

		mySqlCommand.CommandText= "select * from articulo";

		refreshAction.Activated += delegate {

			listStore.Clear();
			MySqlDataReader mySqlDataReaderActualiza= mySqlCommand.ExecuteReader();

			fieldCount = mySqlDataReaderActualiza.FieldCount;

			listStore= createListStore(fieldCount);

			while(mySqlDataReaderActualiza.Read()){

				string []line= new string[mySqlDataReaderActualiza.FieldCount];
				for (int index=0; index< mySqlDataReaderActualiza.FieldCount;index++){
						object value= mySqlDataReaderActualiza.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);


				treeView.Model=listStore;


			}

			mySqlDataReaderActualiza.Close();
		};
	}
		private ListStore createListStore(int fieldCount){
			Type[] types = new Type[fieldCount];
			for (int index = 0; index < fieldCount; index++)
				types[index] = typeof(string);
				return new ListStore(types);
		}		
	
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;

			mySqlConnection.Close();

		}
	}