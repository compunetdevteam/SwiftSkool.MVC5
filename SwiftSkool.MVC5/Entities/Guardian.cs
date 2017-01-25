﻿using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.Entities
{
    public class Guardian : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public Relationship Relationship { get; set; }


        public List<Student> Students { get; set; }
    }
}