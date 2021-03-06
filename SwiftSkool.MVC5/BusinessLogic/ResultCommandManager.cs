﻿using AutoMapper;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class ResultCommandManager : IResultCommandManager
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
            var term = await _db.SchoolTerms.FindAsync(result.SchoolTermsId);

            try
            {
                var newresult = new Result(student, subject, term);
                _db.Results.Add(newresult);
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Change any result provided an UpdateResultViewModel in a valid state
        /// is provided
        /// </summary>
        /// <param name="model">UpdateResultViewModel</param>
        /// <returns>int</returns>
        public async Task<int> ChangeResult(UpdateResultViewModel model)
        {
            var result = await _db.Results.FindAsync(model.ResultId);
            
            if(model.StudentId ==0 && model.SubjectId == 0 && model.SchoolSessionId == 0)
            {
                throw new ArgumentException("You have given values that are invalid!");
            }

            result = Mapper.Map<Result>(model);

            try
            {
                _db.Entry(result).State = EntityState.Modified;
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}