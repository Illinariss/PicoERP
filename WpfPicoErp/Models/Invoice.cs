using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfPicoErp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        // Company information
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyUstIdNr { get; set; }

        // Billing address
        public string BillingCustomerName { get; set; }
        public string BillingAttention { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostalCode { get; set; }

        // Shipping address
        public string ShippingCustomerName { get; set; }
        public string ShippingAttention { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public decimal NetTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrossTotal { get; set; }

        public virtual PaymentTerm PaymentTerms { get; set; }
    }



}