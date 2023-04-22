using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPicoErp.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankRoutingNumber { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string LogoPath { get; set; }
        public string SignaturePath { get; set; }
        public string InvoiceFooterText { get; set; }

        // Geschäftsführer Informationen
        public string CEOFirstName { get; set; }
        public string CEOLastName { get; set; }
        public string CEOTitle { get; set; }

        // Handelskammer Informationen
        public string ChamberOfCommerceName { get; set; }
        public string ChamberOfCommerceId { get; set; }

        // Navigation Properties
        public ICollection<Invoice> Invoices { get; set; }
    }

}
