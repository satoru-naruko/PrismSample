using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

            MyList.Add("ListContent1");
            MyList.Add("ListContent2");
            MyList.Add("ListContent3");
        }

        private ObservableCollection<string> _myList = new ObservableCollection<string>();
        public ObservableCollection<string> MyList
        {
            get { return _myList; }
            set { SetProperty(ref _myList, value); }
        }

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
    }
}
