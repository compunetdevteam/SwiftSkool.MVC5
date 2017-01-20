using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkools.Abstractions
{
    public interface IClassManager
    {
        Task<ClassViewModel> AsignStudentToClass();
        Task<ClassViewModel> AsignTeacherToClass();
        Task<ClassViewModel> GetAllClasses(string classes);
        Task<List<ClassViewModel>> GetClassAsync();
        Task<List<ClassViewModel>> GetClassByName(string name);
        Task<List<ClassViewModel>> GetClassByNameAsync(string classname);
        Task<List<ClassViewModel>> GetClassLevelAsync(int classid);
        Task<ClassViewModel> GetClassSummary(string classummary);
        Task<List<ClassViewModel>> GetStudentClassAttndance(int studentid);
    }
}