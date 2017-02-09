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
        public string FullName { get; set; }
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
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Display(Name ="Guardian")]
        public int GuardianId { get; set; }

        public SelectList guardian { get; set; }
    }

    public class UpdateStudentInputModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public int Age { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Gender { get; set; }

        public string StudentPassport { get; set; }

        public string AdmissionNumber { get; set; }

        public string Country { get; set; }

        public bool Active { get; set; }

        public int ClassId { get; set; }

        public SelectList Class { get; set; }

        public int? ClubId { get; set; }

        public SelectList Club { get; set; }

        public int GuardianId { get; set; }

        public SelectList Guardian { get; set; }

        public int HostelId { get; set; }

        public SelectList Hostel { get; set; }

        public int MedicalHistoryId { get; set; }

        public SelectList MedicalHistory { get; set; }

        public int StateId { get; set; }

        public SelectList StateOfOrigin { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public IEnumerable<SelectList> Subjects { get; set; }

        public IEnumerable<SelectList> Payments { get; set; }
    }
}
