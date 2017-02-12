using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IStudentCommandManager
    {
        Task ChangeStudentDetails(UpdateStudentVM model);
        Task RegisterStudent(CreateStudentInputModel model);
    }
}