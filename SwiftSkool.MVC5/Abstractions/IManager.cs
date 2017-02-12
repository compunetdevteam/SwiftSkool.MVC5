using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IManager<T> where T : class
    {
        Task<T> FindStudentById(int? id);
    }
}
