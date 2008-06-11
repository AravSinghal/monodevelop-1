// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.SourceEditor {
    
    
    public partial class SearchAndReplaceWidget {
        
        private Gtk.HBox hbox3;
        
        private Gtk.Table table1;
        
        private Gtk.Button closeButton;
        
        private Gtk.Image image4;
        
        private Gtk.ComboBoxEntry entryReplace;
        
        private Gtk.ComboBoxEntry entrySearch;
        
        private Gtk.Label label1;
        
        private Gtk.Label label3;
        
        private Gtk.Table table2;
        
        private Gtk.Button buttonReplace;
        
        private Gtk.Button buttonReplaceAll;
        
        private Gtk.Button buttonSearchBackward;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Arrow arrow2;
        
        private Gtk.Label label5;
        
        private Gtk.Button buttonSearchForward;
        
        private Gtk.HBox hbox5;
        
        private Gtk.Arrow arrow3;
        
        private Gtk.Label label6;
        
        private MonoDevelop.Components.MenuButton optionsButton;
        
        private Gtk.VBox vbox3;
        
        private Gtk.HBox hbox7;
        
        private Gtk.Fixed fixed1;
        
        private Gtk.Button buttonSearchMode;
        
        private Gtk.Arrow arrow4;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.SourceEditor.SearchAndReplaceWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.SourceEditor.SearchAndReplaceWidget";
            // Container child MonoDevelop.SourceEditor.SearchAndReplaceWidget.Gtk.Container+ContainerChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(3)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.closeButton = new Gtk.Button();
            this.closeButton.CanFocus = true;
            this.closeButton.Name = "closeButton";
            this.closeButton.Relief = ((Gtk.ReliefStyle)(2));
            // Container child closeButton.Gtk.Container+ContainerChild
            this.image4 = new Gtk.Image();
            this.image4.Name = "image4";
            this.image4.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-close", Gtk.IconSize.Menu, 16);
            this.closeButton.Add(this.image4);
            this.closeButton.Label = null;
            this.table1.Add(this.closeButton);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.closeButton]));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.entryReplace = Gtk.ComboBoxEntry.NewText();
            this.entryReplace.Name = "entryReplace";
            this.table1.Add(this.entryReplace);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.entryReplace]));
            w3.TopAttach = ((uint)(1));
            w3.BottomAttach = ((uint)(2));
            w3.LeftAttach = ((uint)(2));
            w3.RightAttach = ((uint)(3));
            w3.XPadding = ((uint)(6));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.entrySearch = Gtk.ComboBoxEntry.NewText();
            this.entrySearch.Name = "entrySearch";
            this.table1.Add(this.entrySearch);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.entrySearch]));
            w4.LeftAttach = ((uint)(2));
            w4.RightAttach = ((uint)(3));
            w4.XPadding = ((uint)(6));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Find:");
            this.label1.UseUnderline = true;
            this.table1.Add(this.label1);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label1]));
            w5.LeftAttach = ((uint)(1));
            w5.RightAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Replace:");
            this.label3.UseUnderline = true;
            this.table1.Add(this.label3);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.label3]));
            w6.TopAttach = ((uint)(1));
            w6.BottomAttach = ((uint)(2));
            w6.LeftAttach = ((uint)(1));
            w6.RightAttach = ((uint)(2));
            w6.XOptions = ((Gtk.AttachOptions)(4));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            this.hbox3.Add(this.table1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox3[this.table1]));
            w7.Position = 0;
            // Container child hbox3.Gtk.Box+BoxChild
            this.table2 = new Gtk.Table(((uint)(2)), ((uint)(3)), false);
            this.table2.Name = "table2";
            this.table2.RowSpacing = ((uint)(6));
            this.table2.ColumnSpacing = ((uint)(6));
            // Container child table2.Gtk.Table+TableChild
            this.buttonReplace = new Gtk.Button();
            this.buttonReplace.CanFocus = true;
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.UseUnderline = true;
            this.buttonReplace.Relief = ((Gtk.ReliefStyle)(2));
            // Container child buttonReplace.Gtk.Container+ContainerChild
            Gtk.Alignment w8 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w9 = new Gtk.HBox();
            w9.Spacing = 2;
            // Container child GtkHBox2.Gtk.Container+ContainerChild
            Gtk.Image w10 = new Gtk.Image();
            w10.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-find-and-replace", Gtk.IconSize.Menu, 16);
            w9.Add(w10);
            // Container child GtkHBox2.Gtk.Container+ContainerChild
            Gtk.Label w12 = new Gtk.Label();
            w12.LabelProp = Mono.Unix.Catalog.GetString("Replace");
            w12.UseUnderline = true;
            w9.Add(w12);
            w8.Add(w9);
            this.buttonReplace.Add(w8);
            this.table2.Add(this.buttonReplace);
            Gtk.Table.TableChild w16 = ((Gtk.Table.TableChild)(this.table2[this.buttonReplace]));
            w16.TopAttach = ((uint)(1));
            w16.BottomAttach = ((uint)(2));
            w16.XOptions = ((Gtk.AttachOptions)(4));
            w16.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.buttonReplaceAll = new Gtk.Button();
            this.buttonReplaceAll.CanFocus = true;
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.UseUnderline = true;
            this.buttonReplaceAll.Relief = ((Gtk.ReliefStyle)(2));
            this.buttonReplaceAll.Label = Mono.Unix.Catalog.GetString("Replace all");
            this.table2.Add(this.buttonReplaceAll);
            Gtk.Table.TableChild w17 = ((Gtk.Table.TableChild)(this.table2[this.buttonReplaceAll]));
            w17.TopAttach = ((uint)(1));
            w17.BottomAttach = ((uint)(2));
            w17.LeftAttach = ((uint)(1));
            w17.RightAttach = ((uint)(2));
            w17.XOptions = ((Gtk.AttachOptions)(4));
            w17.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.buttonSearchBackward = new Gtk.Button();
            this.buttonSearchBackward.CanFocus = true;
            this.buttonSearchBackward.Name = "buttonSearchBackward";
            this.buttonSearchBackward.Relief = ((Gtk.ReliefStyle)(2));
            // Container child buttonSearchBackward.Gtk.Container+ContainerChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.arrow2 = new Gtk.Arrow(((Gtk.ArrowType)(2)), ((Gtk.ShadowType)(2)));
            this.arrow2.Name = "arrow2";
            this.hbox2.Add(this.arrow2);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.hbox2[this.arrow2]));
            w18.Position = 0;
            w18.Expand = false;
            w18.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Find Previous");
            this.hbox2.Add(this.label5);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox2[this.label5]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
            this.buttonSearchBackward.Add(this.hbox2);
            this.buttonSearchBackward.Label = null;
            this.table2.Add(this.buttonSearchBackward);
            Gtk.Table.TableChild w21 = ((Gtk.Table.TableChild)(this.table2[this.buttonSearchBackward]));
            w21.XOptions = ((Gtk.AttachOptions)(4));
            w21.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.buttonSearchForward = new Gtk.Button();
            this.buttonSearchForward.CanFocus = true;
            this.buttonSearchForward.Name = "buttonSearchForward";
            this.buttonSearchForward.Relief = ((Gtk.ReliefStyle)(2));
            // Container child buttonSearchForward.Gtk.Container+ContainerChild
            this.hbox5 = new Gtk.HBox();
            this.hbox5.Name = "hbox5";
            this.hbox5.Spacing = 6;
            // Container child hbox5.Gtk.Box+BoxChild
            this.arrow3 = new Gtk.Arrow(((Gtk.ArrowType)(3)), ((Gtk.ShadowType)(2)));
            this.arrow3.Name = "arrow3";
            this.hbox5.Add(this.arrow3);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.hbox5[this.arrow3]));
            w22.Position = 0;
            w22.Expand = false;
            w22.Fill = false;
            // Container child hbox5.Gtk.Box+BoxChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Find Next");
            this.hbox5.Add(this.label6);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox5[this.label6]));
            w23.Position = 1;
            w23.Expand = false;
            w23.Fill = false;
            this.buttonSearchForward.Add(this.hbox5);
            this.buttonSearchForward.Label = null;
            this.table2.Add(this.buttonSearchForward);
            Gtk.Table.TableChild w25 = ((Gtk.Table.TableChild)(this.table2[this.buttonSearchForward]));
            w25.LeftAttach = ((uint)(1));
            w25.RightAttach = ((uint)(2));
            w25.XOptions = ((Gtk.AttachOptions)(4));
            w25.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.optionsButton = new MonoDevelop.Components.MenuButton();
            this.optionsButton.CanFocus = true;
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.UseUnderline = true;
            this.optionsButton.Relief = ((Gtk.ReliefStyle)(2));
            this.optionsButton.UseMarkup = false;
            this.optionsButton.Label = "";
            this.table2.Add(this.optionsButton);
            Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table2[this.optionsButton]));
            w26.LeftAttach = ((uint)(2));
            w26.RightAttach = ((uint)(3));
            w26.XOptions = ((Gtk.AttachOptions)(4));
            w26.YOptions = ((Gtk.AttachOptions)(4));
            this.hbox3.Add(this.table2);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.hbox3[this.table2]));
            w27.Position = 1;
            w27.Expand = false;
            w27.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbox7 = new Gtk.HBox();
            this.hbox7.Name = "hbox7";
            this.hbox7.Spacing = 6;
            // Container child hbox7.Gtk.Box+BoxChild
            this.fixed1 = new Gtk.Fixed();
            this.fixed1.Name = "fixed1";
            this.fixed1.HasWindow = false;
            this.hbox7.Add(this.fixed1);
            Gtk.Box.BoxChild w28 = ((Gtk.Box.BoxChild)(this.hbox7[this.fixed1]));
            w28.Position = 0;
            // Container child hbox7.Gtk.Box+BoxChild
            this.buttonSearchMode = new Gtk.Button();
            this.buttonSearchMode.CanFocus = true;
            this.buttonSearchMode.Name = "buttonSearchMode";
            this.buttonSearchMode.Relief = ((Gtk.ReliefStyle)(2));
            // Container child buttonSearchMode.Gtk.Container+ContainerChild
            this.arrow4 = new Gtk.Arrow(((Gtk.ArrowType)(1)), ((Gtk.ShadowType)(0)));
            this.arrow4.Name = "arrow4";
            this.buttonSearchMode.Add(this.arrow4);
            this.buttonSearchMode.Label = null;
            this.hbox7.Add(this.buttonSearchMode);
            Gtk.Box.BoxChild w30 = ((Gtk.Box.BoxChild)(this.hbox7[this.buttonSearchMode]));
            w30.Position = 1;
            w30.Expand = false;
            w30.Fill = false;
            this.vbox3.Add(this.hbox7);
            Gtk.Box.BoxChild w31 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbox7]));
            w31.Position = 0;
            w31.Expand = false;
            w31.Fill = false;
            this.hbox3.Add(this.vbox3);
            Gtk.Box.BoxChild w32 = ((Gtk.Box.BoxChild)(this.hbox3[this.vbox3]));
            w32.Position = 2;
            this.Add(this.hbox3);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
        }
    }
}
