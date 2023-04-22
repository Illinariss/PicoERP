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
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public BankAccount BankAccount { get; set; }
        public bool SepaDirectDebit { get; set; }
        public string PreferredContactMethod { get; set; }
        public List<Document> Documents { get; set; }
        public List<Invoice> Invoices { get; set; }
    }


}