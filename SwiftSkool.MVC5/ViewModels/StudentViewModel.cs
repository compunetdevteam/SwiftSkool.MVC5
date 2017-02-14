using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{
    public class StudentViewModel
    {
        public string id { get; set; }
        public string AdmissionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Hostel { get; set; }
        public string Class { get; set; }
        public DateTime AdmissionDate { get; set; }
    }

    public class StudentGuardianViewModel
    {
        public string AdmissionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
        public string Class { get; set; }
        public string PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }

    }

    public class StudentAcademicViewModel
    {
        public string FullName { get; set; }
        public int StudentId { get; set; }
        public string AdmissionNumber { get; set; }
        public string Class { get; set; }
        public string House { get; set; }
    }

    public class StudentAddressViewModel
    {
        public string FullName { get; set; }
        public string AdmissionNumber { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
    }

    public class StudentSubjectViewModel
    {
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }

    public class CreateStudentInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name ="Admission Date")]
        public DateTime AdmissionDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name of Area")]
        public string NameOfArea { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Display(Name ="Guardian")]
        public int GuardianId { get; set; }

        public SelectList Guardian { get; set; }
    }

    public class UpdateStudentVM
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Other Names")]
        [DataType(DataType.Text)]
        public string OtherName { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:yyyy-MM-dd", ApplyFormatInEditMode =true)]
        public DateTime AdmissionDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        public string StudentPassport { get; set; }

        [Required]
        [Display(Name ="Admission Number")]
        public string AdmissionNumber { get; set; }

        [Display(Name ="Country of Origin")]
        public string Country { get; set; }

        public bool Active { get; set; }

        [Display(Name ="Student Class")]
        [Required]
        public int ClassId { get; set; }

        public SelectList Class { get; set; }

        [Required]
        [Display(Name ="Club")]
        public int? ClubId { get; set; }

        public SelectList Club { get; set; }

        [Required]
        [Display(Name = "Guardian")]
        public int GuardianId { get; set; }

        public SelectList Guardian { get; set; }

        [Required]
        [Display(Name = "Hostel")]
        public int HostelId { get; set; }

        public SelectList Hostel { get; set; }

        [Required]
        [Display(Name = "State Of Origin")]
        public int StateId { get; set; }

        public SelectList StateOfOrigin { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Street1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Street2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string NameOfArea { get; set; }

        public IEnumerable<SelectList> Subjects { get; set; }
    }
}
