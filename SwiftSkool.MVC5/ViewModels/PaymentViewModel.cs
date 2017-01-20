using SwiftSkool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class PaymentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdmissionNumber { get; set; }
        public List<PaymentType> PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }


        public class PaymentStatusViewModel
        {
            public PaymentStatus PaymentStatus { get; set; }
            public decimal AmountPaid { get; set; }
            public string FullName { get; set; }
            public string Class { get; set; }

        }

        public class PaymentStatusesViewModel
        {
            public string FullName { get; set; }
            public string Class { get; set; }
            public string Level { get; set; }
            public PaymentStatus PaymentStatus { get; set; }
            public string AdmissionNumber { get; set; }
            public decimal AmountPaid { get; set; }
        }
    }
}
