using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IGuardianCommandManager
    {
        Task RegisterGuardian(GuardianViewModel model);

        Task UpdateGuardianDetails(UpdateGuardianVM model);

        Task RemoveGuardian(int? id);
    }
}
