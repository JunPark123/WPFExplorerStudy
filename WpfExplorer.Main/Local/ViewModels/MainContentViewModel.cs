using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System.Windows;
using System.Windows.Input;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;
using System.Collections.Generic;

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
        public List<FolderInfo> Roots { get; init; } //init 키워드는 객체 생성 시에만 초기화 할 수 있음
        public MainContentViewModel(FileService fileService)
        {
            //del//FolderChangedCommand = new RelayCommand<FolderInfo>(FolderChanged);
            _fileService = fileService;
            Roots = fileService.GenerateRootNodes();
        }

        [RelayCommand]
        private void FolderChanged(FolderInfo info)
        {
            //del//MessageBox.Show($"Selected : {info.Name}");
            _fileService.RefreshSubDirectories(info);
        }
    }


}
