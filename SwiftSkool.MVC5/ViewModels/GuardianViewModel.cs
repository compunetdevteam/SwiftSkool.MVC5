

using System.ComponentModel.DataAnnotations;

namespace SwiftSkool.MVC5.ViewModels
{
    public class GuardianViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        [Display(Name ="Mobile Number")]
        public string PhoneNumber { get; set; }

        public string Occupation { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name =" Area Name")]
        public string NameOfArea { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }
    }
}