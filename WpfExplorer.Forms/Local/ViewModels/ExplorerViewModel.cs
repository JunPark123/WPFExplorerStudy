using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows.Controls;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;


namespace WpfExplorer.Forms.Local.ViewModels
{
    public class ExplorerViewModel : ObservableBase, IViewLoadable
    {
        private readonly IContainerProvider _containerProvider; 
        private readonly IRegionManager _regionManager;

        public List<FolderInfo> Roots { get; init; }

        public ExplorerViewModel(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
        }

        public void OnLoaded(IViewable view) //해당 뷰모델의 뷰가 로드되는 시점에 호출됨
        {
            IRegion mainRegion = _regionManager.Regions["MainRegion"]; //해당 Region을 찾아옴
            IViewable mainContent = _containerProvider.Resolve<IViewable>("MainContent"); 
            //^^^^^ ContainerProvider는 타입과 이름으로 등록된 싱글턴 객체를 불러오는 역할을 함

            if (!mainRegion.Views.Contains(mainContent)) //여러 뷰를 등록하기 때문에 중복 여부를 확인함
            {
                mainRegion.Add(mainContent);
            }

            mainRegion.Activate(mainContent); 
        }
    }
}
