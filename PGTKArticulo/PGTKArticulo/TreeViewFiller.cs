using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	public class TreeViewFiller
	{
		public static void Fill (TreeView treeView, IDbConnection dbConnection, string selectText){
//			IDbCommand.CommandText= "select * from articulo";
//
//			IDataReader dataReader= mySqlCommand.ExecuteReader();
//			
//			
//			for (int index=0; index<mySqlDataReader.FieldCount;index ++)
//				treeView.AppendColumn(mySqlDataReader.GetName(index),new CellRendererText(),"text",index);
//
//			int fieldCount = mySqlDataReader.FieldCount;
//
//			ListStore listStore= createListStore(fieldCount);
//
//			while(mySqlDataReader.Read()){
//
//				string []line= new string[mySqlDataReader.FieldCount];
//				for (int index=0; index< mySqlDataReader.FieldCount;index++){
//						object value= mySqlDataReader.GetValue(index);
//						line[index]=value.ToString();			
//						}
//
//				listStore.AppendValues(line);
//
//				treeView.Model=listStore;
//			}
//			mySqlDataReader.Close();
//			mySqlCommand.CommandText= "select * from articulo";
//		
//		}
//		static ListStore createListStore(int fieldCount){
//			Type[] types = new Type[fieldCount];
//			for (int index = 0; index < fieldCount; index++)
//				types[index] = typeof(string);
//				return new ListStore(types);
//		}		
	}
}

}