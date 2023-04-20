using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfPicoErp.Models;

namespace WpfPicoErp.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        #region Properties
        public int Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Address;
        public string City;
        public string PostalCode;
        public string Country;
        public string Phone;
        public ObservableCollection<Customer> Customers;
        #endregion Properties


    }

}