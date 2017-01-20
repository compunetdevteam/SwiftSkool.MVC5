using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System;
using System.Collections.Generic;

namespace SwiftSkool.Entities
{
    public class Attendance : Entity
    {
        public SchoolSession Session { get; set; }

        public int SessionId { get; set; }

        public List<Student> Students { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public string StatusDescription { get; set; }

        public int TeacherId { get; set; }

        public ApplicationUser FormTeacher { get; set; }

    }
}
