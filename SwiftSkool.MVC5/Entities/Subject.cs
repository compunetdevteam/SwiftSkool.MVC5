using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using System.Collections.Generic;
using System.Linq;

namespace SwiftSkool.MVC5.Entities
{
    public class Subject : Entity
    {

        public Subject(string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
        }

        private Subject()
        {

        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string SubjectCode { get; private set; }


        public ICollection<ApplicationUser> Teachers
        {
            get
            {
                return Teachers.ToList();
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return Students.ToList(); //Defensive Copy
            }
        }

        public int? ScoreGradeId { get; private set; }

        public ScoreGrade ScoreGrade { get; private set; }

        public int? LessonPlanId { get; private set; }

        public LessonPlan LessonPlan { get; private set; }

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
