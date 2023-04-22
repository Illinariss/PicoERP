using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Interfaces;
using WpfPicoErp.Misc;
using WpfPicoErp.Pages;

namespace WpfPicoErp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase currentViewModel;
        public ObservableCollection<INavigationItem> NavigationItems { get; private set; }
        private NavigationItem selectedNavigationItem;
        public NavigationItem SelectedNavigationItem
        {
            get
            { return selectedNavigationItem; }
            set
            {
                if (value != selectedNavigationItem)
                {
                    selectedNavigationItem = value;
                    selectedNavigationItem.NavigateCommand.Execute(null);
                }
            }
        }


        private INavigationService navigationService;
        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            SetUpCommand();
            SetUpNavigation();

        }

        private void SetUpNavigation()
        {
            NavigationItems = new ObservableCollection<INavigationItem>
            {
                new NavigationItem("Kundenverwaltung", () => navigationService.Navigate<CustomerManagerViewModel>(), navigationService,typeof(CustomerManagerViewModel), "Images/customer.png"),
                new NavigationItem("Rechnungsverwaltung", () => navigationService.Navigate<InvoiceManagerViewModel>(), navigationService,typeof(InvoiceManagerViewModel), "Images/invoice.png")
            };
        }

        private void SetUpCommand()
        {
            NavigateToCustomerManagerCommand = new RelayCommand(NavigateToCustomerManager);
            NavigateToInvoiceManagerCommand = new RelayCommand(NavigateToInvoiceManager);
        }

        public ICommand NavigateToCustomerManagerCommand { get; set; }
        public ICommand NavigateToInvoiceManagerCommand { get; set; }

        public void NavigateToCustomerManager()
        {
            navigationService.Navigate<CustomerManagerViewModel>();
        }

        public void NavigateToInvoiceManager()
        {
            navigationService.Navigate<InvoiceManagerViewModel>();
        }
    }

}
