using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class LessonPlanViewModel
    {
        public string PlanDescription { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public int LessonPlanId { get; set; }
        public int Week { get; set; }
        public string Topic { get; set; }
        public string Discussions { get; set; }
        public string Evaluations { get; set; }
    }

    public class LessonPlanClassViewModel
    {
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int Week { get; set; }
        public string PlanDescription { get; set; }

    }
    public class LessonPlanSessionViewModel
    {
        public string Session { get; set; }
        public string Term { get; set; }
        public int Week { get; set; }
        public string PlanDescription { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
    }
}
