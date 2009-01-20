// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Deployment.Gui {
    
    
    internal partial class InstallDialog {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label1;
        
        private MonoDevelop.Components.FolderEntry folderEntry;
        
        private Gtk.Label label2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Entry nameEntry;
        
        private Gtk.Button button19;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Deployment.Gui.InstallDialog
            this.Events = ((Gdk.EventMask)(256));
            this.Name = "MonoDevelop.Deployment.Gui.InstallDialog";
            this.Title = Mono.Unix.Catalog.GetString("Install Project");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.HasSeparator = false;
            // Internal child MonoDevelop.Deployment.Gui.InstallDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Events = ((Gdk.EventMask)(256));
            w1.Name = "dialog_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog_VBox.Gtk.Box+BoxChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            this.vbox1.BorderWidth = ((uint)(12));
            // Container child vbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Directory prefix:");
            this.vbox1.Add(this.label1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.label1]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.folderEntry = new MonoDevelop.Components.FolderEntry();
            this.folderEntry.Name = "folderEntry";
            this.folderEntry.BrowserTitle = "Select Directory";
            this.vbox1.Add(this.folderEntry);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.folderEntry]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.Xalign = 0F;
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Application name (to use as subdirectory name in the installation prefix):");
            this.vbox1.Add(this.label2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.label2]));
            w4.Position = 2;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            // Container child hbox1.Gtk.Box+BoxChild
            this.nameEntry = new Gtk.Entry();
            this.nameEntry.WidthRequest = 275;
            this.nameEntry.CanFocus = true;
            this.nameEntry.Name = "nameEntry";
            this.nameEntry.IsEditable = true;
            this.nameEntry.InvisibleChar = '●';
            this.hbox1.Add(this.nameEntry);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.nameEntry]));
            w5.Position = 0;
            w5.Expand = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w6.Position = 3;
            w6.Expand = false;
            w6.Fill = false;
            w1.Add(this.vbox1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(w1[this.vbox1]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Internal child MonoDevelop.Deployment.Gui.InstallDialog.ActionArea
            Gtk.HButtonBox w8 = this.ActionArea;
            w8.Name = "MonoDevelop.Deployment.InstallDialog_ActionArea";
            w8.Spacing = 10;
            w8.BorderWidth = ((uint)(5));
            w8.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child MonoDevelop.Deployment.InstallDialog_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.button19 = new Gtk.Button();
            this.button19.CanDefault = true;
            this.button19.CanFocus = true;
            this.button19.Name = "button19";
            this.button19.UseStock = true;
            this.button19.UseUnderline = true;
            this.button19.Label = "gtk-cancel";
            this.AddActionWidget(this.button19, -6);
            Gtk.ButtonBox.ButtonBoxChild w9 = ((Gtk.ButtonBox.ButtonBoxChild)(w8[this.button19]));
            w9.Expand = false;
            w9.Fill = false;
            // Container child MonoDevelop.Deployment.InstallDialog_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w10 = ((Gtk.ButtonBox.ButtonBoxChild)(w8[this.buttonOk]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 453;
            this.DefaultHeight = 193;
            this.Show();
            this.folderEntry.PathChanged += new System.EventHandler(this.OnFolderEntryPathChanged);
            this.nameEntry.Changed += new System.EventHandler(this.OnNameEntryChanged);
        }
    }
}
