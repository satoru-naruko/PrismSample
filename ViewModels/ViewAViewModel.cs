using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        public ViewAViewModel()
        {

        }

        private string _myLabel;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
