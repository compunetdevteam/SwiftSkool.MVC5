using SwiftSkool.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.BusinessLogic
{
    public class StudentManager
    {
        private readonly SchoolDb db;

        public StudentManager(SchoolDb _db)
        {
            db = _db;
        }

        //method to save the selected student 
        //public Student SelectStudentSubjects(Student student, StudentInputModel stud = null)
        //{
        //    //var selectedSubjects = student.Student;
        //    //return selectedSubjects;
        //    //if (student.Subjects.Count <= 8) //it means the student has no subjects
        //    //{
        //    //    student.Subjects.AddRange(stud.Subjects);
        //    //    return student;
        //    //}
        //    //return student;
        //}
        //method to enter the score of a student



        //method to get all the student in the school
        public int CountAllStudent()
        {
            return CountNumberOfStudents();
        }
        //method to return all the subject offered by a single student
        public async Task<List<SimpleSubjectViewModel>> SubjectsOfferedByStudent(int id)
        {
            return await GetAllStudentSubjects(id);//method not yet implemented
        }
        //student can view all their subject teachers 
        public async Task<List<StudentSubjectViewModel>> StudentSubjectTeacher(int id)
        {
            return await GetAllStudentSubjectTeacher(id);
        }
        /**
         * ////////////////////////////////////////////////////
        implementing the Query Repository for Student Search
        **/


        //method to search student by name
        public async Task<IEnumerable<Student>> SearchStudentByName(string student)
        {
            return await GetStudentsByNameAsync(student);

        }
        //method to search student Age by Ascending Order
        public async Task<List<StudentViewModel>> SearchStudentByAgeAscending()
        {
            return await GetStudentsByAgeAscendingAsync();
        }
        //search student in the same hostel
        public async Task<List<StudentViewModel>> StudentInSameHostel(string student)
        {
            return await GetStudentsInSameHostelAsync(student);
        }

        public async Task<List<StudentGuardianViewModel>> SearchStudentByGuardian(string studentGuardian)
        {
            return await GetStudentsByGuardianAsync(studentGuardian);
        }
        public async Task<List<StudentViewModel>> SearchStudentByAdmission(string admissionnumber)
        {
            return await GetStudentByAdmissionNumber(admissionnumber);
        }
        public async Task<List<StudentViewModel>> SearchStudentByAdmissionDate(DateTime studentDate)
        {
            return await GetStudentsByAdmissionDate(studentDate);
        }
        public async Task<List<StudentAcademicViewModel>> SearchStudentByClass(string classname)
        {
            return await GetStudentsByClass(classname);
        }
        public async Task<List<StudentViewModel>> SearchStudentByGender(string gender)
        {
            return await GetStudentsByGender(gender);
        }
        public async Task<List<StudentAddressViewModel>> SearchStudentByAddress(string address)
        {
            return await GetStudentsByAddressAsync(address);
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
                                    Class = s.Class.ClassName
                                }).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously Search for students with either the same firstname or lastname
        /// </summary>
        /// <param name="name">Student's FirstName or LastName</param>
        /// <returns>List of StudentViewModel</returns>
        public async Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
        {
            return await db.Students.Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name))
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
                                Class = s.Class.ClassName
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
                                Class = s.Class.ClassName
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
                                Class = s.Class.ClassName
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
                            Hostel = s.Hostel.Name
                        }).ToListAsync();
        }

        /// <summary>
        /// Get Students that all have the same Guardian
        /// </summary> Student::with('payments')->
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
                                Hostel = s.Hostel.Name
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
                                Hostel = s.Hostel.Name
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
                               Class = s.Class.ClassName + s.Class.Section
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
                               Name = s.Subjects.Select(p => p.Name).SingleOrDefault(),
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
                               SubjectName = s.Subjects.Select(p => p.Name).SingleOrDefault(),
                               TeacherName = s.Subjects.Select(p => p.Teachers.Select(
                                   t => t.FirstName+" "+t.LastName).SingleOrDefault()).SingleOrDefault()
                           }).ToListAsync();


        }

        //Task<int> CountAllStudent()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<int> IStudentManager.CountNumberOfStudents()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<int> IStudentManager.CountTotalNumberOfStudents()
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeleteStudent(string student)
        {
            throw new NotImplementedException();
        }

        public Task<List<SimpleSubjectViewModel>> GetAllStudentSubjects(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentSubjectViewModel>> GetAllStudentSubjectTeacher(string id)
        {
            throw new NotImplementedException();
        }

        public Student SelectStudentSubjects(Student student, StudentInputModel stud = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentSubjectViewModel>> StudentSubjectTeacher(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SimpleSubjectViewModel>> SubjectsOfferedByStudent(string id)
        {
            throw new NotImplementedException();
        }

        //void IStudentManager.Update(StudentInputModel student)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<Student> ViewStudentToDelete(string studentID)
        {
            throw new NotImplementedException();
        }

        public Task<List<bool>> IfGuadianExist(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
