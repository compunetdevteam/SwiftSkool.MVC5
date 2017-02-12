using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Entities
{
    public class KeyToRating : Entity
    {

        public string Punctuality { get; set; }

        public string Attendance { get; set; }

        public string Attentiveness { get; set; }

        public string Assignments { get; set; }

        public string ActivityParticipation { get; set; }

        public string Creativity { get; set; }

        public string Neatness { get; set; }

        public string Honesty { get; set; }

        public string HandWriting { get; set; }

        public string SelfControl { get; set; }

        public string SocialSkills { get; set; }

        public string Sports { get; set; }

        public int BehaviourActivityId { get; set; }

        public BehaviourActivity BehaviourActivity { get; set; }

    }
}
