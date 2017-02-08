using System;
using SwiftSkool.MVC5.Entities;
using static SwiftSkool.MVC5.ViewModels.SubjectViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{
    public class CreateStudentInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GuardianId { get; set; }

        public SelectList guardian { get; set; } 
    }
    public class GuardianViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressViewModel Address { get; set; }
    }
    public class AddressViewModel
    {
        public string City { get; set; }
        public string NameOfArea { get; set; }
    }
}
