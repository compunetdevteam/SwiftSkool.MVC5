using AutoMapper;
using SwiftSkool.MVC5.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{

    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultViewModel>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(
                    q => new StudentViewModel {
                        OtherName = q.Student.OtherName,
                        FirstName = q.Student.FirstName,
                        LastName = q.Student.LastName,
                        AdmissionDate = q.Student.AdmissionDate,
                        AdmissionNumber = q.Student.AdmissionNumber,
                        Class = q.Student.Class.ClassName + q.Student.Class.Section,
                        Hostel = q.Student.Hostel.Name,
                        id = q.Student.Id.Value
                    }))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(
                    q => Mapper.Map<Subject, SimpleSubjectViewModel>(q.Subject)))
                .ForMember(d => d.CA, opt =>
                opt.MapFrom(q => Mapper.Map<ContinuousAssessment, CAViewModel>
                (q.ContinuousAssessments.Single())))
                .ForMember(d => d.Session, opt => opt.MapFrom(src => src.SchoolTerm.SchoolSession.SessionName));            CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.OtherName, opt => opt.MapFrom(
                    q => q.FirstName + " " + q.LastName)).ReverseMap();

            CreateMap<StudentViewModel, Student>();
            CreateMap<ContinuousAssessment, CAViewModel>();
            CreateMap<Subject, SimpleSubjectViewModel>();
        }
    }
    public class ResultViewModel
    {
        
        public int ResultId { get; set; }

        [Display(Name ="Continuous Assessment")]
        public CAViewModel CA { get; set; }

        [Display(Name = "Student")]
        public StudentViewModel Student { get; set; }

        public SimpleSubjectViewModel Subject { get; set; }

        public string Term { get; set; }

        public string Session { get; set; }

        public double TermTotal { get; set; }

        public double ClassAverage { get; set; }

        public string Grade { get; set; }

        public string Position { get; set; }
    }

    public class ResultViewModelOld
    {
        [DataType(DataType.Text)]
        [Display(Name="Admission Number")]
        [StringLength(15)]
        public string StudentAdmissionNumber { get; set; }

        [StringLength(30)]
        [Display(Name="Student Name")]
        [DataType(DataType.Text)]
        public string StudentFullName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name="Subject")]
        [StringLength(20)]
        public string SubjectName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Term")]
        [StringLength(10)]
        public string Term { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Term Work")]
        [StringLength(15)]
        public string TermWork { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        [StringLength(10)]
        public string Class { get; set; }

        
        [Display(Name = "First Assignment")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double AssignmentScore1 { get; set; }

        [Display(Name = "Second Assignment")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AssignmentScore2 { get; set; }

        [Display(Name = "Exams Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ExamScore { get; set; }

        [Display(Name = "First Test")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TestScore1 { get; set; }

        [Display(Name = "Second Test")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TestScore2 { get; set; }

        [Display(Name = "Class Project")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Project { get; set; }

        [Display(Name = "Average Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AverageScore { get; set; }

        [StringLength(2)]
        [Display(Name="Score Grade")]
        public string Grade { get; set; }

        [StringLength(5)]
        [Display(Name = "Class Position")]
        public string Position { get; set; }

        [Display(Name = "Total Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TermTotal { get; set; }

        [Display(Name ="Updated At")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name ="Modified By")]
        [DataType(DataType.Text)]
        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Created By")]
        [DataType(DataType.Text)]
        [StringLength(25)]
        public string CreatedBy { get; set; }

        [Display(Name ="ResultId")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int Id { get; set; }

    }

    public class StudentResultCAViewModel
    {

        [StringLength(20)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [StringLength(20)]
        [Display(Name = "Admission Number")]
        public string StudentAdmissionNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "Assessment Name")]
        public string CAName { get; set; }

        [StringLength(2)]
        [Display(Name = "Score Grade")]
        public string Grade { get; set; }

        [Display(Name = "Total Score")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Score { get; set; }
    }

    public class CreateResultViewModel
    {
        [Display(Name ="Select Student :")]
        public int StudentId { get; set; }

        public SelectList Student { get; set; }

        [Display(Name = "Select Subject :")]
        public int SubjectId { get; set; }

        public SelectList Subject { get; set; }

        [Display(Name ="Select Term :")]
        public int SchoolTermsId { get; set; }

        public SelectList SchoolTerms { get; set; }
    }

    public class UpdateResultViewModel
    {
        public int ResultId { get; set; }

        public int StudentId { get; set; }

        public SelectList Students { get; set; }

        public int SchoolSessionId { get; set; }

        public SelectList SchoolSessions { get; set; }

        public int SubjectId { get; set; }

        public SelectList Subjects { get; set; }

        public int ScoreGradeId { get; set; }

        public SelectList ScoreGrade { get; set; }

        public double TermTotal { get; set; }

        public double SubjectAverage { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }


    }
}
