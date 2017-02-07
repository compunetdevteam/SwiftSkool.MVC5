using SwiftSkool.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SwiftSkool.MVC5.Entities
{
    public class Result : Entity
    {
        private Result()
        {

        }

        public Result(Student student, Subject subject, SchoolSession session)
        {
            if(student.Id != 0 && subject.Id != 0 && session.Id != 0)
            {
                Student = student;
                Subject = subject;
                SchoolSession = session;
            }
        }

        public int SchoolSessionId { get; private set; }

        public SchoolSession SchoolSession { get; private set; }

        public int StudentId { get; private set; }

        public Student Student { get; private set; }

        public int SubjectId { get; private set; }

        public Subject Subject { get; private set; }

        public int ScoreGradeId { get; private set; }

        public ScoreGrade ScoreGrade { get; private set; }

        public IEnumerable<ContinuousAssessment> ContinuousAssessments
        {
            get
            {
                return ContinuousAssessments.ToList(); //defensive copy of our sequence
            }
            private set
            {

            }
        }

        public double TermTotal { get; private set; }

        public double ClassAverage { get; private set; }

        public double SubjectAverage { get; private set; }

        public string Position { get; private set; }

        public string Status { get; private set; }

        public void CalculateClassAverage(SchoolSession session)
        {
            var result = ContinuousAssessments.Where(x => x.Result.SchoolSession == session).Sum(y => y.Score);
            var subjectsoffered = Student.Subjects.Count();
        }

        public void CalculateSubjectAverage()
        {
            var scores = ContinuousAssessments.Where(x => x.ResultId.Value == Id.Value).Sum(x => x.Score);
            var students = Subject.Students.Count;
            SubjectAverage = scores / students;
        }

        public void SumCAScore()
        {
            TermTotal = ContinuousAssessments.Where(x => x.ResultId.Value == Id.Value)
                                             .Sum(s => s.Score);
        }
    }
}
