using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.Entities;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public interface IReportManager
    {
        Task<List<Report>> GetAllReportByStudentName(string studentname);
        Task<string> GetScoreRemark(double averagescore);
    }
}