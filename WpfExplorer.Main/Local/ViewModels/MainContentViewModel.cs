using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;


namespace WpfExplorer.Main.Local.ViewModels
{
    /// <summary>
    /// Tip)
    /// partial로 지정함으로써 RelayCommand 어트리뷰트를 지정한 콜백 메서드에
    /// 코드 자동 생성 기능을 사용할 수 있음
    /// </summary>
    public partial class MainContentViewModel : ObservableBase
    {
        //del//public ICommand FolderChangedCommand { get; init; }
        private readonly FileService _fileService;
        private readonly NavigatorService _navigatorService;
        public List<FolderInfo> Roots { get; init; } //init 키워드는 객체 생성 시에만 초기화 할 수 있음
        public ObservableCollection<FolderInfo> Files { get; init; }
        public MainContentViewModel(FileService fileService, NavigatorService navigatorService)
        {
            //del//FolderChangedCommand = new RelayCommand<FolderInfo>(FolderChanged);
            _fileService = fileService;
            _navigatorService = navigatorService;
            _navigatorService.LocationChanged += _navigatorService_LocationChanged;

            Roots = fileService.GenerateRootNodes();
            Files = new();
        }

        private void _navigatorService_LocationChanged(object? sender, LocationChangedEventArgs e)
        {
            List<FolderInfo> source = GetDirectoryItems(e.Current.FullPath);

            Files.Clear();
            Files.AddRange(source);
        }

        private List<FolderInfo> GetDirectoryItems(string fullPath)
        {
            List<FolderInfo> items = new();
            string[] dirs = Directory.GetDirectories(fullPath);
            foreach (string path in dirs)
            {
                items.Add(new FolderInfo { FullPath = path });
            }

            string[] files = Directory.GetFiles(fullPath);
            foreach (string path in files)
            {
                items.Add(new FolderInfo { FullPath = path });
            }
            return items;
        }

        [RelayCommand]
        private void FolderChanged(FolderInfo info)
        {
            //del//MessageBox.Show($"Selected : {info.Name}");
            _fileService.RefreshSubDirectories(info);
            _navigatorService.ChangeLocation(info);
        }

        [RelayCommand]
        private void GoBack()
        {
            _navigatorService.GoBack();
        }
        [RelayCommand]
        private void GoForward()
        {
            _navigatorService.GoForward();
        }

        [RelayCommand]
        private void GoToParent()
        {
            _navigatorService.GoToParent();
        }
    }


}
