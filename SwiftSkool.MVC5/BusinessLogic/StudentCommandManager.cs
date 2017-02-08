using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class StudentCommandManager : IStudentCommandManager
    {
        private SchoolDb _db;

        public StudentCommandManager(SchoolDb db)
        {
            _db = db;
        }

        public async Task RegisterStudent(CreateStudentInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) && string.IsNullOrWhiteSpace(model.LastName)
                && model.GuardianId == 0)
                throw new ArgumentException("Please provide valid values to create a student with!");

            var guardian = await _db.Guardians.FindAsync(model.GuardianId);

            var student = new Student(guardian, model.FirstName, model.LastName);

            try
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new EntityException("The Student could not be created at this time please try again later!");
            }
        }

        public async Task ChangeStudentDetails(UpdateStudentInputModel model)
        {
            //var student = await _db.Students.FindAsync(model.StudentId);
        }
    }
}