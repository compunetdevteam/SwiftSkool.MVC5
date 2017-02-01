using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Entities
{
    public class Report
    {
        public char Gender { get; set; }

        public string Class { get; set; }

        public string Term { get; set; }

        public DateTime TermEnding { get; set; }

        public DateTime NextTermBegins { get; set; }

        public int Year { get; set; }

        public string ReportFinalGrade { get; set; } //total grading for all results

        public double ReportFinalAverage { get; set; } //total average of all Totals

        public string ResultRemark { get; set; } //remark per result entry

        public string PrincipalRemark { get; set; } //come from scoregrade

        public string FormTeacherRemark { get; set; } //come from scoregrade

        public DateTime ReportGenerationDate { get; set; }

        public List<ResultViewModel> Results { get; set; }

        public double ReportFinalTotal { get; set; }  //total of all scores over 100

        public int NumberOfStudentsInClass { get; set; }

        public string FormTeacher { get; set; }

        public KeyToRating KeyToRating { get; set; }

        public StudentViewModel Student { get; set; }

        public void AllocatePosition()
        {
            //get all students scores per subject
            //
        }

        public void AllocateRemark()
        {

        }


    }
}
