using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Infrastructure;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwiftSkool.MVC5.Entities
{
    public class Student : Entity
    {

        private  Student()
        {
            
        }

        public Student(Address addy, Guardian relative, string firstname, string lastname, 
            DateTime admissionDate)
        {
            if (relative.Id.Value == 0 && addy == null)
                throw new ArgumentException("Student cannot be created without an address and a Guardian!");
            Address = addy;
            Guardian = relative;
            FirstName = firstname;
            LastName = lastname;
            AdmissionDate = admissionDate;
            Active = true;
        }

        public Student(Guardian relative, string firstname, string lastname)
        {
            if(relative.Id == 0 && string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentException("Student cannot be created with out a Guardian and Ward names!");
            }

            Guardian = relative;
            FirstName = firstname;
            LastName = lastname;
            Active = true;
        }
        
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string OtherName { get; private set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int Age { get; private set; }


        public DateTime DateOfBirth { get; private set; }

        public string Email { get; private set; }

        public DateTime AdmissionDate { get; private set; }

        public string Gender { get; private set; }

        public string StudentPassport { get; private set; }

        public string AdmissionNumber { get; private set; }

        public string Country { get; private set; }

        public bool Active { get; private set; }


        public int? AttendanceId { get; private set; }

        public Attendance Attendance { get; private set; }

        public int? ClassId { get; private set; }

        public Class Class { get; private set; }

        public int? ClubId { get; private set; }

        public Club Club { get; private set; }

        public int GuardianId { get; private set; }

        public Guardian Guardian { get; private set; }

        public int? HostelId { get; private set; }

        public Hostel Hostel { get; private set; }

        public int? MedicalHistoryId { get; private set; }

        public MedicalHistory MedicalHistory { get; private set; }

        public int? StateId { get; private set; }

        public State StateOfOrigin { get; private set; }

        public Address Address { get;  private set; }

        public ICollection<Subject> Subjects { get; private set; }

        public ICollection<Payment> Payments { get; private set; }

        public ICollection<Result> Results { get; private set; }

        public Student PrepareStudent(string firstname, string lastname, string gender, DateTime dob,
            string passport,Address add)
        {
            if(!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) &&
                !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(passport) && dob != null)
            {
                FirstName = firstname;
                LastName = lastname;
                Gender = gender;
                StudentPassport = passport;
                Address = add;
                DateOfBirth = dob;
                var t = DateOfBirth - DateTime.Now;
                Age = (int)t.Days / 365;
                return this;
            }
            throw new ArgumentException("Invalid values were provided to create student");
        }

        public void GenerateStudentAdmissionNumber()
        {
            //1. Student vital info (names address age and gender have been provided
            //2. Admission Date must be a valid date

        }

        public void AssignStudentToClass(Class studentclass)
        {
            Class = studentclass;
            ClassId = studentclass.Id.Value;
        }

        /// <summary>
        /// Returns the list of subjects a student offers after giving
        /// DroppedSubjects
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public IEnumerable<Subject> DropSubjects(DroppedSubjects ds)
        { 
            ds.Done();
            return Subjects.Except(ds.StudentsDroppedSubjects);
        }

        public void UpdateStudentDetails(UpdateStudentVM model, Class studentclass, Club club, Hostel house)
        {
            if (model == null)
                return;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Gender = model.Gender;
            Email = model.Email;
            DateOfBirth = model.DateOfBirth;
            Address.UpdateAddress(model.Street1 + model.Street2, model.NameOfArea, model.City, "");
            Class = studentclass;
            Club = club;
            Hostel = house;
        }

        public void DeactivateGraduatingStudent()
        {
            //determine students graduating status and based on it
            //change the active status of student to false for deactivated
        }

        public void DeactivateTransferredStudent()
        {

        }
    }
}
