using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WpfPicoErp.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string InternalProductNumber { get; set; }
        public string ExternalProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public decimal Weight { get; set; }
        public string ShippingInformation { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();        
    }
}