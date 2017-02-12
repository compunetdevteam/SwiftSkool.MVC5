using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Entities
{
    public class Disability : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int MedicalHistoryId { get; private set; }

        public MedicalHistory MedicalHistory { get; private set; }

    }
}
