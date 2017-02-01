using SwiftSkool.MVC5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class StudentResultViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string AdmissionNumber { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string Level { get; set; }
        public string Section { get; set; }
        public List<Result> Results { get; set; }

    }
}
