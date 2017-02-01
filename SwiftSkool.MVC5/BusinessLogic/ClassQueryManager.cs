using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class ClassQueryManager : IClassQueryManager
    {
        private readonly SchoolDb db;
        


        public ClassQueryManager(SchoolDb _db)
        {
            db = _db;
        }

        /// <summary>
        /// Return a Class projected into a ClassViewModel
        /// </summary>
        /// <param name="classname">string representing the target class</param>
        /// <returns>ClassViewModel</returns>
        public async Task<ClassViewModel> GetClassByNameAsync(string classname)
        {
            return await db.Classes
                           .Include(c => c.Students)
                           .Include(c => c.FormTeacher)
                           .Where(c => c.ClassName.Contains(classname) &&
                           c.Level.Contains(classname) && c.Section.Contains(classname))
                           .Select(c => new ClassViewModel
                           {
                               ClassName = c.ClassName + c.Level + c.Section,
                               FormMaster = c.FormTeacher.FirstName + " " + c.FormTeacher.LastName,
                               NumberOfStudentInClass = c.Students.Count()
                           }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of all classes projected to classviewmodels
        /// </summary>
        /// <returns>List of ClassViewModels</returns>
        public async Task<List<ClassViewModel>> GetClassesAsync()
        {
            return await db.Classes
                           .Include(c => c.Students)
                           .Include(c => c.FormTeacher)
                           .Select(c => new ClassViewModel
                           {
                               ClassName = c.ClassName + c.Level + c.Section,
                               FormMaster = c.FormTeacher.FirstName + " " + c.FormTeacher.LastName,
                               NumberOfStudentInClass = c.Students.Count()
                           }).ToListAsync();
        }
    }
}
