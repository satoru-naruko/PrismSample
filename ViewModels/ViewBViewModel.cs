using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    public class ViewBViewModel : BindableBase, IDialogAware
    {
        private string _viewBTextBox;
        public string ViewBTextBox
        {
            get { return _viewBTextBox; }
            set { SetProperty(ref _viewBTextBox, value); }
        }
        public ViewBViewModel()
        {

        }

        public string Title => "Prism Sample B";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ViewBTextBox = parameters.GetValue<string>(nameof(ViewBTextBox));
        }
    }
}
