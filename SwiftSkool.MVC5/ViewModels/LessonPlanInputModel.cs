using SwiftSkool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class LessonPlanInputModel
    {
        public int LessonPlanId { get; set; }
        public string PlanDescription { get; set; }
        public string Session { get; set; }
        public Term Term { get; set; }
        public int Week { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClassLevel { get; set; }
        public string Class { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string Topic { get; set; }
        public string Discussions { get; set; }
        public string Evaluations { get; set; }
        public string RecommendedTexts {get; set;}

    }
}
