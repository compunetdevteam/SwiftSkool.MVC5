using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftSkool.MVC5.ViewModels;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class GuardianCommandManager : IGuardianCommandManager
    {
        public Task RegisterGuardian(GuardianViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task RemoveGuardian(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGuardianDetails(UpdateGuardianVM model)
        {
            throw new NotImplementedException();
        }
    }
}