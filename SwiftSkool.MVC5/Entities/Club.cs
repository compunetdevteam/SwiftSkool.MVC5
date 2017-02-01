using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;

namespace SwiftSkool.MVC5.Entities
{
    public class Club : Entity
    {
        public string Clubname { get; set; }

        public int TeacherId { get; set; }

        public ApplicationUser Patron { get; set; }

    }
}
