using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.Entities
{
    public class Class : Entity
    {

        private Class()
        {
            
        }

        public Class(string level, string classname, string section)
        {
            CheckDependencies(level, classname, section);
        }

        private void CheckDependencies(string level, string classname, string section)
        {
            if (!string.IsNullOrEmpty(level) && !string.IsNullOrEmpty(classname) && !string.IsNullOrEmpty(section))
            {
                Level = level;
                ClassName = classname;
                Section = section;
            }
        }

        public string Level { get; private set; }

        public string ClassName { get; private set; }

        public string Section { get; private set; }


        public int? TeacherId { get; private set; }

        public ApplicationUser FormTeacher { get; private set; }

        public IEnumerable<Student> Students { get; private set; }

        public IEnumerable<Subject> Subjects { get; private set; }

    }
}
