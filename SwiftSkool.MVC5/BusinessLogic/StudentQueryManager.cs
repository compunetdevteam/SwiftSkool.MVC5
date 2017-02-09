using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class StudentQueryManager : IStudentQueryManager
    {
        private readonly SchoolDb db;

        public StudentQueryManager(SchoolDb _db)
        {
            db = _db;
        }

        public async Task<StudentViewModel> GetStudentByNameAsync(string name)
        {
            return await db.Students
                                .Include(s => s.Class)
                                .Where(s => s.FullName.Contains(name))
                                .Select(s => new StudentViewModel
                                {
                                    AdmissionNumber = s.AdmissionNumber,
                                    FirstName = s.FirstName,
                                    LastName = s.LastName,
                                    Hostel = s.Hostel.Name,
                                    Class = s.Class.ClassName,
                                    AdmissionDate = s.AdmissionDate,
                                    FullName = s.FullName,
                                    id = s.Id.Value.ToString()
                                }).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously Search for students with either the same firstname or lastname
        /// </summary>
        /// <param name="name">Student's FirstName or LastName</param>
        /// <returns>List of StudentViewModel</returns>
        public async Task<List<StudentViewModel>> GetStudentsAsync()
        {
            return await db.Students.Select(s => new StudentViewModel
                                    {
                                        AdmissionNumber = s.AdmissionNumber,
                                        FirstName = s.FirstName,
                                        LastName = s.LastName,
                                        Hostel = s.Hostel.Name,
                                        Class = s.Class.ClassName,
                                        AdmissionDate = s.AdmissionDate,
                                        FullName = s.FirstName+ " "+s.LastName,
                                        id = s.Id.Value.ToString()
                                    })
                                    .OrderBy(o => o.FirstName)
                                    .Skip(0)
                                    .Take(20)
                                    .ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetStudentsByAgeAscendingAsync()
        {

            return await db.Students
                           .OrderBy(s => s.Age)
                           .Skip(0)
                           .Take(20)
                           .Select(s => new StudentViewModel
                            {
                                AdmissionNumber = s.AdmissionNumber,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                Hostel = s.Hostel.Name,
                                Class = s.Class.ClassName,
                               AdmissionDate = s.AdmissionDate,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }

        /// <summary>
        /// Asynchronously search and get all students in the same hostel
        /// </summary>
        /// <param name="hostelName">Name of Hostel</param>
        /// <returns>List of StudentViewModels</returns>
        public async Task<List<StudentViewModel>> GetStudentsInSameHostelAsync(string hostelName)
        {
            return await db.Students
                           .Include(s => s.Hostel)
                           .Skip(0)
                           .Take(20)
                           .Select(s => new StudentViewModel
                            {
                                AdmissionNumber = s.AdmissionNumber,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                Hostel = s.Hostel.Name,
                                Class = s.Class.ClassName,
                               AdmissionDate = s.AdmissionDate,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }

        /// <summary>
        /// Projects the search for students by their names and hostels
        /// they belong to into a studentsviewmodel type. Expects student's
        /// name and hostel name
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="hostelName"></param>
        /// <returns></returns>
        public async Task<List<StudentViewModel>> GetStudentByNameAndHostelNameAsync(string studentName, string hostelName)
        {
            return await db.Students
                           .Include(s => s.Hostel)
                           .Where(s => s.FirstName.Contains(studentName) 
                           && s.Hostel.Name == hostelName)
                           .OrderBy(s => s.Hostel.Name)
                           .Skip(0)
                           .Take(20)
                           .Select(s => new StudentViewModel
                           {
                                AdmissionNumber = s.AdmissionNumber,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                Hostel = s.Hostel.Name,
                                Class = s.Class.ClassName,
                               AdmissionDate = s.AdmissionDate,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }

        /// <summary>
        /// Does a search and matches a student's firstname or lastname and what class they belong
        /// to and returns a List<StudentViewModel>
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="classname"></param>
        /// <returns></returns>
        public async Task<List<StudentViewModel>> GetStudentByNameAndClassAsync(string studentName, string classname)
        {
            return await db.Students
                         .Include(s => s.Class)
                         .Where(s => s.FirstName.Contains(studentName)
                        || s.LastName.Contains(studentName) && s.Class.ClassName == classname)
                        .OrderBy(s => s.FirstName)
                        .Skip(0)
                        .Take(20)
                        .Select(s => new StudentViewModel
                        {
                            AdmissionNumber = s.AdmissionNumber,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Class = s.Class.ClassName,
                            Hostel = s.Hostel.Name,
                            AdmissionDate = s.AdmissionDate,
                            FullName = s.FullName,
                            id = s.Id.Value.ToString()
                        }).ToListAsync();
        }

        /// <summary>
        /// Get Students that all have the same Guardian
        /// </summary>
        /// <param name="guardian">a guardian</param>
        /// <returns>List of StudentGuardianViewModel</returns>
        public async Task<List<StudentGuardianViewModel>> GetStudentsByGuardianAsync(string guardian)
        {
            return await db.Students
                           .Include(s => s.Guardian)
                           .Include(s => s.Payments)
                           .Where(s => s.Guardian.FirstName.Contains(guardian) ||
                           s.Guardian.LastName.Contains(guardian))
                           .Select(s => new StudentGuardianViewModel
                            {
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                AdmissionNumber = s.AdmissionNumber,
                                PaymentStatus = s.Payments.Select(p => p.PaymentStatus).Single().ToString(),
                                AmountPaid = s.Payments.Select(p => p.Amount).SingleOrDefault(),
                                Class = s.Class.ClassName,
                                Level = s.Class.Level
                            }).ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetStudentByAdmissionNumber(string admissionnumber)
        {
            return await db.Students
                           .Where(s => s.AdmissionNumber == admissionnumber)
                           .OrderBy(s => s.FirstName)
                           .Skip(0)
                           .Take(20)
                           .Select(s => new StudentViewModel
                            {
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                AdmissionNumber = s.AdmissionNumber,
                                Class = s.Class.ClassName,
                                Hostel = s.Hostel.Name,
                               AdmissionDate = s.AdmissionDate,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }


        public async Task<List<StudentViewModel>> GetStudentsByAdmissionDate(DateTime date)
        {
            return await db.Students
                           .Where(s => s.AdmissionDate == date)
                           .OrderBy(s => s.AdmissionDate)
                           .Select(s => new StudentViewModel
                            {
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                AdmissionDate = s.AdmissionDate,
                                AdmissionNumber = s.AdmissionNumber,
                                Class = s.Class.ClassName,
                                Hostel = s.Hostel.Name,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }

        public async Task<List<StudentAcademicViewModel>> GetStudentsByClass(string classname)
        {
            return await db.Students.Where(s => s.Class.ClassName.Contains(classname))
                                    .OrderBy(s => s.FirstName)
                                    .Select(s => new StudentAcademicViewModel
                                    {
                                        FullName = s.FullName,
                                        AdmissionNumber = s.AdmissionNumber,
                                        House = s.Hostel.Name,
                                        Class = s.Class.ClassName + s.Class.Section
                                    }).ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetStudentsByGender(string gender)
        {

            return await db.Students
                           .Where(s => s.Gender == gender)
                           .OrderBy(s => s.FirstName)
                           .Select(s => new StudentViewModel
                           {
                               FirstName = s.FirstName,
                               LastName = s.LastName,
                               AdmissionNumber = s.AdmissionNumber,
                               Hostel = s.Hostel.Name,
                               Class = s.Class.ClassName + s.Class.Section,
                               AdmissionDate = s.AdmissionDate,
                               FullName = s.FullName,
                               id = s.Id.Value.ToString()
                           }).ToListAsync();
        }

        public async Task<List<StudentAddressViewModel>> GetStudentsByAddressAsync(string partofaddress)
        {

            return await db.Students
                           .Where(s => s.Address.NameOfArea.Contains(partofaddress)
                                || s.Address.StreetName.Contains(partofaddress)
                                || s.Address.HouseNumber.Contains(partofaddress))
                            .OrderBy(o => o.FirstName)
                            .Select(s => new StudentAddressViewModel
                            {
                                FullName = s.FullName,
                                Address = s.Address.HouseNumber + " " + s.Address.StreetName + ", "
                                                    + s.Address.NameOfArea + " ",
                                AdmissionNumber = s.AdmissionNumber,
                                Class = s.Class.ClassName + s.Class.Section
                            }).ToListAsync();
        }

        /// <summary>
        /// Count Number of active students in a school 
        /// </summary>
        /// <returns>Task of Int</returns>
        public int CountNumberOfStudents()
        {
            //return await qdb.GetCountAsync<Student>(s => s.Active == true);
            return db.Students.Count(s => s.Active == true);
        }

        /// <summary>
        /// Return the Number students that ever attended a school
        /// </summary>
        /// <returns>Task of Int</returns>
        public int CountTotalNumberOfStudents()
        {
            return db.Students.Where(x => x.FirstName != "").Count();
        }


        public async Task<List<SimpleSubjectViewModel>> GetAllStudentSubjects(int id)
        {
            return await db.Students
                           .Include(s => s.Subjects)
                           .Where(s => s.Id == id)
                           .Select(s => new SimpleSubjectViewModel
                           {
                               Name = s.Subjects.Select(p => p.Name).FirstOrDefault(),
                               SubjectCode = s.Subjects.Select(p => p.SubjectCode).SingleOrDefault()
                           }).ToListAsync();
        }

        public async Task<List<SimpleSubjectViewModel>> GetAllStudentsSubjectsByStudentName(string name)
        {
            return await db.Students
                           .Include(s => s.Subjects)
                           .Where(s => s.FullName.Contains(name))
                           .Select(s => new SimpleSubjectViewModel
                           {
                               Name = s.Subjects.Select(p => p.Name).SingleOrDefault(),
                               SubjectCode = s.Subjects.Select(p => p.SubjectCode).SingleOrDefault()
                           }).ToListAsync();
        }


        public async Task<List<StudentSubjectViewModel>> GetAllStudentSubjectTeacher(int id)
        {

            return await db.Students
                           .Include(s => s.Subjects)
                           .Select(s => new StudentSubjectViewModel
                           {
                               StudentName = s.FullName,
                               SubjectName = s.Subjects.Select(p => p.Name).FirstOrDefault(),
                               TeacherName = s.Subjects.Select(p => p.Teachers.Select(
                                   t => t.FirstName+" "+t.LastName).FirstOrDefault()).FirstOrDefault()
                           }).ToListAsync();


        }
    }
}
