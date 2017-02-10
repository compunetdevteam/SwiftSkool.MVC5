using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftSkool.MVC5.ViewModels;
using System.Threading.Tasks;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

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

        public async Task UpdateGuardianDetails(UpdateGuardianVM model)
        {
            var guardian = await _db.Guardians.FindAsync(model.GuardianId);

            if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.PhoneNumber)
                || string.IsNullOrWhiteSpace(model.StreetName))
                throw new ArgumentException("Dunno how you want to update a guardian with some field empty!");
            var addy = guardian.Address.UpdateAddress(model.StreetName, model.NameOfArea, model.City, model.HouseNumber);

            try
            {
                guardian.UpdateGuardian(model);
                _db.Entry(guardian).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
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