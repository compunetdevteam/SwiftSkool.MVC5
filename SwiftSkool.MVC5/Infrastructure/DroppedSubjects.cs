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


        public DroppedSubjects(Subject subject, Subject subject1, Subject subject2)
        {
            _droppedSubjects = new List<Subject>();

            _droppedSubjects.Add(subject);
            _droppedSubjects.Add(subject1);
            _droppedSubjects.Add(subject2);
        }

        ///// <summary>
        ///// Requires a subject that a student desires to drop or not offer.
        ///// </summary>
        ///// <param name="subject">Subject</param>
        ///// <returns>DroppedSubjects</returns>
        //public DroppedSubjects AddSubject()
        //{
        //    return this;
        //}

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