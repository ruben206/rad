using System;

namespace GestionBD
{
	public class PEntrys
	{
		//En esta clase declaramos las variables que hacen referencia la los campos
		// de la tabla y implementamos los metodos get y set de cada campo para la
		//recepcion de datos de la base de datos.
		private string Nom, Ape, Ed, Tel;
		
		public PEntrys()
		{
			Nom = "";
			Ape = "";
			Ed = "";
			Tel = "";
		}
		public string Nombre{
			get{
				return Nom;
			}
			set{
				Nom = value;
			}
		}
		public string Apellidos{
			get{
				return Ape;
			}
			set{
				Ape = value;
			}
		}
		public string Edad{
			get{
				return Ed;
			}
			set{
				Ed = value;
			}
		}
		public string Telefono{
			get{
				return Tel;
			}
			set{
				Tel = value;
			}
		}
	}
}

