using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using AutoMapper.QueryableExtensions;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class CAQueryManager : ICAQueryManager
    {
        private readonly SchoolDb _db;

        public CAQueryManager(SchoolDb db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Returns ContinuousAssessments
        /// </summary>
        /// <returns>List of CAIndexViewModel types</returns>
        public async Task<List<CAIndexViewModel>> ReturnCAList()
        {
            return await _db.ContinuousAssessment.Include(c => c.Subject)
                                                 .Include(c => c.Result)
                                                 .ProjectTo<CAIndexViewModel>()
                                                 .ToListAsync();
        }

        /// <summary>
        /// Show details of a single ContinuousAssessment
        /// </summary>
        /// <returns>CAViewModel</returns>
        public async Task<CAViewModel> ReturnCADetails(int id)
        {
            return await _db.ContinuousAssessment.Include(c => c.Subject)
                                                 .Include(c => c.Result)
                                                 .Where(c => c.Id.Value == id)
                                                 .ProjectTo<CAViewModel>()
                                                 .FirstOrDefaultAsync();
        }


    }
}