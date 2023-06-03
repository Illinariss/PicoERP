using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WpfPicoErp.Context;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;
using WpfPicoErp.ViewModels.Windows;
using WpfPicoErp.Windows;

namespace WpfPicoErp.ViewModels.Pages
{
    public partial class InvoiceManagerViewModel : ViewModelBase
    {
        public InvoiceManagerViewModel()
        {
            PicoContext = new PicoDbContext();
            DeleteInvoiceCommand = new ParameteredRelayCommand(DeleteInvoice, InvoiceExists);
            OpenEditInvoiceWindowCommand = new ParameteredRelayCommand(EditInvoice, InvoiceExists);
            OpenAddInvoiceWindowCommand = new ParameteredRelayCommand(AddInvoice);

            LoadData();
        }

        private ObservableCollection<Invoice> _invoices;
        public ObservableCollection<Invoice> Invoices
        {
            get => _invoices;
            set
            {
                _invoices = value;
                OnPropertyChanged(nameof(Invoices));
            }
        }

        private Invoice _selectedInvoice;
        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                Debug.WriteLine("SelectedInvoice changed");
                OnPropertyChanged(nameof(SelectedInvoice));
            }
        }

        private void LoadData()
        {
            Invoices = new ObservableCollection<Invoice>(PicoContext.Invoices.ToList());
        }

        private void AddInvoice(object parameter)
        {
            SelectedInvoice = new Invoice();
            var addEditInvoiceViewModel = new AddEditInvoiceViewModel(PicoContext, SelectedInvoice);
            var addEditInvoiceWindow = new AddEditInvoiceWindow { DataContext = addEditInvoiceViewModel };
            addEditInvoiceWindow.ShowDialog();
        }

        private void EditInvoice(object parameter)
        {
            if (SelectedInvoice != null)
            {
                var addEditInvoiceViewModel = new AddEditInvoiceViewModel(PicoContext, SelectedInvoice);
                var addEditInvoiceWindow = new AddEditInvoiceWindow { DataContext = addEditInvoiceViewModel };               
                addEditInvoiceWindow.ShowDialog();
            }
        }

        private bool InvoiceExists(object parameter) => SelectedInvoice != null;

        private void DeleteInvoice(object parameter)
        {
            if (SelectedInvoice != null)
            {
                PicoContext.Remove(SelectedInvoice);
                Invoices.Remove(SelectedInvoice);
            }
        }

        public PicoDbContext PicoContext { get; private set; }
        public ParameteredRelayCommand DeleteInvoiceCommand { get; private set; }
        public ParameteredRelayCommand OpenEditInvoiceWindowCommand { get; private set; }
        public ParameteredRelayCommand OpenAddInvoiceWindowCommand { get; private set; }

    }
}
