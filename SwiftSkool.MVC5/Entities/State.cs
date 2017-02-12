using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using System.Collections.Generic;

namespace SwiftSkool.MVC5.Entities
{
    public class State : Entity
    {

        public string Name { get; set; }

        public List<LocalGovernment> LocalGovt { get; set; }
    }
}
