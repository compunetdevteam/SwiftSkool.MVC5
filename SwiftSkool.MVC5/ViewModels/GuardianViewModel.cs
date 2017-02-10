

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
        [DataType(DataType.Text)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
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

        public string Address { get; set; }

        public int GuardianId { get; set; }
    }

    public class UpdateGuardianVM
    {
        [Display(Name ="First Name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public string Occupation { get; set; }

        [Display(Name ="Other Names")]
        [DataType(DataType.Text)]
        public string OtherNames { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Street Name")]
        public string StreetName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="House Number")]
        public string HouseNumber { get; set; }

        [Required]
        [Display(Name ="Name of Area")]
        [DataType(DataType.Text)]
        public string NameOfArea { get; set; }
        
        public int GuardianId { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string City { get; set; }

        [EnumDataType(typeof(Relationship))]
        public Relationship RelationshipToStudent { get; set; }

    }
}