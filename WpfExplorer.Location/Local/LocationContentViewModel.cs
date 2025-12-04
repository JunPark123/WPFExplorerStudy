using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;


namespace WpfExplorer.Location.Local
{
    public partial class LocationContentViewModel : ObservableBase
    {
        private readonly NavigatorService _navigatorService;

        [ObservableProperty]
        private FileInfoBase _current;
        public LocationContentViewModel(NavigatorService navigatorService)
        {
            _navigatorService = navigatorService;
            _navigatorService.LocationChanged += _navigatorService_LocationChanged;
        }
        private void _navigatorService_LocationChanged(object? sender, Support.Local.Models.LocationChangedEventArgs e)
        {
            Current = e.Current;
        }

        [RelayCommand]
        public void Undo()
        {
            _navigatorService.GoBack();
        }
        [RelayCommand]
        public void Redo()
        {
            _navigatorService.GoForward();
        }
        [RelayCommand]
        public void Up()
        {
            _navigatorService.GoToParent();
        }
    }
}
