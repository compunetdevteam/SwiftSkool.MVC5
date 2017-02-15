using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftSkool.MVC5.ViewModels;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class GuardianQueryManager : IGuardianQueryManager
    {
        private readonly SchoolDb _db;

        public GuardianQueryManager(SchoolDb db)
        {
            _db = db;
        }

        public async Task<UpdateGuardianVM> GetGuardianToUpdate(int? id)
        {
            return await _db.Guardians.Where(x => x.Id.Value == id.Value)
                            .Select(g => new UpdateGuardianVM
                            {
                                FirstName = g.FirstName,
                                LastName = g.LastName,
                                PhoneNumber = g.PhoneNumber,
                                Occupation = g.Occupation,
                                OtherNames = g.OtherName,
                                City = g.Address.City,
                                GuardianId = g.Id.Value,
                                HouseNumber = g.Address.HouseNumber,
                                NameOfArea = g.Address.NameOfArea,
                                StreetName = g.Address.StreetName,
                                RelationshipToStudent = g.Relationship
                            }).FirstOrDefaultAsync();
        }

        public async Task<List<GuardianIndexVM>> ShowAllGuardians()
        {
            return await _db.Guardians.Select(g => new GuardianIndexVM
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                PhoneNumber = g.PhoneNumber,
                Address = g.Address.HouseNumber + " " + g.Address.StreetName + ", " + g.Address.NameOfArea
                          + ", " + g.Address.City,
                GuardianId = g.Id.Value
            }).ToListAsync();
        }

        public async Task<GuardianDetailsVM> ShowGuardianDetails(int? id)
        {
            return await _db.Guardians.Where(x => x.Id.Value == id.Value)
                            .Select(g => new GuardianDetailsVM
                            {
                                FirstName = g.FirstName,
                                LastName = g.LastName,
                                PhoneNumber = g.PhoneNumber,
                                RelatedStudents = new List<StudentViewModel>
                                {
                                    new StudentViewModel
                                    {
                                        AdmissionDate = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).AdmissionDate,
                                        AdmissionNumber = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).AdmissionNumber,
                                        FirstName = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).FirstName,
                                        LastName = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).LastName,
                                        OtherName = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).OtherName,
                                        Class = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).Class.ClassName,
                                        Hostel = g.Students.FirstOrDefault(x => x.GuardianId == id.Value).Hostel.Name
                                    }
                                },
                                Address = g.Address.HouseNumber+" "+g.Address.StreetName+", "+
                                          g.Address.NameOfArea+", "+g.Address.City
                            }).FirstOrDefaultAsync();


        }
    }
}