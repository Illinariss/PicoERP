using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Context;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;
using WpfPicoErp.Windows;
using WpfPicoErp.ViewModels.Windows;

namespace WpfPicoErp.ViewModels.Pages
{

    public partial class CustomerManagerViewModel : ViewModelBase
    {

        public CustomerManagerViewModel()
        {
            PicoContext = new PicoDbContext();
            DeleteCustomerCommand = new ParameteredRelayCommand(DeleteCustomer, CanDeleteCustomer);
            OpenEditCustomerWindowCommand = new ParameteredRelayCommand(EditCustomer);
            OpenAddCustomerWindowCommand = new ParameteredRelayCommand(AddCustomer);

            LoadData();
        }

        private void LoadData()
        {
            Customers = new ObservableCollection<Customer>(PicoContext.Customers.ToList());
            var foo = "bar";
        }

        public PicoDbContext PicoContext { get; }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }


        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                Debug.WriteLine("SelectedCustomer changed");
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public ICommand DeleteCustomerCommand { get; }
        public ICommand OpenEditCustomerWindowCommand { get; }
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
                addCustomerViewModel.CancelCommand = new RelayCommand(() => { addCustomerViewModel.DialogResult = false; addCustomerWindow.Close(); });
                addCustomerViewModel.SaveCommand = new RelayCommand(() => { addCustomerViewModel.DialogResult = true; addCustomerWindow.Close(); });
                var dialogresult = addCustomerWindow.ShowDialog();
                if (dialogresult ?? false)
                {
                    PicoContext.SaveChanges();
                }
            }
        }

        private bool CanDeleteCustomer(object parameter) => SelectedCustomer != null;

        private void AddCustomer(object parameter)
        {
            SelectedCustomer = new Customer();
            var addCustomerViewModel = new AddEditCustomerViewModel(SelectedCustomer);
            var addCustomerWindow = new AddEditCustomerWindow { DataContext = addCustomerViewModel };
            addCustomerViewModel.CancelCommand = new RelayCommand(() =>
            {
                SelectedCustomer = null;
                addCustomerWindow.Close();
            });
            addCustomerViewModel.SaveCommand = new RelayCommand(() =>
            {
                PicoContext.Add(SelectedCustomer);
                if (PicoContext.SaveChanges() > 0)
                {
                    Customers.Add(SelectedCustomer);
                }
                else
                {
                    //TODO speichern fehlgeschlagen
                }
                addCustomerWindow.Close();
            });
            var dialogresult = addCustomerWindow.ShowDialog();

        }
    }



}
