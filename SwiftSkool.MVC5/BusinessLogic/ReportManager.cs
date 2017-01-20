//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using System;

//namespace SwiftSkool.BusinessLogic
//{
//    public class ReportManager : IReportManager
//    {
//        private readonly QueryOnlyRepository<SchoolDb> _db;

//        public ReportManager(QueryOnlyRepository<SchoolDb> db)
//        {
//            _db = db;
//        }

       
//        public async Task<List<Report>> GetAllReportByStudentName(string studentname)
//        {
//            var student = await _db.GetOneByAsync<Student>(s =>
//                s.FullName.Contains(studentname), null);//gets student

//            var results = await _db.GetAsync<Result>(
//                r => r.Student.FullName.Contains(studentname), null, null,
//                null, null);//get results of student
//            var subjects = await _db.GetAsync<Subject>(
//                s => s.Students.Any(x => x.FullName.Contains(studentname)),null,"Teachers",null,null);
//            var listofreports = new List<Report>();

//            var report = new Report()
//            {
//                Student = new StudentViewModel
//                {
//                    AdmissionDate = student.AdmissionDate,
//                    Class = student.Class.Level.ClassLevel + " " + student.Class.ClassName +
//                    student.Class.Section,
//                    FirstName = student.FirstName,
//                    LastName = student.LastName,
//                    AdmissionNumber = student.AdmissionNumber,
//                    Hostel = student.Hostel.Name
//                },
//                Class = student.Class.ClassName,
//                Results = results.Select(x => new ResultViewModel
//                {
//                    StudentFullName = x.Student.FullName,
//                    StudentAdmissionNumber = x.Student.AdmissionNumber,
//                    Class = x.Student.Class.Level.ClassLevel + " " + x.Student.Class.ClassName + " " +
//                    x.Student.Class.Section,
//                    SubjectName = x.Subject.Name,
//                    TermWork = x.TermWork.TermWorkType.Name,
//                    Term = x.SchoolSession.Term.ToString(),
//                    AssignmentScore1 = x.AssignmentScore1,
//                    AssignmentScore2 = x.AssignmentScore2,
//                    AverageScore = x.Average,
//                    Project = x.Project,
//                    Grade = x.Subject.ScoreGrade.Grade.RatingGrade,
//                    TestScore1 = x.TestScore1,
//                    TestScore2 = x.TestScore2,
//                    TermTotal = x.TermTotal
//                }).ToList(),
//                FormTeacher = student.Class.FormTeacher.FullName,
//                Year = DateTime.UtcNow.Year,
//                ReportFinalTotal = results.Sum(x => x.TermTotal),
//                ReportFinalAverage = results.Sum(r => r.Average),
//                ReportGenerationDate = DateTime.UtcNow,
//                Gender = student.Gender,
//                Term = results.Single().SchoolSession.Term.ToString(),
//                NextTermBegins = results.SingleOrDefault().SchoolSession.TermStarts,
//                TermEnding = results.Single().SchoolSession.TermEnds,
//                NumberOfStudentsInClass = student.Class.Students.Count,
//                FormTeacherRemark =
//                    await GetScoreRemark(results.Sum(r => r.TermTotal) / results.Count()),
//                PrincipalRemark = await GetScoreRemark(results.Sum(r => r.TermTotal) / results.Count()),
//                KeyToRating = new KeyToRating()
//            };

//            listofreports.Add(report);
//            return listofreports;
            
//        }

//        public async Task<string> GetScoreRemark(double averagescore)
//        {
//            var scoregrade = await _db.GetOneByAsync<ScoreGrade>(g => g.MinimumScore <= averagescore
//                        && g.MaximumScore <= averagescore, "Subjects");
//            return scoregrade.ScoreComment;
//        }
       
//        /// <summary>
//        /// Generate MidTerm Report Card for Student
//        /// </summary>
//        /// <param name="term">string representation of current term</param>
//        /// <returns></returns>
//        //    public List<Report> MidTermReport( string term)
//        //    {


//        //    }

//        //    public async Task<Result> TermlyReport(string termname)
//        //    {
//        //        var termreport = TermlyReport(termname);
//        //        if(TermWorkType == null)
//        //        {
//        //            throw (new Exception("There is no score for this term for this student"));
//        //        }
//        //        return termreport;
//        //    }
//        //    public async Task<Result> YearlyReport(string session)
//        //    {
//        //        var yearlyreport = YearlyReport(session);
//        //        if(TermWorkType == null)
//        //        {
//        //            throw (new Exception("There is no score for this term for this student"));
//        //        }
//        //    }
//        //    public async Task<Result> CummilativeReport(string terms)
//        //    {
//        //        var cummilativereport = CummilativeReport(terms);
//        //        if(cummilativereport == null)
//        //        {
//        //            throw (new Exception("There is no session for this term "));
//        //        }
//        //        return cummilativereport;
//        //    }


//        //
//    }
   


//}
