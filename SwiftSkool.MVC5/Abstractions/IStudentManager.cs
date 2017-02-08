using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public interface IStudentManager
    {
        int CountAllStudent();
        int CountNumberOfStudents();
        int CountTotalNumberOfStudents(); 
        Student CreateStudent(CreateStudentInputModel student);
        bool DeleteStudent(string student);
        Task<List<SimpleSubjectViewModel>> GetAllStudentsSubjectsByStudentName(string name);
        Task<List<SimpleSubjectViewModel>> GetAllStudentSubjects(string id);
        Task<List<StudentSubjectViewModel>> GetAllStudentSubjectTeacher(string id);
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
        Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
        Task<List<StudentViewModel>> GetStudentsInSameHostelAsync(string hostelName);
        Task<List<StudentAddressViewModel>> SearchStudentByAddress(string address);
        Task<List<StudentViewModel>> SearchStudentByAdmission(string admissionnumber);
        Task<List<StudentViewModel>> SearchStudentByAdmissionDate(DateTime studentDate);
        Task<List<StudentViewModel>> SearchStudentByAgeAscending();
        Task<List<StudentAcademicViewModel>> SearchStudentByClass(string classname);
        Task<List<StudentViewModel>> SearchStudentByGender(string gender);
        Task<List<StudentGuardianViewModel>> SearchStudentByGuardian(string studentGuardian);
        Task<IEnumerable<Student>> SearchStudentByName(string student);
        Student SelectStudentSubjects(Student student, CreateStudentInputModel stud = null);
        Task<List<StudentViewModel>> StudentInSameHostel(string student);
        Task<List<StudentSubjectViewModel>> StudentSubjectTeacher(string id);
        Task<List<SimpleSubjectViewModel>> SubjectsOfferedByStudent(string id);
        Task Update(CreateStudentInputModel student);
        Task<Student> ViewStudentToDelete(string studentID);
        Task<List<bool>> IfGuadianExist(Student student);
        Student ViewStudentToDelete(int studentID);
        List<Student> ViewAllStudents();
    }
}