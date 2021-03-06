﻿using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftSkool.MVC5.Entities
{
    public class Allergy : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MedicalHistoryId { get; set; }

        public MedicalHistory MedicalHistory { get; set; }

    }
}
