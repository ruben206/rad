
// This file has been generated by the GUI designer. Do not modify.
namespace Serpis.Ad
{
	public partial class VentanaAñadir
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entryNombre;
		private global::Gtk.VBox vbox3;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label6;
		private global::Gtk.Entry entryCat;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label label7;
		private global::Gtk.Entry entryPreci;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Button btnAñadir;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Serpis.Ad.VentanaAñadir
			this.Name = "Serpis.Ad.VentanaAñadir";
			this.Title = global::Mono.Unix.Catalog.GetString ("VentanaAñadir");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Serpis.Ad.VentanaAñadir.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre");
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryNombre = new global::Gtk.Entry ();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.hbox1.Add (this.entryNombre);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryNombre]));
			w2.Position = 1;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Categoria");
			this.hbox2.Add (this.label6);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label6]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entryCat = new global::Gtk.Entry ();
			this.entryCat.CanFocus = true;
			this.entryCat.Name = "entryCat";
			this.entryCat.IsEditable = true;
			this.entryCat.InvisibleChar = '•';
			this.hbox2.Add (this.entryCat);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entryCat]));
			w5.Position = 1;
			this.vbox3.Add (this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Precio");
			this.hbox3.Add (this.label7);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label7]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.entryPreci = new global::Gtk.Entry ();
			this.entryPreci.CanFocus = true;
			this.entryPreci.Name = "entryPreci";
			this.entryPreci.IsEditable = true;
			this.entryPreci.InvisibleChar = '•';
			this.hbox3.Add (this.entryPreci);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entryPreci]));
			w8.Position = 1;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnAñadir = new global::Gtk.Button ();
			this.btnAñadir.CanFocus = true;
			this.btnAñadir.Name = "btnAñadir";
			this.btnAñadir.UseUnderline = true;
			this.btnAñadir.Label = global::Mono.Unix.Catalog.GetString ("Añadir");
			this.hbox4.Add (this.btnAñadir);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.btnAñadir]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox3]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 233;
			this.Show ();
		}
	}
}
