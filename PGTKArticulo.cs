using System;

namespace PArticulo
{
	public partial class PGTKArticulo : Gtk.Window
	{
		public PGTKArticulo () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

