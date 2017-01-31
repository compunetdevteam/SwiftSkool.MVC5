using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.BusinessLogic
{
    public class SubjectQueryManager : ISubjectQueryManager
    {
        private readonly SchoolDb _db;


        public SubjectQueryManager(SchoolDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Asynchronously Return a List of SimpleSubjectViewModel
        /// </summary>
        /// <returns>List of SimpleSubjectViewModel</returns>
        public async Task<List<SimpleSubjectViewModel>> GetSubjects()
        {
            return await _db.Subjects
                            .Select(s => new SimpleSubjectViewModel
                            {
                                Name = s.Name,
                                SubjectCode = s.SubjectCode
                            }).ToListAsync();
        }

        
        public async Task<List<SubjectViewModel>> GetSubjectsByClass(string classname)
        {
            return await _db.Subjects
                            .Include(s => s.Teachers)
                            .Include(s => s.Students)
                            .Where(s => s.Students.Select(x => x.Class.ClassName).Contains(classname))
                            .Select(s => new SubjectViewModel
                            {
                                Class = s.Students.Select(x => x.Class.ClassName).FirstOrDefault(),
                                StudentAdmissionNumber = s.Students.FirstOrDefault().AdmissionNumber,
                                StudentFullName = s.Students.FirstOrDefault().FullName,
                                Level = s.Students.FirstOrDefault().Class.Level,
                                SubjectCode = s.SubjectCode,
                                SubjectName = s.Name
                            }).ToListAsync();
        }
    }
}
