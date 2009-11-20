// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Debugger {
    
    
    public partial class DebuggerOptionsPanelWidget {
        
        private Gtk.Notebook notebook1;
        
        private Gtk.VBox vbox3;
        
        private Gtk.CheckButton checkAllowEval;
        
        private Gtk.CheckButton checkToString;
        
        private Gtk.Table tableEval;
        
        private Gtk.Label label60;
        
        private Gtk.SpinButton spinTimeout;
        
        private Gtk.Label label4;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView engineList;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Button buttonUp;
        
        private Gtk.Button buttonDown;
        
        private Gtk.Label label1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Debugger.DebuggerOptionsPanelWidget
            Stetic.BinContainer.Attach(this);
            this.Name = "MonoDevelop.Debugger.DebuggerOptionsPanelWidget";
            // Container child MonoDevelop.Debugger.DebuggerOptionsPanelWidget.Gtk.Container+ContainerChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            this.vbox3.BorderWidth = ((uint)(9));
            // Container child vbox3.Gtk.Box+BoxChild
            this.checkAllowEval = new Gtk.CheckButton();
            this.checkAllowEval.CanFocus = true;
            this.checkAllowEval.Name = "checkAllowEval";
            this.checkAllowEval.Label = Mono.Unix.Catalog.GetString("Allow implicit property evaluation and method invocation");
            this.checkAllowEval.Active = true;
            this.checkAllowEval.DrawIndicator = true;
            this.checkAllowEval.UseUnderline = true;
            this.vbox3.Add(this.checkAllowEval);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox3[this.checkAllowEval]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.checkToString = new Gtk.CheckButton();
            this.checkToString.CanFocus = true;
            this.checkToString.Name = "checkToString";
            this.checkToString.Label = Mono.Unix.Catalog.GetString("Use ToString() to get the string value of objects");
            this.checkToString.DrawIndicator = true;
            this.checkToString.UseUnderline = true;
            this.vbox3.Add(this.checkToString);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox3[this.checkToString]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.tableEval = new Gtk.Table(((uint)(1)), ((uint)(3)), false);
            this.tableEval.Name = "tableEval";
            this.tableEval.RowSpacing = ((uint)(6));
            this.tableEval.ColumnSpacing = ((uint)(6));
            // Container child tableEval.Gtk.Table+TableChild
            this.label60 = new Gtk.Label();
            this.label60.Name = "label60";
            this.label60.Xalign = 0F;
            this.label60.LabelProp = Mono.Unix.Catalog.GetString("Evaluation Timeout:");
            this.tableEval.Add(this.label60);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.tableEval[this.label60]));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child tableEval.Gtk.Table+TableChild
            this.spinTimeout = new Gtk.SpinButton(0, 1000000, 100);
            this.spinTimeout.CanFocus = true;
            this.spinTimeout.Name = "spinTimeout";
            this.spinTimeout.Adjustment.PageIncrement = 10;
            this.spinTimeout.ClimbRate = 100;
            this.spinTimeout.Numeric = true;
            this.tableEval.Add(this.spinTimeout);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.tableEval[this.spinTimeout]));
            w4.LeftAttach = ((uint)(1));
            w4.RightAttach = ((uint)(2));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            this.vbox3.Add(this.tableEval);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox3[this.tableEval]));
            w5.Position = 2;
            w5.Expand = false;
            w5.Fill = false;
            this.notebook1.Add(this.vbox3);
            // Notebook tab
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("General");
            this.notebook1.SetTabLabel(this.vbox3, this.label4);
            this.label4.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(6));
            // Container child vbox2.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.WidthRequest = 417;
            this.label2.Name = "label2";
            this.label2.Xalign = 0F;
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("This priority list will be used by MonoDevelop when selecting the engine to be used for debugging an application.");
            this.label2.Wrap = true;
            this.vbox2.Add(this.label2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox2[this.label2]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.engineList = new Gtk.TreeView();
            this.engineList.CanFocus = true;
            this.engineList.Name = "engineList";
            this.engineList.HeadersVisible = false;
            this.GtkScrolledWindow.Add(this.engineList);
            this.hbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
            w9.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.buttonUp = new Gtk.Button();
            this.buttonUp.CanFocus = true;
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.UseStock = true;
            this.buttonUp.UseUnderline = true;
            this.buttonUp.Label = "gtk-go-up";
            this.vbox4.Add(this.buttonUp);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox4[this.buttonUp]));
            w10.Position = 0;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.buttonDown = new Gtk.Button();
            this.buttonDown.CanFocus = true;
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.UseStock = true;
            this.buttonDown.UseUnderline = true;
            this.buttonDown.Label = "gtk-go-down";
            this.vbox4.Add(this.buttonDown);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox4[this.buttonDown]));
            w11.Position = 1;
            w11.Expand = false;
            w11.Fill = false;
            this.hbox1.Add(this.vbox4);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox4]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            this.vbox2.Add(this.hbox1);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
            w13.Position = 1;
            this.notebook1.Add(this.vbox2);
            Gtk.Notebook.NotebookChild w14 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox2]));
            w14.Position = 1;
            // Notebook tab
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Preferred Debuggers");
            this.notebook1.SetTabLabel(this.vbox2, this.label1);
            this.label1.ShowAll();
            this.Add(this.notebook1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.checkAllowEval.Toggled += new System.EventHandler(this.OnCheckAllowEvalToggled);
            this.buttonUp.Clicked += new System.EventHandler(this.OnButtonUpClicked);
            this.buttonDown.Clicked += new System.EventHandler(this.OnButtonDownClicked);
        }
    }
}
