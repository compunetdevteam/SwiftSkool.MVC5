﻿using SwiftSkool.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SwiftSkool.Entities
{
    public class Result : Entity
    {
        private List<ContinuousAssessment> _ca;

        private Result()
        {

        }

        public Result(Student student, Subject subject, SchoolSession session,
            List<ContinuousAssessment> ca)
        {
            if(student.Id != 0 && subject.Id != 0 && session.Id != 0 && ca.Any())
            {
                Student = student;
                Subject = subject;
                SchoolSession = session;
                _ca = ca;
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

        public List<ContinuousAssessment> ContinuousAssessments
        {
            get
            {
                return _ca;
            }
        }

        public double TermTotal { get; private set; }

        public double ClassAverage { get; private set; }

        public string Position { get; private set; }

        public string Status { get; private set; }


        public void SetStatus()
        {

        }

        public void CalculateTermAverage()
        {

        }

        public void CalculateSubjectAverage()
        {
            var scores = ContinuousAssessments.Where(x => x.ResultId == Id).Sum(x => x.Score);
            var students = Student.Subjects.Count;
            ClassAverage = scores / students;
        }

        public void SumCAScoreOverHundred()
        {
            TermTotal = ContinuousAssessments.Where(x => x.ResultId.Value == Id.Value)
                                              .Sum(s => s.Score) / 100;
        }

        public void AllocatePosition()
        {

        }

        public void AllocateRemark()
        {

        }
    }

}
