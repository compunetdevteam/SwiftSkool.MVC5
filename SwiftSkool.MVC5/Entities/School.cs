using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System.Collections.Generic;

namespace SwiftSkool.Entities
{
    public class School : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }//string to image path

        public string OwnerName { get; set; }

        public string SchoolMotto { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<Student> Students { get; set; }

        public List<ApplicationUser> Staff { get; set; }

        public List<SchoolSession> Sessions { get; set; }



    }
}
