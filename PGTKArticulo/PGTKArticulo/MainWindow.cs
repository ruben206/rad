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
		
			IDbCommand selectDbCommand= App.Instance.DbConnection.CreateCommand();
			selectDbCommand.CommandText= "select * from articulo";

			IDataReader dataReader= selectDbCommand.ExecuteReader();

			for (int index=0; index<dataReader.FieldCount;index ++)
				treeView.AppendColumn(dataReader.GetName(index),new CellRendererText(),"text",index);

			int fieldCount = dataReader.FieldCount;

			ListStore listStore= createListStore(fieldCount);

			while(dataReader.Read()){

				string []line= new string[dataReader.FieldCount];
				for (int index=0; index< dataReader.FieldCount;index++){
						object value= dataReader.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);

				treeView.Model=listStore;
			
				

			}
		dataReader.Close();

		selectDbCommand.CommandText= "select * from articulo";
		
		editAction.Sensitive=false;
		deleteAction.Sensitive=false;
		
		treeView.Selection.Changed += delegate 

			{
				editAction.Sensitive= treeView.Selection.CountSelectedRows()>0;
				deleteAction.Sensitive= treeView.Selection.CountSelectedRows()>0;
			};
		
		addAction.Activated += delegate {
			VentanaAñadir añadir = new VentanaAñadir();
			añadir.Show();
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
			IDataReader dataReaderActualiza= selectDbCommand.ExecuteReader();

			fieldCount = dataReaderActualiza.FieldCount;

			listStore= createListStore(fieldCount);

			while(dataReaderActualiza.Read()){

				string []line= new string[dataReaderActualiza.FieldCount];
				for (int index=0; index< dataReaderActualiza.FieldCount;index++){
						object value= dataReaderActualiza.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);


				treeView.Model=listStore;


			}

			dataReaderActualiza.Close();
		};
	}	
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;

			mySqlConnection.Close();

		}
	}