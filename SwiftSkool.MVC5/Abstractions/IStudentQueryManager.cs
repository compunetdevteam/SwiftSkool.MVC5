using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IStudentQueryManager
    {
        int CountNumberOfStudents();
        int CountTotalNumberOfStudents();
        Task<List<SimpleSubjectViewModel>> GetAllStudentsSubjectsByStudentName(string name);
        Task<List<SimpleSubjectViewModel>> GetAllStudentSubjects(int id);
        Task<List<StudentSubjectViewModel>> GetAllStudentSubjectTeacher(int id);
        Task<List<StudentViewModel>> GetStudentByAdmissionNumber(string admissionnumber);
        Task<List<StudentViewModel>> GetStudentByNameAndClassAsync(string studentName, string classname);
        Task<List<StudentViewModel>> GetStudentByNameAndHostelNameAsync(string studentName, string hostelName);
        Task<StudentViewModel> GetStudentByNameAsync(string name);
        Task<List<StudentAddressViewModel>> GetStudentsByAddressAsync(string partofaddress);
        Task<List<StudentViewModel>> GetStudentsByAdmissionDate(DateTime date);
        Task<List<StudentViewModel>> GetStudentsByAgeAscendingAsync();
        Task<List<StudentAcademicViewModel>> GetStudentsByClass(string classname);
        Task<List<StudentViewModel>> GetStudentsByGender(string gender);
        Task<List<StudentGuardianViewModel>> GetStudentsByGuardianAsync(string guardian);
        Task<IEnumerable<StudentViewModel>> GetStudentsAsync();
        Task<List<StudentViewModel>> GetStudentsInSameHostelAsync(string hostelName);
    }
}