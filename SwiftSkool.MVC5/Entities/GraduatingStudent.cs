using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftSkool.MVC5.Entities
{
    public class GraduatingStudent : Entity
    {
        public string FullName { get; set; }

        public DateTime? GraduationYear { get; set; }

        public string AdmissionNumber { get; set; }
    }
}