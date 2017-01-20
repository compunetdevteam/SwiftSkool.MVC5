using System.Collections.Generic;

namespace SwiftSkool.MVC5.ViewModels
{
    public class TeacherViewModel
    {
        public string TeacherFullName { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public int TeacherId { get; set; }
    }

    public class TeacherSubjectViewModel
    {
        public string TeacherName { get; set; }
        public List<SimpleSubjectViewModel> TeacherSubjects { get; set; }
        public string EmailAddress { get; set; }
        public string TeacherId { get; set; }

    }
}
