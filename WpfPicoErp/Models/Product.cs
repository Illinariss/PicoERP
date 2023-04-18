using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfPicoErp.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        // Navigation properties
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}