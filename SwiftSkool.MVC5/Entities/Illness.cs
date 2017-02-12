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
    public class Illness : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MedicalHistoryId { get; set; }

        public MedicalHistory MedicalHistory { get; set; }
        
    }
}
