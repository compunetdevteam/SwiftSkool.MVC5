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
    public class EntranceExamSubject : Entity
    {
        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public string Description { get; set; }

        // establishing relationship that exist between exam subject and exam candidate.
        public int EntranceExamCandidateId { get; set; }

        public EntranceExamCandidate EntranceExamCandidate { get; set; }

        // establishing relationship that exist between exam subjects and entrance exam.
        public int EntranceExamId { get; set; }

        public EntranceExam EntranceExam { get; set; }
    }
}
