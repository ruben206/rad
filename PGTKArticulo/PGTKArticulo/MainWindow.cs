using System;
using Gtk;
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




			// CREACION DE LOS APENDICES DE LA TABLA
			for (int index=0; index<mySqlDataReader.FieldCount;index ++)
				TreeView.AppendColumn(mySqlDataReader.GetName(index),new CellRendererText(),"text",index);



			//CREACION DEL MODELO DE DATOS DE LA TABLA
			int fieldCount = mySqlDataReader.FieldCount;

			ListStore listStore= createListStore(fieldCount);


			//INSERCION DE LOS DATOS DENTRO DEL MODELO
			while(mySqlDataReader.Read()){

				string []line= new string[mySqlDataReader.FieldCount];
				for (int index=0; index< mySqlDataReader.FieldCount;index++){
						object value= mySqlDataReader.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);

				//INSERCION DEL MODELO EN LA TABLA(TREEVIEW)
				treeview.Model=listStore;

			}
		mySqlDataReader.Close();
		editAction.Sensitive=false;
		deleteAction.Sensitive=false;
		addAction.Sensitive=false;

		mySqlCommand.CommandText= "select * from articulo";

		treeview.Selection.Changed += delegate 

			{
				editAction.Sensitive= treeview.Selection.CountSelectedRows()>0;
				deleteAction.Sensitive= treeview.Selection.CountSelectedRows()>0;
				addAction.Sensitive=treeview.Selection.CountSelectedRows()>0;
			};

			editAction.Activated += delegate {
			String mensaje;


			//CON ESTA CONDICION PROTEJO EL EVENTO EN CASO DE QUE SE ACTIVARA EL BOTON Y NO HUBIESE NADA SELECCIONADO	
			if (treeview.Selection.CountSelectedRows()==0)
				return;


			TreeIter treeIter;
			if(treeview.Selection.GetSelected(out treeIter)){
				String[] linea = new String[fieldCount];	
				for (int index=0; index< fieldCount;index++)		
					linea[index]=listStore.GetValue(treeIter,index).ToString();

			 mensaje= string.Join("  ", linea);
			}

			MessageDialog md = new MessageDialog (this,DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, mensaje);

			md.Run ();
			md.Destroy();
				};

			deleteAction.Activated += delegate {

				if(treeview.Selection.CountSelectedRows()==0)
					return;
				TreeIter treeIter;
				treeview.Selection.GetSelected(out treeIter);
				object id = listStore.GetValue(treeIter,0).ToString();
				Console.WriteLine(id);

				MySqlCommand mySqlCommandDelete= mySqlConnection.CreateCommand();
				mySqlCommandDelete.CommandText= "delete from articulo where id='"+id+"'";

				MessageDialog md = new MessageDialog (this, 
                                      	DialogFlags.DestroyWithParent,
	                              		MessageType.Question, 
                                      	ButtonsType.YesNo, "¿Estas seguro de eliminarlo?");
				ResponseType result = (ResponseType)md.Run ();

				if (result == ResponseType.Yes){
					mySqlCommandDelete.ExecuteNonQuery();
					md.Destroy();

				}
				else
					md.Destroy();

				};


			addAction.Activated += delegate {

				if(treeview.Selection.CountSelectedRows()==0)
					return;

			};
		refreshAction.Activated += delegate {

			listStore.Clear();
			MySqlDataReader mySqlDataReaderActualiza= mySqlCommand.ExecuteReader();

			//CREACION DEL MODELO DE DATOS DE LA TABLA
			fieldCount = mySqlDataReaderActualiza.FieldCount;

			listStore= createListStore(fieldCount);

			//INSERCION DE LOS DATOS DENTRO DEL MODELO
			while(mySqlDataReaderActualiza.Read()){

				string []line= new string[mySqlDataReaderActualiza.FieldCount];
				for (int index=0; index< mySqlDataReaderActualiza.FieldCount;index++){
						object value= mySqlDataReaderActualiza.GetValue(index);
						line[index]=value.ToString();			
						}

				listStore.AppendValues(line);

				//INSERCION DEL MODELO EN LA TABLA(TREEVIEW)
				treeview.Model=listStore;


			}

			mySqlDataReaderActualiza.Close();
		};




			// CREACION DE UN EVENTO PARA TREEVIEW (INDICA EN CONSOLA EN QUE CELDA NOS ENCONTRAMOS)
//			treeview.Selection.Changed += delegate {
//	
//				TreeIter treeIter;
//				if(treeview.Selection.GetSelected(out treeIter)){
//				
//					Console.WriteLine("path= "+listStore.GetPath(treeIter));
//					Console.WriteLine(listStore.GetValue(treeIter,0));
//					Console.WriteLine(listStore.GetValue(treeIter,1));
//				}else
//					Console.WriteLine("fuera de rango");
//				};
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