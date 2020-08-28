using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _systemDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string SystemDate
        {
            get { return _systemDate; }
            set { SetProperty(ref _systemDate, value); }
        }

        private IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SystemDateUpdateCmd = new DelegateCommand(
                SystemDateUpdateExecute
                );

            ShowViewACmd = new DelegateCommand(
                ShowViewA
                );

        }
        public DelegateCommand SystemDateUpdateCmd { get; }

        private void SystemDateUpdateExecute()
        {
            SystemDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public DelegateCommand ShowViewACmd { get; }
        private void ShowViewA()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

    }
}
