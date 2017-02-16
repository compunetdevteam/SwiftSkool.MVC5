using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class ClassCommandManager : IClassCommandManager
    {
        private SchoolDb _db;

        public ClassCommandManager(SchoolDb db)
        {
            _db = db;
        }

        public async Task CreateClass(CreateClassVM model)
        {
            if (string.IsNullOrWhiteSpace(model.Level) && string.IsNullOrWhiteSpace(model.ClassName)
                && string.IsNullOrWhiteSpace(model.Section))
                return;
            var studclass = new Class(model.Level,model.ClassName,model.Section);
            _db.Classes.Add(studclass);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateClass(UpdateClassVM model)
        {
            if (model == null)
                throw new ArgumentNullException();
            var updateableclass = await _db.Classes.FindAsync(model.ClassId);
        }
    }
}