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

        public Address(Student student, string streetname, string nameofarea, string city,
            State state)
        {
            
        }

        public string NameOfArea { get; private set; }

        public string StreetName { get; private set; }

        public string HouseNumber { get; private set; }

        public string City { get; private set; }


    }
}
