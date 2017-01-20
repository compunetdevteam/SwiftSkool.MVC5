using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.Entities
{
    public class SchoolSession : Entity
    {
        private readonly List<Result> _result;

        private SchoolSession()
        {

        }

        public SchoolSession(string sessionname, Term term, DateTime startingdate,
            DateTime enddate)
        {
            _result = new List<Result>();
            if(!string.IsNullOrWhiteSpace(sessionname) && term != 0 && startingdate != null
                && enddate != null)
            {
                SessionName = sessionname;
                Term = term;
                TermStarts = startingdate;
                TermEnds = enddate;
            }
        }

        public string SessionName { get; private set; }

        public Term Term { get; private set; }

        public DateTime TermStarts { get; private set; }

        public DateTime TermEnds { get; private set; }

        public int? SchoolId { get; private set; }

        public School School { get; private set; }

        public IEnumerable<Result> Results
        {
            get { return _result; }
        }
    }
}
