using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfPicoErp.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }  // ProductId ist nun nullable
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Neue Eigenschaften
        public string GroupName { get; set; }
        public decimal SubTotal { get { return Quantity * Price; } }

        // Navigation Properties
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}