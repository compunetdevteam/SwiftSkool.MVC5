using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System.Collections.Generic;

namespace SwiftSkool.Entities
{
    public class Subject : Entity
    {
        private List<Student> _students;

        private List<ApplicationUser> _teachers;

        public Subject(string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                Name = name;
            }

            _students = new List<Student>();
            _teachers = new List<ApplicationUser>();
        }

        private Subject()
        {

        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string SubjectCode { get; private set; }


        public List<ApplicationUser> Teachers
        {
            get
            {
                return _teachers;
            }
        }

        public List<Student> Students
        {
            get
            {
                return _students;
            }
        }

        public int? ScoreGradeId { get; private set; }

        public ScoreGrade ScoreGrade { get; private set; }

        public int? LessonPlanId { get; set; }

        public LessonPlan LessonPlan { get; set; }

        public void SetSubjectDetails(string description, string subjectcode)
        {
            if(!string.IsNullOrWhiteSpace(description) && string.IsNullOrWhiteSpace(subjectcode))
            {
                SubjectCode = subjectcode;
                Description = description;
            }
        }
        
    }
}
