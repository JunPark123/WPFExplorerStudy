using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Main.UI.Units
{
    public class FolderTreeItem : TreeViewItem
    {
        static FolderTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderTreeItem), 
                new FrameworkPropertyMetadata(typeof(FolderTreeItem)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            Debug.WriteLine("들어옴");
            return new FolderTreeItem();
        }
    }
}
