using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPicoErp.Models
{
    public class PaymentTerm
    {
        public int Id { get; set; }

        // Payment due date
        public int PaymentDueDays { get; set; }

        // Payment method
        public string PaymentMethod { get; set; }

        // Early payment discount
        public bool HasDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int DiscountDueDays { get; set; }

        // Installment payments
        public bool HasInstallments { get; set; }
        public int NumberOfInstallments { get; set; }

        // Late payment fees
        public decimal LatePaymentInterestRate { get; set; }
        public int LatePaymentInterestPeriod { get; set; } // Number of days or months

        // Collection process
        public bool HasCollectionProcess { get; set; }
        public string CollectionProcessDescription { get; set; }
    }

}
