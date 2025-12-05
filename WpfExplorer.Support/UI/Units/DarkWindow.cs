using Jamesnet.Wpf.Controls;
using System.Windows;

namespace WpfExplorer.Support.UI.Units
{
    public class DarkWindow : JamesWindow
    {
        public static readonly DependencyProperty LocationTemplateProperty =
            DependencyProperty.Register("LocationTemplate",
                typeof(DataTemplate),
                typeof(DarkWindow),
                new PropertyMetadata(null));

        public DataTemplate LocationTemplate
        {
            get { return (DataTemplate)GetValue(LocationTemplateProperty); }
            set { SetValue(LocationTemplateProperty, value); }
        }

        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", 
                typeof(object),
                typeof(DarkWindow),
                new UIPropertyMetadata(null));

        public object Location
        {
            get { return GetValue(LocationTemplateProperty); }
            set
            {
                SetValue(LocationTemplateProperty, value);
            }
        }

        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow),
                new FrameworkPropertyMetadata(typeof(DarkWindow)));
        }


        


    }
}
