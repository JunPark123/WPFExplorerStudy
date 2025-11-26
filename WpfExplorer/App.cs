using System.Windows;
using Jamesnet.Wpf.Controls;
using WpfExplorer.Forms.UI.Views;

namespace WpfExplorer
{
    internal class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new ExplorerWindow();
        }
    }
}
