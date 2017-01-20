using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.Abstractions
{
    public interface ITeacherManager
    {
        void AssignTeacherASubject(TeacherToSubjectInputModel teacherSubject);
        Task<int> CreateTeacher(TeacherInputModel teacher);
        Task<bool> DeleteTeacher(string teacher);
        Task<List<TeacherSubjectViewModel>> SearchTeacherBySubjectTaught(string subject);
        Task<int> Update(TeacherInputModel teacher);
    }
}