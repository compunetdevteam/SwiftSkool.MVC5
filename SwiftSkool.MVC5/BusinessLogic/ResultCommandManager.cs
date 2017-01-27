using SwiftSkool.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class ResultCommandManager
    {
        private SchoolDb _db;

        public ResultCommandManager(SchoolDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Create a student's Result provided a result
        /// is in a valid state.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns a task if successfully or an Exception</returns>
        public async Task<int> CreateResult(CreateResultViewModel result)
        {
            if(result.StudentId == 0 && result.SubjectId == 0)
            {
                throw new ArgumentException("An invalid parameter was given for creating the result!");
            }
            var student = await _db.Students.FindAsync(result.StudentId);
            var subject = await _db.Subjects.FindAsync(result.SubjectId);
            var session = await _db.Sessions.FindAsync(result.SessionId);

            try
            {
                var newresult = new Result(student, subject, session);
                _db.Results.Add(newresult);
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }



        
    }
}