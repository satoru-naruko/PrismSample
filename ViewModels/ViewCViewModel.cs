using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.Injection;

namespace PrismSample.ViewModels
{
    public class ViewCViewModel : BindableBase, IConfirmNavigationRequest
    {
        private IMessageService _messageService;

        public ViewCViewModel() : this( new MessageService()) 
        {
        }

        public ViewCViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            AreaSelectionChanged = new DelegateCommand<object[]>(
                AreaSelectionChangedExecute
                );

            MyList.Add("ListContent1");
            MyList.Add("ListContent2");
            MyList.Add("ListContent3");

            Areas.Add(new ComboBoxViewModel(1,"横浜"));
            Areas.Add(new ComboBoxViewModel(2,"神戸"));
            Areas.Add(new ComboBoxViewModel(3,"高松"));

            SelectedArea = Areas[0];
        }

        private ObservableCollection<string> _myList = new ObservableCollection<string>();
        public ObservableCollection<string> MyList
        {
            get { return _myList; }
            set { SetProperty(ref _myList, value); }
        }

        private ObservableCollection<ComboBoxViewModel> _areas = new ObservableCollection<ComboBoxViewModel>();
        public ObservableCollection<ComboBoxViewModel> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }

        private ComboBoxViewModel _selectedArea;
        public ComboBoxViewModel SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }

        private string _testSelectedArea;
        public string TestSelectedArea
        {
            get { return _testSelectedArea; }
            set { SetProperty(ref _testSelectedArea, value); }
        }

        public DelegateCommand<object[]> AreaSelectionChanged { get; }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (_messageService.Question("閉じますか？") == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        private void AreaSelectionChangedExecute(object[] items)
        {
            var obj = items[0] as ComboBoxViewModel;
            if ( obj is ComboBoxViewModel)
            {
                TestSelectedArea = obj.DisplayValue;
            }            
        }
    }
}
