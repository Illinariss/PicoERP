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
    public partial class AddCustomerViewModel : ViewModelBase
    {
        #region Properties
        public int Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public string CompanyName;
        public string ContactPerson;
        public Address BillingAddress;
        public Address ShippingAddress;
        public BankAccount BankAccount;
        public bool SepaDirectDebit;
        public string PreferredContactMethod;
        public List<Document> Documents;
        public List<Invoice> Invoices;
        #endregion Properties

        #region Methods

        #endregion Methods
    }

}