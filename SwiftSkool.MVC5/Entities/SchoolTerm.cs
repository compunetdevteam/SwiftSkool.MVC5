using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.Entities
{
    public class SchoolTerm : Entity
    {
        private SchoolTerm()
        {
        }

        public SchoolTerm(string termname, DateTime startterm, DateTime endterm)
        {
            
        }

        public string TermName { get; private set; }

        public DateTime? TermStarts { get; private set; }

        public DateTime? TermEnds { get; private set; }

        public bool MidTermBreak { get; private set; }

        public DateTime? MidTermStarts { get; private set; }

        public DateTime? MidTermEnds { get; private set; }

        public int SchoolSessionId { get; set; }

        public SchoolSession SchoolSession { get; private set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<LessonPlan> LessonPlans { get; set; }

        public void PrepareTerm(string termname, DateTime startterm, DateTime endTerm)
        {
            TermName = termname;
            TermStarts = startterm;
            TermEnds = endTerm;
        }

        public void SetMidTermBreak(DateTime startsAt, DateTime endsAt, bool ApproveMidTerm)
        {
            if (!ApproveMidTerm)
                return;
            MidTermBreak = true;
            MidTermStarts = startsAt;
            MidTermEnds = endsAt;
        }
    }
}