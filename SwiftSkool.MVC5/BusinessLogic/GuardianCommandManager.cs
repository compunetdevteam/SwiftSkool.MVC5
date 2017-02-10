using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftSkool.MVC5.ViewModels;
using System.Threading.Tasks;
using AutoMapper;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class GuardianCommandManager : IGuardianCommandManager
    {
        private SchoolDb _db;

        public GuardianCommandManager(SchoolDb db)
        {
            _db = db;
        }
        public async Task RegisterGuardian(GuardianViewModel model)
        {
            var guardian = MapGuardian(model);
            _db.Guardians.Add(guardian);
            await _db.SaveChangesAsync();
        }

        public Task UpdateGuardianDetails(UpdateGuardianVM model)
        {

        }

        private Guardian MapGuardian(GuardianViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) && string.IsNullOrWhiteSpace(model.city))
                throw new ArgumentException("Mapping Failed!");
            var address = new Address(model.StreetName, model.NameOfArea, model.city);
            return new Guardian(model.FirstName, model.LastName, address, model.PhoneNumber);
        }
    }
}