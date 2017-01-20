using AutoMapper;
using SwiftSkool.Entities;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{

    public class CAProfile : Profile
    {
        public CAProfile()
        {
            CreateMap<ContinuousAssessment, CAViewModel>()
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(
                    q => q.Subject.Name));
            CreateMap<ContinuousAssessment, CAEditViewModel>()
                .ForMember(dest => dest.CAId, opt => opt.MapFrom(
                    q => q.Id))
                .ForMember(dest => dest.CAName, opt => opt.MapFrom(
                    q => q.Name)).ReverseMap();
        }
    }


    public class CAViewModel
    {
        public string Name { get; set; }

        public double Score { get; set; }

        public int Id { get; set; }

        public string Subject { get; set; }
    }

    public class CACreateViewModel
    {
        public string CAName { get; set; }

        public double? Score { get; set; }

        public int ResultId { get; set; }

        public SelectList Result { get; set; }

    }

    public class CAEditViewModel
    {
        public int CAId { get; set; }

        public string CAName { get; set; }

        public double? Score { get; set; }

        public int ResultId { get; set; }

    }
}
