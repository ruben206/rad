using System;
using System.Data;
using Gtk;
using Serpis.Ad;

namespace PGTKArticulo
{
	public partial class VentanaAñadir : Gtk.Window
	{
		public VentanaAñadir () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}
