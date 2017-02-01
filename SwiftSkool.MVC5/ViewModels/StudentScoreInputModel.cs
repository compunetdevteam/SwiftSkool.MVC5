using SwiftSkool.MVC5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.ViewModels
{
    public class StudentScoreInputModel
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public double Score { get; set; }

    }
}
