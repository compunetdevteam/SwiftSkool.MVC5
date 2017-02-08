using SwiftSkool.MVC5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftSkool.MVC5.Infrastructure
{
    public class DroppedSubjects
    {
        private List<Subject> _droppedSubjects;

        private List<Subject> addedsubs;


        public DroppedSubjects(Subject subject, Subject subject1, Subject subject2)
        {
            addedsubs = new List<Subject>();

            addedsubs.Add(subject);
            addedsubs.Add(subject1);
            addedsubs.Add(subject2);
        }

        /// <summary>
        /// Requires a subject that a student desires to drop or not offer.
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <returns>DroppedSubjects</returns>
        public DroppedSubjects AddSubject()
        {
            _droppedSubjects.AddRange(addedsubs);
            return this;
        }

        /// <summary>
        /// Called when adding subjects is complete. Will throw exception if more than 3 subjects
        /// are added to DroppedSubjects
        /// </summary>
        /// <returns>DroppedSubjects</returns>
        public DroppedSubjects Done()
        {
            if (_droppedSubjects.Count > 3)
                throw new InvalidOperationException("The Maximum number of Subject to dropped cannot exceed 3");
            return this;
        }

        public IEnumerable<Subject> StudentsDroppedSubjects => _droppedSubjects.ToList();

    }
}