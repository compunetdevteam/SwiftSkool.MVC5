using SwiftSkool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class PaymentInputModel
    {
        public Guid UniquePaymentId { get; set; }
        public List<PaymentType> TypeOfPayment { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Session { get; set; }
        public string Term { get; set; }
        public DateTime PaymentDate { get; set; }
        public ModeOfPayment PaymentMode { get; set; }
        public string TellerNumber { get; set; }
        public string TransactionNumber { get; set; }
        
    }
}
