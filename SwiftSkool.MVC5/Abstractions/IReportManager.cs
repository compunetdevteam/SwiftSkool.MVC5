using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.Entities;

namespace SwiftSkool.BusinessLogic
{
    public interface IReportManager
    {
        Task<List<Report>> GetAllReportByStudentName(string studentname);
        Task<string> GetScoreRemark(double averagescore);
    }
}