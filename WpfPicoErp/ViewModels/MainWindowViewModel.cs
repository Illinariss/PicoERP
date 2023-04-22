using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Interface;
using WpfPicoErp.Misc;
using WpfPicoErp.Pages;

namespace WpfPicoErp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase currentViewModel;
        private INavigationService navigationService;
        public MainWindowViewModel()
        {
            
        }
        public MainWindowViewModel(INavigationService navigationService)
        {
            NavigateToCustomerManagerCommand = new RelayCommand(NavigateToCustomerManager);
            this.navigationService = navigationService;
        }

        public RelayCommand NavigateToCustomerManagerCommand { get; private set; }
        public void NavigateToCustomerManager()
        {
            navigationService.NavigateTo<CustomerManagerViewModel>();
        }
    }

}
