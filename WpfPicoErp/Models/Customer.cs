using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;

namespace WpfPicoErp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public bool SepaDirectDebit { get; set; }
        public string PreferredContactMethod { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }


}