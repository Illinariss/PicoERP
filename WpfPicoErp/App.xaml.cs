using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfPicoErp.Interface;
using WpfPicoErp.Misc;
using WpfPicoErp.Pages;
using WpfPicoErp.ViewModels;

namespace WpfPicoErp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private  INavigationService _navigationService;

        public App()
        {
            Startup += OnStartup;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            _navigationService = new NavigationService(mainWindow);

            // Registriere ViewModels und zugehörige Views
            RegisterViewModels(_navigationService);

            //mainWindow.Show();
            _navigationService.NavigateTo<MainWindowViewModel>();
        }

        public void RegisterViewModels(INavigationService navigationService)
        {
            navigationService.Register<MainWindowViewModel,MainWindow>();
            navigationService.Register<CustomerManagerViewModel, CustomerManager>();
            navigationService.Register<InvoiceManagerViewModel, InvoiceManager>();
        }

    }
}
