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
		
		editAction.Sensitive=false;
		deleteAction.Sensitive=false;
		
		treeView.Selection.Changed += delegate 

			{
				editAction.Sensitive= treeView.Selection.CountSelectedRows()>0;
				deleteAction.Sensitive= treeView.Selection.CountSelectedRows()>0;
			};

		editAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			object nombre = listStore.GetValue (treeIter, 1);

			MessageDialog messageDialog = new MessageDialog(this,
                DialogFlags.DestroyWithParent,
                MessageType.Info,
                ButtonsType.Ok,
                "Seleccionado Id={0} Nombre={1}", id, nombre);
			messageDialog.Title = "Editar";
			messageDialog.Run ();
			messageDialog.Destroy ();
		};
		
		deleteAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);

			MessageDialog messageDialog = new MessageDialog(this,
                DialogFlags.DestroyWithParent,
                MessageType.Question,
                ButtonsType.YesNo,
                "¿Quieres eliminar el elemento seleccionado?");
			messageDialog.Title = "Eliminar elemento";
			ResponseType response = (ResponseType)messageDialog.Run ();
			messageDialog.Destroy ();
			if (response == ResponseType.Yes ) {
				MySqlCommand deleteMySqlCommand = mySqlConnection.CreateCommand();
				deleteMySqlCommand.CommandText = "delete from articulo where id=" + id;
				deleteMySqlCommand.ExecuteNonQuery();
			}
		};
		
		
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