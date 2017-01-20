using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SwiftSkool.MVC5.Models;

namespace SwiftSkools.BusinessLogic
{
    public class ClassManager
    {
        private readonly SchoolDb db;
        


        public ClassManager(SchoolDb _db)
        {
            db = _db;
        }

        
        //// To display class by level for example Jss1,Jss2 or SS1
        //public async Task<List<ClassViewModel>> GetClassLevelAsync(int classid)
        //{
            
        //}
        //// To display class by name; for example Jss1A or Jss1B
        //public async Task <List<ClassViewModel >>GetClassByName(string name)
        //{
            
        //}
        //// method to get student class attendance count
        //public async Task<List<ClassViewModel>>GetStudentClassAttndance(int studentid)
        //{

        //}

        public async Task<List<ClassViewModel>> GetClassByNameAsync(string classname)
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
                           }).ToListAsync();
        }

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
