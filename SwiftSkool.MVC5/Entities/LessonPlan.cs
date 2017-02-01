using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System;

namespace SwiftSkool.MVC5.Entities
{
    public class LessonPlan : Entity
    {
        public SchoolSession Session { get; set; }

        public int SchoolSessionId { get; set; }

        public string ClassLevel { get; set; }

        public string Class { get; set; }

        public int Week { get; set; }

        public string Topic { get; set; }

        public string Discussions { get; set; }

        public string Evaluations { get; set; }

        public string RecommendedTexts { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PlanDescription { get; set; }

        public int TeacherId { get; set; }

        public ApplicationUser Teacher { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

    }
}
