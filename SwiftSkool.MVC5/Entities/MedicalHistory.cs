using SwiftSkool.Abstractions;
using System;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Entities
{
    public class MedicalHistory : Entity
    {
        public List<Allergy> Allergies { get; set; }

        public bool Surgery { get; set; }

        public List<Illness> Illnesses { get; set; }

        public List<Disability> Disabilities { get; set; }

        public DateTime YearOfSurgery { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

    }
}
