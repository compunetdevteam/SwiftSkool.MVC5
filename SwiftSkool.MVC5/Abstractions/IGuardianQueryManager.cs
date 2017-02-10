using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IGuardianQueryManager
    {
        Task<List<GuardianIndexVM>> ShowAllGuardians();
        Task<GuardianDetailsVM> ShowGuardianDetails(int? id);
        Task<UpdateGuardianVM> GetGuardianToUpdate(int? id);
    }
}
