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

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get => _dialogResult;
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    OnPropertyChanged(nameof(DialogResult));
                }
            }
        }

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

        private bool CustomerValid()
        {
            //TODO Sinnvolle Prüfung hinzufügen.
            return true;
        }

        private void Save()
        {
            DialogResult = true;
        }

        #endregion Properties

        #region Methods



        #endregion Methods
    }

}