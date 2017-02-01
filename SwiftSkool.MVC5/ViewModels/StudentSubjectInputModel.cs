using SwiftSkool.MVC5.Entities;
using System;

namespace SwiftSkool.MVC5.ViewModels
{
    public class StudentSubjectInputModel
    {
        public int SubjectId { get; set; }
        public SubjectViewModel Subject { get; set; }
        public double Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public SchoolSession Session { get; set; }
        
    }
}

