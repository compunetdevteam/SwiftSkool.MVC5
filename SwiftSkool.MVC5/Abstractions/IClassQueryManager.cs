using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IClassQueryManager
    {
        Task<ClassViewModel> GetClassByNameAsync(string classname);
        Task<List<ClassViewModel>> GetClassesAsync();
    }
}