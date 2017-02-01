using System;
using System.Collections.Generic;
using SwiftSkool.MVC5.Entities;

namespace SwiftSkool.MVC5.ViewModels
{
    public class TeacherInputModel
    {
        public string TeacherId { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string StateOfOrigin { get; set; }
        public string LocalGovtArea { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Qualifications Qualifications { get; set; }
        public string TeacherPassport { get; set; }
        public List<Subject> Subject { get; set; }
        public Address ResidentialAddress { get; set; }
        public List<LessonPlan> LessionPlan { get; set; }


    }

    public class TeacherToSubjectInputModel
    {
        public int SubjectID { get; set; }
        public string TeacherID { get; set; }
    }

       
}