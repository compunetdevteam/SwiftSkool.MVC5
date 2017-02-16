using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.MVC5.Entities
{
    public class SchoolSession : Entity
    {

        private SchoolSession()
        {

        }

        public SchoolSession(string sessionname)
        {
            if(!string.IsNullOrWhiteSpace(sessionname))
            {
                SessionName = sessionname;
            }
        }

        public string SessionName { get; private set; }

        public int? SchoolId { get; private set; }

        public School School { get; private set; }

        public ICollection<SchoolTerm> SchoolTerms { get; private set; }

        public ICollection<Result> Results { get; private set; }
    }
}
