using PrismSample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismSample.ViewModels;

namespace PrismSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterDialog<ViewB, ViewBViewModel>();

        }
    }
}
