using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfPicoErp.Context;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;

namespace WpfPicoErp.ViewModels.Windows
{
    public class AddEditInvoiceViewModel : ViewModelBase
    {
        private readonly PicoDbContext _context;
        private Invoice _invoice;

        public ObservableCollection<InvoiceItem> Items { get; }
        public ObservableCollection<Customer> Customers { get; }
        public ObservableCollection<Product> Products { get; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditInvoiceViewModel(PicoDbContext context, Invoice invoice = null)
        {
            _context = context;
            _invoice = invoice ?? new Invoice();

            // Initialize collections

            Items =  new ObservableCollection<InvoiceItem>(_invoice.InvoiceItems);
            Customers = new ObservableCollection<Customer>(_context.Customers.ToList());
            Products = new ObservableCollection<Product>(_context.Products.ToList());

            // Initialize commands
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            // Update invoice items
            _invoice.InvoiceItems.Clear();
            foreach (var item in Items)
            {
                _invoice.InvoiceItems.Add(item);
            }

            // Add or update invoice in context
            if (_context.Entry(_invoice).State == EntityState.Detached)
            {
                _context.Invoices.Add(_invoice);
            }

            _context.SaveChanges();

            // Close window
            CloseWindow();
        }

        private void Cancel()
        {
            // Discard changes and close window
            CloseWindow();
        }

        private void CloseWindow()
        {
            // Assuming that this ViewModel is data context of the window
            // We can find window and close it.
            if (Application.Current.MainWindow.DataContext == this)
            {
                Application.Current.MainWindow.Close();
            }
        }
    }


}
