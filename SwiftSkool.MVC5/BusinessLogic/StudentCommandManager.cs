using SwiftSkool.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class StudentCommandManager
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