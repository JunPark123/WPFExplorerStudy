using System.Windows;
using System.Windows.Controls;
using WpfExplorer.Support.UI.Units;
using WpfExplorer.Forms.Local.ViewModels;

namespace WpfExplorer.Forms.UI.Views
{
      public class ExplorerWindow : DarkWindow
    {
        static ExplorerWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExplorerWindow), 
                new FrameworkPropertyMetadata(typeof(ExplorerWindow)));
        }
    }
}
