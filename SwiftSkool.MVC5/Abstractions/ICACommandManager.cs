using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface ICACommandManager
    {


        /// <summary>
        /// Updates or changes a target Continuous Assessment from the database
        /// </summary>
        /// <param name="ca">CAViewModel</param>
        /// <returns>true if update was successful or false if it fails</returns>
        Task<bool> CorrectCA(CAUpdateViewModel ca);

        /// <summary>
        /// Creates a brand new Continous Assessment for a student
        /// provided a valid Data Transfer Object is supplied as a
        /// parameter.
        /// </summary>
        /// <param name="ca">CreateCAViewModel</param>
        /// <returns>return a Task of Int if successful 
        /// or an ArgumentOutOfRangeException on failure</returns>
        Task<int> CreateCA(CreateCAViewModel ca);
    }
}