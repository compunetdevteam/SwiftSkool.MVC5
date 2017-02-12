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
    public class EntranceExamCandidate : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double TermTotal { get; set; }

        // establishing the relationship that exists between candidates and subjects written
        public List<EntranceExamSubject> ExamSubjects { get; set; }

        // establishing the relationship that exists between candidates and entrance exam.
        public int EntranceExamId { get; set; }

        public EntranceExam EntranceExam { get; set; }
        
    }
}
