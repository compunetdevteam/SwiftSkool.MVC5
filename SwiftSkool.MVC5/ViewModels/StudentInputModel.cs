using System;
using SwiftSkool.Entities;
using static SwiftSkool.MVC5.ViewModels.SubjectViewModel;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.ViewModels
{
    public class StudentInputModel
    {
        public string StudentID { get; set; }
        public bool Activate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string State { get; set; }
        public Attendance Attendance { get; set; }
        public string Class { get; set; }
        public string Club { get; set; }
        public string Hostel { get; set; }
        public string MedicalHistory { get; set; }
        public string StudentPassPort { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guardian Guardian { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
