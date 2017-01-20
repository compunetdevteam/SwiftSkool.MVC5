using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.Entities;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.Abstractions
{
    public interface IResultQueryManager
    {
        Task<List<ResultViewModel>> BestFivePerformingStudent(int id);
        Task<double> CalculateClassHighestPerSubject(string classname, string subjectname, string term);
        Task<double> CalculateClassLowestPerSubject(string classname, string subjectname, string term);
        double CalculateCumilativeResult(double firsttermtotal, double secondtermtotal, double thirdtermtotal);
        double CalculateFirstTermTotalPerStudent(List<Result> results, string studentname);
        Task<double> CalucaluteCumilativeScorePerSubject(string subjectName, string className, string studentname);
        Task<int> CountNumberOfResultsAsync();

        /// <summary>
        /// Return a List of ResultViewModels Asynchronously
        /// </summary>
        /// <returns>List<ResultViewModel></returns>
        Task<List<ResultViewModel>> GetAllResultsAsync();
        
        Task<List<ResultViewModel>> GetAllResultsByNameAsync(string name);
        Task<List<ResultViewModel>> GetAllResultsBySessionAsync(string sessionname);
        Task<List<ResultViewModel>> GetAllResultsDescendingAsync();
        Task<List<StudentResultCAViewModel>> GetCABySingleStudent(string caname);

        /// <summary>
        /// Find A Result using supplied Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResultViewModel</returns>
        ResultViewModel GetResultById(int id);

        /// <summary>
        /// Find a Result asynchronously using supplied Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultViewModel> GetAllResultsByIdAsync(int id);
        Task<List<ResultViewModel>> GetResultsByDateCreatedAsync();
        Task<List<ResultViewModel>> GetResultsBySubjectNameAsync(string name);
        Task<List<ResultViewModel>> GetResultsByTermNameAsync(string termname);
        Task<List<ResultViewModel>> GetResultStatusAsync(string studentname);
        Task<ResultViewModel> GetSingleResultByStudentNameAsync(string name);
        Task<List<ResultViewModel>> WorstFivePerformingStudent(int id);
    }
}