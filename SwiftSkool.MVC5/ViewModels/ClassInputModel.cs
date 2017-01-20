using System;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.ViewModels
{
    public class ClassInputModel
    {
        public string Level { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public int TeacherId { get; set; }
        public SelectList Teacher { get; set; }

        //public int StudentId { get; set; }
        //public SelectList Students { get; set; }
        //public List<StudentsSubjects> Subjects { get; set; }

        internal void Save()
        {
            throw new NotImplementedException();
        }
    }
}
