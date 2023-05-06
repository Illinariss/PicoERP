using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;
using WpfPicoErp.Windows;

namespace WpfPicoErp.ViewModels
{
    public partial class CustomerManagerViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;

        public CustomerManagerViewModel()
        {
            DeleteCustomerCommand = new ParameteredRelayCommand(DeleteCustomer, CanDeleteCustomer);
            OpenAddCustomerWindowCommand = new ParameteredRelayCommand(OpenAddCustomerWindow);
            // ...
        }

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer SelectedCustomer { get; set; }

        public ICommand DeleteCustomerCommand { get; }
        public ICommand OpenAddCustomerWindowCommand { get; }

        private void DeleteCustomer(object SelectedCustomer)
        {
            if (SelectedCustomer != null)
            {
                // Implementieren Sie die Logik zum Löschen des ausgewählten Kunden
                // z.B. Customers.Remove(SelectedCustomer) oder Kunden aus der Datenbank löschen

                // Aktualisieren Sie die Kundenliste nach dem Löschen
                // z.B. durch erneutes Laden der Kunden aus der Datenbank
            }
        }
        private void EditCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                var addCustomerViewModel = new AddEditCustomerViewModel(SelectedCustomer);
                var addCustomerWindow = new AddEditCustomerWindow { DataContext = addCustomerViewModel };
                addCustomerWindow.ShowDialog();
            }
        }

        private bool CanDeleteCustomer(object parameter) => SelectedCustomer != null;

        private void OpenAddCustomerWindow(object parameter)
        {
            // Implementieren Sie die Logik zum Öffnen des AddCustomerWindow
            // z.B. indem Sie eine neue Instanz des Fensters erstellen und anzeigen
            var addCustomerWindow = new AddEditCustomerWindow();
           
            addCustomerWindow.ShowDialog();
        }
    }



}
