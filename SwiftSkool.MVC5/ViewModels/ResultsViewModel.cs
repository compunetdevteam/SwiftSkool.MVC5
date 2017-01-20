using SwiftSkool.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{
    public class ResultsViewModel
    {
        public ResultsViewModel()
        {

        }

        [Display(Name = "Students")]
        [Required]
        public int StudentId { get; set; }

        public SelectList Students { get; set; }

        [Display(Name = "Subjects")]
        public int SubjectId { get; set; }

        public SelectList Subjects { get; set; }

        [Display(Name = "Term")]
        public Term SessionTerms { get; set; }

        [Display(Name = "Continuous Assessment")]
        public int CAId { get; set; }

        public SelectList ContinuousAssessments { get; set; }

        [Display(Name = "Continuous Assessment Score")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double CAScore { get; set; }

        [Display(Name = "School Year")]
        public int SchoolSessionId { get; set; }

        public SelectList Session { get; set; }

        [Display(Name = "Class")]
        public int ClassId { get; set; }

        public SelectList Class { get; set; }

        [Display(Name = "Average Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AverageScore { get; set; }

        [Display(Name = "Term Total Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TermTotal { get; set; }
    }
}
