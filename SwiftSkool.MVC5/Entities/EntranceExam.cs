using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.Entities
{
    public class EntranceExam : Entity
    {
        public EntranceLevel ClassOfEntry { get; set; }

        [Range(0,100)]
        public double TermTotal { get; set; }

        [Range(0,100)]
        public double CutoffScore { get; set; }

        public DateTime RegistrationDate { get; set; }

        public EntranceAcceptance AcceptanceStatus { get; set; }
        
        // establishing relationship between entrance exam and exam subjects
        public List<EntranceExamSubject> ExamSubjects { get; set; }

        // establishing relationship between entrance exam and exam candidates
        public int EntranceExamCandidateId { get; set; }
        public List<EntranceExamCandidate> EntranceExamCandidates { get; set; }

    }
}
