using SwiftSkool.Abstractions;
using System.Collections.Generic;

namespace SwiftSkool.Entities
{
    public class State : Entity
    {

        public string Name { get; set; }

        public List<LocalGovernment> LocalGovt { get; set; }
    }
}
