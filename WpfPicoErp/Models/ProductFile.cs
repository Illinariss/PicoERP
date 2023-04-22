using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPicoErp.Models
{
    public class ProductFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
