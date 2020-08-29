using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
        private IDialogService _dialogService;
        public MainWindowViewModel(IRegionManager regionManager,
            IDialogService dialogService
            )
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            SystemDateUpdateCmd = new DelegateCommand(
                SystemDateUpdateExecute
            );

            ShowViewACmd = new DelegateCommand(
                ShowViewA
            );
            ShowViewAWithParamCmd = new DelegateCommand(
                ShowViewAWithParam
            );
            ShowViewBCmd = new DelegateCommand(
                ShowViewB
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

        public DelegateCommand ShowViewAWithParamCmd { get; }
        private void ShowViewAWithParam()
        {
            var param = new NavigationParameters();
            param.Add(nameof(ViewAViewModel.MyLabel), SystemDate);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA), param);
        }

        public DelegateCommand ShowViewBCmd { get; }
        private void ShowViewB()
        {
            var param = new DialogParameters();
            param.Add(nameof(ViewBViewModel.ViewBTextBox), SystemDate);
            _dialogService.ShowDialog(nameof(ViewB),param,null);
        }

    }
}
