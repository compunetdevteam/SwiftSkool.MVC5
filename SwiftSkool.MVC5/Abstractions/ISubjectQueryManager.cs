using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.MVC5.Entities;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface ISubjectQueryManager
    {
        Task<List<SimpleSubjectViewModel>> GetSubjects();
        Task<List<SubjectViewModel>> GetSubjectsByClass(string classname);

        /// <summary>
        /// Returns a Subject if primary key supplied is valid
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Subject</returns>
        Task<Subject> FindSubjectByIdAsync(int id);
    }
}