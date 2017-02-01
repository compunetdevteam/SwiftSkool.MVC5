using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public interface ISubjectManager
    {
        bool Delete(int id);
        Task<List<SubjectViewModel>> GetSameSubjectOffered(string subjectname);
        Task<SubjectDetailViewModel> GetSubjectByName(string subjectName);
        bool IfExit(int aclass);
        Task<IEnumerable<Subject>> SelectStudentSubjects(Student student);
        void ViewClassToUpdate(int id);
    }
}