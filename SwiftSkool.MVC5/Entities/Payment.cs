using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Entities
{
    public class Payment : Entity
    {
        public Payment(decimal amount)
        {
            if(amount != 0 || amount <= -1)
            {
                Amount = amount;
            }
        }
        public List<PaymentType> PaymentTypes { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool MakePayment(Student student, decimal payment, SchoolSession session, DateTime? paymentdate,
        PaymentType paymenttype)
        {
            //first check if the student is a valid student, what type
            return false;

        }
        
    }
}
