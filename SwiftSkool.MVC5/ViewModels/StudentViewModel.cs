using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class CreateStudentViewModel
    {

    }
}
