using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwiftSkool.MVC5.ViewModels.StudentViewModel;

namespace SwiftSkool.MVC5.ViewModels
{
    public class SubjectViewModel
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string StudentFullName { get; set; }
        public string StudentAdmissionNumber { get; set; }
        public string Class { get; set; }
        public string Level { get; set; }
        
    }

    public class SubjectDetailViewModel
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public int NumberOfStudents { get; set; }
    }

    public class SimpleSubjectViewModel
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
    }
}
