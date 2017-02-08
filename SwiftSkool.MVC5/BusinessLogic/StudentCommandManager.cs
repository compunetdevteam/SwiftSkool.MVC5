using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class StudentCommandManager : IStudentCommandManager
    {
        private SchoolDb _db;

        public StudentCommandManager(SchoolDb db)
        {
            _db = db;
        }

        public async Task RegisterStudent(CreateStudentViewModel model)
        {

        }
    }
}