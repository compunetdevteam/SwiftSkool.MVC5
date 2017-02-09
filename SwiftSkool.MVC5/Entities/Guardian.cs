using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SwiftSkool.MVC5.Entities
{
    public class Guardian : Entity
    {

        private Guardian()
        {

        }

        public Guardian(string firstname, string lastname, Address address, string phonenumber)
        {
            ValidateDependencies(firstname, lastname, phonenumber, address);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName => FirstName + " " + OtherName + " " + LastName;

        public string OtherName { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Occupation { get; private set; }

        public Address Address { get; private set; }

        public Relationship Relationship { get; private set; }


        public List<Student> Students { get; private set; }

        private void ValidateDependencies(string firstname, string lname, string phone, Address addy)
        {
            validatestring(firstname);
            validatestring(lname);
            validatestring(phone);
            validatestring(addy.StreetName);
            validatestring(addy.NameOfArea);
            validatestring(addy.HouseNumber);
            validatestring(addy.City);

            FirstName = firstname;
            LastName = lname;
            PhoneNumber = phone;
            Address = addy;
        }

        private void validatestring(string astring)
        {
            if (string.IsNullOrWhiteSpace(astring))
                return;
            throw new ArgumentException("Invalid Arguments are not allowed!");
        }
    }
}
