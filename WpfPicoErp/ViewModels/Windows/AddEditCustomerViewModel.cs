using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Interfaces;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;

namespace WpfPicoErp.ViewModels.Windows
{
    public partial class AddEditCustomerViewModel : ViewModelBase, ISaveCancelViewModel
    {
        #region Properties
        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    OnPropertyChanged(nameof(Customer));
                }
            }
        }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public AddEditCustomerViewModel(Customer customer)
        {
            Customer = customer;
        }

        #endregion Properties

    }

}