using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.Entities
{
    public class LocalGovernment : Entity
    {

        public string Name { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }
    }
}
