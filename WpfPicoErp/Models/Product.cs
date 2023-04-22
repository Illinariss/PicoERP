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

        
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public ICollection<ProductFile> Files { get; set; } = new List<ProductFile>();
    }
}