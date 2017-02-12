using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;

namespace SwiftSkool.MVC5.Entities
{
    public class Hostel : Entity
    {
        public string Name { get; set; }

        public string HouseColour { get; set; }

        public string HousePrefect { get; set; }

        public int TeacherId { get; set; }

        public ApplicationUser Patron { get; set; }

    }
}
