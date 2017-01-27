using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.Entities;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.BusinessLogic
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