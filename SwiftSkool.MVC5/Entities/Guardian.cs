﻿using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Entities
{
    public class Guardian : Entity
    {

        private Guardian()
        {

        }

        public Guardian(string firstname, string lastname, Address address, string phonenumber)
        {
            ValidateGuardian(firstname, lastname, phonenumber, address);
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

        private void ValidateGuardian(string firstname, string lname, string phone, Address addy)
        {
            validatestring(firstname);
            validatestring(lname);
            validatestring(phone);
            validatestring(addy.StreetName);
            validatestring(addy.NameOfArea);
            validatestring(addy.City);

            FirstName = firstname;
            LastName = lname;
            PhoneNumber = phone;
            Address = addy;
        }

        private void validatestring(string astring)
        {
            if (string.IsNullOrWhiteSpace(astring))
                throw new ArgumentException("Invalid Arguments are not allowed!");
            return;
        }

        public void UpdateGuardian(UpdateGuardianVM model)
        {
            validatestring(model.FirstName);
            validatestring(model.LastName);
            validatestring(model.PhoneNumber);
            validatestring(model.Occupation);
            validatestring(model.City);
            validatestring(model.StreetName);
            validatestring(model.HouseNumber);
            validatestring(model.NameOfArea);

            FirstName = model.FirstName;
            LastName = model.LastName;
            PhoneNumber = model.PhoneNumber;
            Occupation = model.Occupation;
            Relationship = model.RelationshipToStudent;
        }
    }
}
