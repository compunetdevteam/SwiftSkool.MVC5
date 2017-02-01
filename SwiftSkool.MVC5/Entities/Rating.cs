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
    public class Rating : Entity
    {
        public string RatingGrade { get; set; }

        public string Description { get; set; }

        public int BehaviourActivityId { get; set; }

        public BehaviourActivity BehaviourActivity { get; set; }

    }
}
