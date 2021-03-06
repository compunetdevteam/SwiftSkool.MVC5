﻿using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftSkool.MVC5.Entities
{
    public class ContinuousAssessment : Entity
    {
        public ContinuousAssessment(double score, string name, Subject subject, Result result)
        {
            if(!name.Contains("exams") || !name.Contains("Exams") || !name.Contains("Exam")
                || !name.Contains("exam") && score >=30)
            {
                throw new
                    ArgumentOutOfRangeException("The score entered cannot be over 30 for non examinations!");
            } else if(subject.Id.Value != 0 && result.Id.Value != 0)
            {
                Score = score;
                Name = name;
                Subject = subject;
                Result = result;
            }
        }

        [Range(0,100)]
        public double Score { get; private set; }

        public string Name { get; private set; }

        public Subject Subject { get; private set; }

        public int SubjectId { get; private set; }

        public Result Result { get; private set; }

        public int? ResultId { get; private set; }

        public void UpdateCA(int? subjectid, string name, double? score)
        {
            if(subjectid.Value != 0 && !string.IsNullOrWhiteSpace(name))
            {
                SubjectId = subjectid.Value;
                Name = name;
                Score = score.Value;
            }
        }
        
    }
}
