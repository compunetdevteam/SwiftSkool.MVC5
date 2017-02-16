using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IClassCommandManager
    {
        Task CreateClass(CreateClassVM model);

        Task UpdateClass(UpdateClassVM model);
    }
}
