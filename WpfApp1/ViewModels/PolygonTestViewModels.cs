using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfExplorer.Support.Local.Models;

namespace WpfApp1.ViewModels
{
    public class PolygonTestViewModels
    {
        public PolygonTestViewModels()
        {
            Current = new();
            
            
        }

        public string Name { get; set; } = "Documents";
        public Brush Color { get; set; } = Brushes.CornflowerBlue;
        public bool IsRoot { get; set; } = false;
        public int Zindex { get; set; } = 10;

        public FileInfoBase Current { get; }


    }

    public class TextBoxViewModels
    {
       public FileInfoBase Current { get; }

        public TextBoxViewModels()
        {

        }
    }
}
