using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SwiftSkool.MVC5.Entities
{
    public class Result : Entity
    {
        private Result()
        {

        }

        public Result(Student student, Subject subject, SchoolTerm term)
        {
            if(student.Id != 0 && subject.Id != 0 && term.Id != 0)
            {
                Student = student;
                Subject = subject;
                SchoolTerm = term;
            }
        }

        public int SchoolTermId { get; private set; }

        public SchoolTerm SchoolTerm { get; private set; }

        public int StudentId { get; private set; }

        public Student Student { get; private set; }

        public int SubjectId { get; private set; }

        public Subject Subject { get; private set; }

        public int ScoreGradeId { get; private set; }

        public ScoreGrade ScoreGrade { get; private set; }

        public ICollection<ContinuousAssessment> ContinuousAssessments { get; private set; }

        public double TermTotal { get; private set; }

        public double ClassAverage { get; private set; }

        public double SubjectAverage { get; private set; }

        public string Position { get; private set; }

        public string Status { get; private set; }

        public void CalculateClassAverage(SchoolTerm session)
        {
            var result = ContinuousAssessments.Where(x => x.Result.SchoolTerm == session).Sum(y => y.Score);
            var subjectsoffered = Student.Subjects.Count();
        }

        public void CalculateSubjectAverage(string classname)
        {
            var scores = ContinuousAssessments.Where(x => x.ResultId.Value == Id.Value).Sum(x => x.Score);
            var students = Subject.Students.Count(x => x.Class.ClassName == classname);
            SubjectAverage = scores / students;
        }

        public void SumCAScore()
        {
            TermTotal = ContinuousAssessments.Where(x => x.ResultId.Value == Id.Value)
                                             .Sum(s => s.Score);
        }
    }
}
