using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfPicoErp.Interfaces;
using WpfPicoErp.Misc;
using WpfPicoErp.Pages;
using WpfPicoErp.ViewModels;
using WpfPicoErp.ViewModels.Pages;

namespace WpfPicoErp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private INavigationService _navigationService;

        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();

            // Finde den Frame, der für die Navigation verwendet werden soll
            var navigationFrame = (Frame)mainWindow.FindName("NavigationFrame");
            _navigationService = new NavigationService(navigationFrame);

            // Registriere ViewModels und zugehörige Views
            RegisterViewModels(_navigationService);

            mainWindow.DataContext = new MainWindowViewModel(_navigationService);
            mainWindow.Show();
        }

        public void RegisterViewModels(INavigationService navigationService)
        {
            navigationService.Register<CustomerManagerViewModel, CustomerManager>();
            navigationService.Register<InvoiceManagerViewModel, InvoiceManager>();
            navigationService.Register<ProductManagerViewModel, ProductManager>();
        }

    }
}
