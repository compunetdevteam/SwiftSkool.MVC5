using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class CACommandManager : ICACommandManager
    {
        private SchoolDb _db;

        public CACommandManager(SchoolDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates a brand new Continous Assessment for a student
        /// provided a valid Data Transfer Object is supplied as a
        /// parameter.
        /// </summary>
        /// <param name="ca">CreateCAViewModel</param>
        /// <returns>return a Task of Int if successful or an ArgumentOutOfRangeException on failure</returns>
        public async Task<int> CreateCA(CreateCAViewModel ca)
        {
            var result = await _db.Results.FindAsync(ca.ResultId);
            var subject = await _db.Subjects.FindAsync(ca.SubjectId);

            try
            {
                var cassess = new ContinuousAssessment(ca.Score.Value, ca.CAName, subject, result);
                _db.ContinuousAssessment.Add(cassess);
                return await _db.SaveChangesAsync();
            }
            catch (ArgumentOutOfRangeException are)
            {

                throw are;
            }
        }

        /// <summary>
        /// Updates or changes a target Continuous Assessment from the database
        /// </summary>
        /// <param name="ca">CAViewModel</param>
        /// <returns>true if update was successful or false if it fails</returns>
        public async Task<bool> CorrectCA(CAUpdateViewModel ca)
        {
            var uca = await _db.ContinuousAssessment.FindAsync(ca.CAId);

            try
            {
                uca.UpdateCA(ca.SubjectId, ca.CAName, ca.Score);
                _db.Entry(uca).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public async Task<bool> DeleteCA(int ca)
        {
            var dca = await _db.ContinuousAssessment.FindAsync(ca);
            try
            {
                _db.ContinuousAssessment.Remove(dca);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}