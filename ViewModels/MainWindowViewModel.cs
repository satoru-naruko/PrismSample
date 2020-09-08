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

        private bool _buttonEnable = false;
        public bool ButtonEnable
        {
            get { return _buttonEnable; }
            set { SetProperty(ref _buttonEnable, value); }
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
            ).ObservesCanExecute(() => ButtonEnable);
            ShowViewAWithParamCmd = new DelegateCommand(
                ShowViewAWithParam
            );
            ShowViewBCmd = new DelegateCommand(
                ShowViewB
            );
            ShowViewCCmd = new DelegateCommand(
                ShowViewC
            );

        }
        public DelegateCommand SystemDateUpdateCmd { get; }

        private void SystemDateUpdateExecute()
        {
            ButtonEnable = true;
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
            _dialogService.ShowDialog(nameof(ViewB),param, ViewBClose);
        }

        public DelegateCommand ShowViewCCmd { get; }
        private void ShowViewC()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewC));

        }

        private  void ViewBClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result == ButtonResult.OK)
            {
                SystemDate = dialogResult.Parameters.GetValue<string>(nameof(ViewBViewModel.ViewBTextBox));
            }
        }
    }
}
