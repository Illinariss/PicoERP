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
            DeleteCustomerCommand = new ParameteredRelayCommand(DeleteCustomer, CustomerExists);
            OpenEditCustomerWindowCommand = new ParameteredRelayCommand(EditCustomer, CustomerExists);
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

        private void DeleteCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                //TODO: Sicherheitsabfrage
                PicoContext.Remove(SelectedCustomer);
                Customers.Remove(SelectedCustomer);
            }
        }
        private void EditCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                var addCustomerViewModel = new AddEditCustomerViewModel(SelectedCustomer);
                var addCustomerWindow = new AddEditCustomerWindow { DataContext = addCustomerViewModel };
                addCustomerViewModel.CancelCommand = new RelayCommand(() => {
                    PicoContext.Entry(SelectedCustomer).Reload();
                    addCustomerWindow.Close(); 
                });
                addCustomerViewModel.SaveCommand = new RelayCommand(() => 
                {
                    if (PicoContext.SaveChanges() > 0)
                    {
                        addCustomerWindow.Close();
                    }
                    else
                    {
                        //todo: fehlermeldung speichern fehlgeschlagen.
                    }
                });
                addCustomerWindow.ShowDialog();
            }
        }

        private bool CustomerExists(object parameter) => SelectedCustomer != null;

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
                    //todo: fehlermeldung speichern fehlgeschlagen.
                }
                addCustomerWindow.Close();
            });
            addCustomerWindow.ShowDialog();
        }
    }



}
