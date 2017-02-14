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
            if (string.IsNullOrWhiteSpace(model.FirstName) &&
                string.IsNullOrWhiteSpace(model.LastName)
                && model.GuardianId == 0)
                throw new 
                    ArgumentException("Please provide valid values to create a student with!");

            var address = new Address(model.Street, model.NameOfArea, model.City);

            var guardian = await _db.Guardians.FindAsync(model.GuardianId);

            var student = new Student(address, guardian, model.FirstName, model.LastName, DateTime.UtcNow);

            try
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw new EntityException("The Student could not be created at this time please try again later!");
                throw ex;
            }
        }

        public async Task ChangeStudentDetails(UpdateStudentVM model)
        {
            var student = await _db.Students.FindAsync(model.StudentId);

            var studentclass = await _db.Classes.FindAsync(model.ClassId);
            var club = await _db.Clubs.FindAsync(model.ClubId);
            var hostel = await _db.Hostels.FindAsync(model.HostelId);
            var guardian = await _db.Guardians.FindAsync(model.GuardianId);
            var state = await _db.States.FindAsync(model.StateId);

            student.UpdateStudentDetails(model, studentclass, club, hostel);

            try
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}