using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.Entities
{
    public class ScoreComment
    {
        public string Remarks { get; private set; }


        public void SetRemarks(string remarks)
        {
            Remarks = remarks;
        }
    }
}
