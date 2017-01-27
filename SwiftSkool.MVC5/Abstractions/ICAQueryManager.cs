using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface ICAQueryManager
    {

        /// <summary>
        /// Returns ContinuousAssessments
        /// </summary>
        /// <returns>List of CAIndexViewModel types</returns>
        Task<CAViewModel> ReturnCADetails(int id);



        /// <summary>
        /// Show details of a single ContinuousAssessment
        /// </summary>
        /// <returns>CAViewModel</returns>
        Task<List<CAIndexViewModel>> ReturnCAList();
    }
}