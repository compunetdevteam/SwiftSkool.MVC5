

using AutoMapper;
using SwiftSkool.MVC5.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwiftSkool.MVC5.ViewModels
{

    public class GuardianProfile : Profile
    {
        public GuardianProfile()
        {
            CreateMap<GuardianDetailsVM, Guardian>()
                .ForMember(d => d.Students, opt => opt.MapFrom(
                    q => q.RelatedStudents)).ReverseMap();
            CreateMap<Guardian, GuardianIndexVM>();
        }
    }


    public class GuardianViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        [Display(Name ="Mobile Number")]
        public string PhoneNumber { get; set; }

        public string Occupation { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name =" Area Name")]
        public string NameOfArea { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }
    }

    public class GuardianIndexVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GuardianId { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }

    public class GuardianDetailsVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<StudentViewModel> RelatedStudents { get; set; }

        public Address Address { get; set; }
    }

    public class UpdateGuardianVM
    {

    }
}