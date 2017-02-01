using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Entities
{
    public class PaymentType : Entity
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

    }
}
