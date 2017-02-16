namespace SwiftSkool.MVC5.ViewModels
{
    public class ClassViewModel
    {
        public string ClassName { get; set; }
        public string FormMaster { get; set; }
        public int NumberOfStudentInClass { get; set; }

        public int ClassId { get; set; }
    }

    public class CreateClassVM
    {
        public string ClassName { get; set; }

        public string Level { get; set; }

        public string Section { get; set; }
    }

    public class UpdateClassVM
    {
        
    }
}