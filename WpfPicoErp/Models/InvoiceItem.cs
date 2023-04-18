using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfPicoErp.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}