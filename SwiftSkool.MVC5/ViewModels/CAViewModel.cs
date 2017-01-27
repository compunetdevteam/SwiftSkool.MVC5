using AutoMapper;
using SwiftSkool.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{

    public class CAProfile : Profile
    {
        public CAProfile()
        {
            CreateMap<ContinuousAssessment, CAViewModel>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(
                    q => q.Subject.Name))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(
                    q => q.Result.Student.FirstName + " " + q.Result.Student.LastName))
                .ForMember(dest => dest.StudentClass, opt => opt.MapFrom(
                    q => q.Result.Student.Class.Level + q.Result.Student.Class.ClassName +
                    q.Result.Student.Class.Section))
                .ForMember(dest => dest.StudentAdmissionNumber, opt => opt.MapFrom(
                    q => q.Result.Student.AdmissionNumber));
            CreateMap<ContinuousAssessment, CAEditViewModel>()
                .ForMember(dest => dest.CAId, opt => opt.MapFrom(
                    q => q.Id))
                .ForMember(dest => dest.CAName, opt => opt.MapFrom(
                    q => q.Name)).ReverseMap();
            CreateMap<ContinuousAssessment, CAIndexViewModel>()
                .ForMember(d => d.SubjectName, o => o.MapFrom(
                    q => q.Subject.Name))
                .ForMember(d => d.CAName, o => o.MapFrom(
                    q => q.Name))
                .ForMember(d => d.CAId, o => o.MapFrom(
                    q => q.Id.Value))
                .ForMember(d => d.CAScore, o => o.MapFrom(
                    q => q.Score))
                .ForMember(d => d.StudentName, o => o.MapFrom(
                    q => q.Result.Student.FirstName+" "+q.Result.Student.LastName));

        }
    }


    public class CAViewModel
    {
        public string Name { get; set; }

        public double Score { get; set; }

        public int Id { get; set; }

        public string SubjectName { get; set; }

        public string StudentName { get; set; }

        public string StudentClass { get; set; }

        public string StudentAdmissionNumber { get; set; }
    }

    public class CAIndexViewModel
    {
        public int CAId { get; set; }

        public string CAName { get; set; }

        public double CAScore { get; set; }

        public string SubjectName { get; set; }

        public string StudentName { get; set; }
    }

    public class CreateCAViewModel
    {
        public string CAName { get; set; }

        public double? Score { get; set; }

        [Display(Name ="Results")]
        public int ResultId { get; set; }

        public SelectList Results { get; set; }

        [Display(Name ="Subject")]
        public int SubjectId { get; set; }

        public SelectList Subject { get; set; }

    }

    public class CAEditViewModel
    {
        public int CAId { get; set; }

        public string CAName { get; set; }

        public double? Score { get; set; }

        public int ResultId { get; set; }

    }

    public class CAUpdateViewModel
    {
        public int CAId { get; set; }

        public string CAName { get; set; }

        public int SubjectId { get; set; }

        public SelectList Subject { get; set; }

        public double Score { get; set; }

        public string StudentName { get; set; }

        public string AdmissionNumber { get; set; }


    }
}
