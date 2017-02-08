using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftSkool.MVC5.Infrastructure
{
    public class DroppedSubjects
    {
        private ICollection<string> _droppedSubjects;


        public DroppedSubjects()
        {
            _droppedSubjects = new List<string>();
        }

        public DroppedSubjects AddSubject(string subjectname)
        {
            _droppedSubjects.Add(subjectname);
            return this;
        }

        public DroppedSubjects Done()
        {
            if (_droppedSubjects.Count > 3)
                throw new InvalidOperationException("The Maximum number of Subject to dropped cannot exceed 3");
            return this;
        }

        public IEnumerable<string> StudentsDroppedSubjects => _droppedSubjects.ToList();

    }
}