using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using GestionBD;

public partial class MainWindow: Gtk.Window
{	
	//En la clase MainWindow utilizaremos las variables de conexion a partir de 
	//de clarar un objeto de la clase metodo, tambien declararemos un nuevo modelo
	//(treeview) donde se definiran los datos.
	//tambien incluiremos metodos para el funcionamiento de la clase
	PConexion pc = new PConexion();
	ListStore modelo;
	string conexion;
	MySqlConnection con;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		//aqui generamos la ventana y utilizaremos el metodo para crear las columnas a partir de un ListStore
		// y cargaremos los datos de dentro de la base de datos con el metodo CargarDatos()
		Build ();
		CreateColumns();
		CargarDatos();
	}
	public void CreateColumns(){
		string [] Th = {"ID", "NOMBRES", "APELLIDOS", "EDAD", "SEXO", "TELEFONO"};
		modelo = new ListStore (typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string));
		
		for (int i = 0; i<Th.Length; i++){
				treeview.AppendColumn(new TreeViewColumn(Th[i],new CellRenderer(), "text", i));
				treeview.Columns[i].Resizable = true;
				treeview.EnableGridLines = TreeViewGridLines.Both;
		}
		treeview.Model = modelo;	
	}
	public ListStore CargarDatos(){
		modelo.Clear();
		conexion = pc.BuildConnection();
		con = new MySqlConnection(conexion);
		
		string consulta = "SELECT * FROM personas";
		
		MySqlCommand con = new MySqlCommand(consulta, con);
		
		try{
			con.Open();
			MySqlDataReader re = con.ExecuteReader();
			while(re.Read()){
				modelo.AppendValues((int)re["ID"],(string)re["NOMBRE"],(string)re["APELLIDOS"],
				                    (int)re["EDAD"],(string)re["SEXO"],(string)re["TELEFONO"]);
			}
		}catch{
			con.Dispose();
			con.Dispose();
		}
		return modelo;
	}
	public bool ComprobarCampos(){
		//creamos un objeto de la clase PEntrys para recoges los valores y comprobamos
		//que los campos no esten vacios.
		PEntrys con = new PEntrys();
		bool vacio = false;
		
		con.Nombre = entry1.Text;
		con.Apellidos = entry2.Text;
		con.Telefono = entry3.Text;
		con.Edad = entry4.Text;
		
		if(con.Nombre == "" || con.Apellidos == "" || con.Edad == "" || con.Telefono == "" ){
			MessageDialog men = new MessageDialog(null, dialogFlags.Modal,MessageType.Error,ButtonsType.Close,"Existen Campos vacios");
		}
		if(men.Run() == (int)ResponseType.Close){
			men.Destroy();
			vacio = true;
		}	
		return vacio;
	}
	
	public void Add(){
		//con este metodo recogeremos los datos de los campos y realizaremos una insercion
		// a la base de datos mediante un mysqlcomand y lo ejecutaremos con mysqlNonquery.
		if(!ComprobarCampos()){
			conexion = pc.BuildConnection();
			using (con = new MySqlConnection(conexion)){
				MySqlCommand comando = new MySqlCommand();
				comando.Connection = con;
				
				comando.CommandType = CommandType.Text;
				comando.CommandText = "INSERT INTO personas (NOMBRE,APELLIDO,EDAD,SEXO,TELEFONO) " +
					"values (@Nombre,@Apellido,@Edad,@Sexo,@Telefono)";
				comando.Parameters.AddWithValue("@Nombre", entry1.Text);
				comando.Parameters.AddWithValue("@Apellido", entry2.Text);
				comando.Parameters.AddWithValue("@Edad", entry4.Text);
				comando.Parameters.AddWithValue("@Sexo", combobox1.ActiveText);
				comando.Parameters.AddWithValue("@Telefono", entry3.Text);
				
				try{
					con.Open();
					comando.ExecuteNonQuery();
				}catch{
					con.Dispose();
					comando.Dispose();
				}
			}
		}
	}
	public void editar(){
		//realizaremos las mismas acciones que en el metodo Add pero en este caso,
		//editaremos los datos ya insertados. recogiento previamente el id
		//de l registro elegido.
		conexion = pc.BuildConnection();
		con = new MySqlConnection(conexion);
		string consultas = "SELECT * FROM personas WHERE ID = '" + entry5.Text + "'";
		MySqlCommand comando2 = new MySqlCommand(consultas,con);
		
		try{
			con.Open();
			comando2.ExecuteNonQuery();
			MySqlDataReader re = comando2.ExecuteReader();
			
			while(re.Read()){
				entry1.Text = (string)re["NOMBRE"];
				entry2.Text = (string)re["APELLIDO"];
				entry4.Text = Convert.ToString( (int)re["EDAD"]);
				
				string s = (string)re["SEXO"];
				if(s == "M"){
					combobox1.Active = 0;
				}else{
					combobox1.Active = 1;
				}
				
				entry3.Text = (string)re["Telefono"];
				
			}
		}catch{
			con.Dispose();
			comando2.Dispose ();
		}
	}
	
	public void Delete(){
		//metodo de eliminacion de registros recogiendo tambien el id del campo.
		conexion = pc.BuildConnection();
		using (con = new MySqlConnection(conexion)){
			MySqlCommand del = new MySqlCommand("DELETE FROM personas WHERE ID = '" +
			                                    entry5.Text + "'",con);
			del.CommandType = CommandType.Text;
			
			try{
				con.Open();
				del.ExecuteNonQuery();
			}catch{
				con.Dispose();
				del.Dispose();
			}
		}
		entry5.Text = "";
	}
	public ListStore Buscar(string nombre){
		//en el siguiente metodo buscaremos registros a partir del ListStore cargado
		//con los datos de la BD
		ListStore li = new ListStore(typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string));
		conexion = pc.BuildConnection();
		con = new MySqlConnection(conexion);
		
		string consulta3 = "SELECT * FROM personas WHERE NOMBRE LIKE'" + nombre + "%'";
		
		MySqlCommand buscar = new MySqlCommand(consulta3,con);
		buscar.CommandType = CommandType.Text;
		
		try{
			con.Open();
			MySqlDataReader reader = buscar.ExecuteReader();
			
			while(reader.Read()){			
				li.AppendValues((int)re["ID"],(string)re["NOMBRE"],(string)re["APELLIDOS"],
				                    (int)re["EDAD"],(string)re["SEXO"],(string)re["TELEFONO"]);
			}
			reader.Close();
		}catch{
		}
		return li;
	}
	
	public void Actualizar (int id, string nombre, string apellido, int edad, char sexo, string telefono){
		conexion = pc.BuildConnection();
		con = new MySqlConnection(conexion);
		
		string edit = "UPDATE personas SET NOMBRE - ?nombre, APELLIDO - ?apellido, EDAD - ?edad," +
			"SEXO - ?sexo, TELEFONO - ?telefono WHERE ID - ?ide";
		MySqlCommand ed = new MySqlCommand(conexion,con);
		
		ed.CommandType = CommandType.Text;
		ed.Parameters.AddWithValue("?nombre", id);
		ed.Parameters.AddWithValue("?apellido", nombre);
		ed.Parameters.AddWithValue("?edad", edad);
		ed.Parameters.AddWithValue("?sexo", sexo);
		ed.Parameters.AddWithValue("?telefono", telefono);
		
		try{
			con.Open();
			ed.ExecuteNonQuery();
		}catch{
			con.Dispose();
			ed.Dispose ();
		}
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnEliminarClicked (object sender, System.EventArgs e)
	{// boton eliminar
		Eliminar();
		CargarDatos();
	}

	protected void OnCargarClicked (object sender, System.EventArgs e)
	{//boton de cargar registros en el treeview
		CargarDatos();
	}

	protected void OnModificarClicked (object sender, System.EventArgs e)
	{//boton modificar con validacion.
		if(entry5 == ""){
			MessageDialog err = new MessageDialog(null,DialogFlags.Modal,MessageType.Info,ButtonsType.Close,"No hay id");
			if(err.Run() == (int)ResponseType.Close){
				err.Destroy();
			}
		}else{
			Actualizar (int.Parse(entry5.Text),entry2.Text,entry3.Text,int.Parse(entry4.Text),char.Parse(combobox1.ActiveText),entry1.Text);
			CargarDatos();
		}
		
	}

	protected void OnAgregarClicked (object sender, System.EventArgs e)
	{// boton añadir
		Add();
		CargarDatos();
	}

	protected void OnEntry5Changed (object sender, System.EventArgs e)
	{//campo id.
		treeview.Model = Buscar (entry1);
	}
}
