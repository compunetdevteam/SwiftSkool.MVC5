using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IResultCommandManager
    {


        /// <summary>
        /// Change any result provided an UpdateResultViewModel in a valid state
        /// is provided
        /// </summary>
        /// <param name="model">UpdateResultViewModel</param>
        /// <returns>int</returns>
        Task<int> ChangeResult(UpdateResultViewModel model);

        /// <summary>
        /// Create a student's Result provided a result
        /// is in a valid state.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns a task if successfully or an Exception</returns>
        Task<int> CreateResult(CreateResultViewModel result);
    }
}