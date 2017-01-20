using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwiftSkool.Entities
{
    public class Student : Entity
    {

        private readonly List<Payment> payment;
        private readonly List<Result> result;
        private readonly List<Subject> subjects;

        private  Student()
        {
            
        }

        public Student(Address addy, Guardian relative)
        {
            payment = new List<Payment>();
            result = new List<Result>();
            subjects = new List<Subject>();
        }

        public Student(Guardian relative, string firstname, string lastname)
        {
            if(relative.Id != 0 && string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname))
            {
                Guardian = relative;
                FirstName = firstname;
                LastName = lastname;
            }
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

        public int HostelId { get; private set; }

        public Hostel Hostel { get; private set; }

        public int MedicalHistoryId { get; private set; }

        public MedicalHistory MedicalHistory { get; private set; }

        public int StateId { get; private set; }

        public State StateOfOrigin { get; private set; }

        public Address Address { get;  private set; }

        public List<Subject> Subjects
        {
            get
            {
                return subjects;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return payment;
            }
        }

        public List<Result> Results
        {
            get
            {
                return result;
            }
        }

        private void ValidateDependencies(Address addy, State whereufrom, Attendance uInClass, Class classUin,
            Club clubUin, Guardian relative, Hostel hostel, MedicalHistory medHis)
        {
            if(whereufrom.Id != 0 && whereufrom != null)
            {
                StateOfOrigin = whereufrom;
            }
            if(uInClass.Id != 0 && uInClass != null)
            {
                Attendance = uInClass;
            }
            if(classUin.Id != 0 && classUin != null)
            {
                Class = classUin;
            }
            if(clubUin.Id != 0 && clubUin != null)
            {
                Club = clubUin;
            }
            if(relative.Id != 0 && relative != null)
            {
                Guardian = relative;
            }
            if(hostel.Id != 0 && hostel != null)
            {
                Hostel = hostel;
            }
            if(medHis.Id != 0 && medHis != null)
            {
                MedicalHistory = medHis;
            }
            throw new ArgumentException("One or more dependencies are null or invalid!");
        }

        public Student PrepareStudent(string firstname, string lastname, string gender, DateTime dob,
            string passport)
        {
            if(!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) &&
                !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(passport) && dob != null)
            {
                FirstName = firstname;
                LastName = lastname;
                Gender = gender;
                StudentPassport = passport;
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

        //public async void AsignStudentToClass()
        //{

        //}
    }
}
