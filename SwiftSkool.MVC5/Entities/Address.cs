using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System;

namespace SwiftSkool.MVC5.Entities
{
    public class Address
    {


        private Address()
        {

        }

        public Address(string streetname, string nameofarea, string city)
        {
            StreetName = streetname;
            NameOfArea = nameofarea;
            City = city;
        }

        public string NameOfArea { get; private set; }

        public string StreetName { get; private set; }

        public string HouseNumber { get; private set; }

        public string City { get; private set; }


    }
}
