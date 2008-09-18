// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Stetic {
    
    
    internal class Gui {
        
        private static bool initialized;
        
        internal static void Initialize(Gtk.Widget iconRenderer) {
            if ((Stetic.Gui.initialized == false)) {
                Stetic.Gui.initialized = true;
                Gtk.IconFactory w1 = new Gtk.IconFactory();
                Gtk.IconSet w2 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("repository.png"));
                w1.Add("vcs-repository", w2);
                w1.AddDefault();
            }
        }
    }
    
    internal class BinContainer {
        
        private Gtk.Widget child;
        
        private Gtk.UIManager uimanager;
        
        public static BinContainer Attach(Gtk.Bin bin) {
            BinContainer bc = new BinContainer();
            bin.SizeRequested += new Gtk.SizeRequestedHandler(bc.OnSizeRequested);
            bin.SizeAllocated += new Gtk.SizeAllocatedHandler(bc.OnSizeAllocated);
            bin.Added += new Gtk.AddedHandler(bc.OnAdded);
            return bc;
        }
        
        private void OnSizeRequested(object sender, Gtk.SizeRequestedArgs args) {
            if ((this.child != null)) {
                args.Requisition = this.child.SizeRequest();
            }
        }
        
        private void OnSizeAllocated(object sender, Gtk.SizeAllocatedArgs args) {
            if ((this.child != null)) {
                this.child.Allocation = args.Allocation;
            }
        }
        
        private void OnAdded(object sender, Gtk.AddedArgs args) {
            this.child = args.Widget;
        }
        
        public void SetUiManager(Gtk.UIManager uim) {
            this.uimanager = uim;
            this.child.Realized += new System.EventHandler(this.OnRealized);
        }
        
        private void OnRealized(object sender, System.EventArgs args) {
            if ((this.uimanager != null)) {
                Gtk.Widget w;
                w = this.child.Toplevel;
                if (((w != null) && typeof(Gtk.Window).IsInstanceOfType(w))) {
                    ((Gtk.Window)(w)).AddAccelGroup(this.uimanager.AccelGroup);
                    this.uimanager = null;
                }
            }
        }
    }
    
    internal class IconLoader {
        
        public static Gdk.Pixbuf LoadIcon(Gtk.Widget widget, string name, Gtk.IconSize size, int sz) {
            Gdk.Pixbuf res = widget.RenderIcon(name, size, null);
            if ((res != null)) {
                return res;
            }
            else {
                try {
                    return Gtk.IconTheme.Default.LoadIcon(name, sz, 0);
                }
                catch (System.Exception ) {
                    if ((name != "gtk-missing-image")) {
                        return Stetic.IconLoader.LoadIcon(widget, "gtk-missing-image", size, sz);
                    }
                    else {
                        Gdk.Pixmap pmap = new Gdk.Pixmap(Gdk.Screen.Default.RootWindow, sz, sz);
                        Gdk.GC gc = new Gdk.GC(pmap);
                        gc.RgbFgColor = new Gdk.Color(255, 255, 255);
                        pmap.DrawRectangle(gc, true, 0, 0, sz, sz);
                        gc.RgbFgColor = new Gdk.Color(0, 0, 0);
                        pmap.DrawRectangle(gc, false, 0, 0, (sz - 1), (sz - 1));
                        gc.SetLineAttributes(3, Gdk.LineStyle.Solid, Gdk.CapStyle.Round, Gdk.JoinStyle.Round);
                        gc.RgbFgColor = new Gdk.Color(255, 0, 0);
                        pmap.DrawLine(gc, (sz / 4), (sz / 4), ((sz - 1) - (sz / 4)), ((sz - 1) - (sz / 4)));
                        pmap.DrawLine(gc, ((sz - 1) - (sz / 4)), (sz / 4), (sz / 4), ((sz - 1) - (sz / 4)));
                        return Gdk.Pixbuf.FromDrawable(pmap, pmap.Colormap, 0, 0, 0, 0, sz, sz);
                    }
                }
            }
        }
    }
    
    internal class ActionGroups {
        
        public static Gtk.ActionGroup GetActionGroup(System.Type type) {
            return Stetic.ActionGroups.GetActionGroup(type.FullName);
        }
        
        public static Gtk.ActionGroup GetActionGroup(string name) {
            return null;
        }
    }
}
