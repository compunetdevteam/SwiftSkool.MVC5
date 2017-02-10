using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.Abstractions;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class ResultQueryManager : IResultQueryManager
    {
        private readonly SchoolDb _db;
        public ResultQueryManager(SchoolDb db)
        {
            _db = db;
        }


        public IQueryable<Result> GetResults()
        {
            return   _db.Results.Include(r => r.ContinuousAssessments)
                                    .Include(r => r.SchoolSession)
                                    .Include(r => r.ScoreGrade)
                                    .Include(r => r.Student)
                                    .Include(r => r.Subject);                          
        }

        /// <summary>
        /// Find a result by a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result</returns>
        public async Task<Result> FindResultByIdAsync(int? id)
        {
            try
            {
                return await _db.Results.FindAsync(id.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultViewModel GetResultById(int id)
        {
            var query = _db.Results.Find(id);
            return new ResultViewModel
            {
                Student = new StudentViewModel
                {
                    AdmissionDate = query.Student.AdmissionDate,
                    AdmissionNumber = query.Student.AdmissionNumber,
                    Class = query.Student.Class.ClassName +
                                          query.Student.Class.Level + query.Student.Class.Section,
                    FirstName = query.Student.FirstName,
                    LastName = query.Student.LastName,
                    Hostel = query.Student.Hostel.Name
                },

                CA = new CAViewModel
                {
                    Id = query.ContinuousAssessments.SingleOrDefault().Id.Value,
                    Name = query.ContinuousAssessments.SingleOrDefault().Name,
                    Score = query.ContinuousAssessments.SingleOrDefault().Score
                },

                ResultId = query.Id.Value,
                Session = query.SchoolSession.SessionName,
                ClassAverage = query.ClassAverage,
                Term = query.SchoolSession.Term.ToString(),
                Grade = query.Subject.ScoreGrade.Grade.RatingGrade,
                Position = query.Position,
                TermTotal = query.TermTotal
            };
        }
        

        /// <summary>
        /// Searches and returns results if search is provided with a name
        /// of a subject
        /// </summary>
        /// <param name="name">Name of Subject</param>
        /// <returns>List of ResultViewModels</returns>
        public async Task<List<ResultViewModel>> GetResultsBySubjectNameAsync(string name)
        {
            return await _db.Results
                            .Include(r => r.Student)
                            .Include(r => r.Student.Class)
                            .Include(r => r.Subject)
                            .Include(r => r.ContinuousAssessments)
                            .Include(r => r.SchoolSession)
                            .Where(r => r.Subject.Name.Contains(name))
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    Hostel = r.Student.Hostel.Name
                                },
                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).SingleOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).SingleOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).SingleOrDefault().Score
                                },

                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }

        /// <summary>
        /// Asynchronously gets results of all students
        /// and orders the results by the students First Name
        /// </summary>
        /// <returns>A List of ResultViewModels</returns>
        public async Task<List<ResultViewModel>> GetAllResultsAsync()
        {
            return await _db.Results
                                    .Include(r => r.Student)
                                    .Include(s => s.Student.Class)
                                    .Include(r => r.Subject)
                                    .Include(r => r.ContinuousAssessments)
                                    .Include(r => r.SchoolSession)
                                    .OrderBy(r => r.Student.FirstName)
                                    .Take(10)
                                    .Select(r => new ResultViewModel
                                    {
                                        Student = new StudentViewModel
                                        {
                                            AdmissionDate = r.Student.AdmissionDate,
                                            AdmissionNumber = r.Student.AdmissionNumber,
                                            Class = r.Student.Class.ClassName +
                                                  r.Student.Class.Level + r.Student.Class.Section,
                                            FirstName = r.Student.FirstName,
                                            LastName = r.Student.LastName,
                                            Hostel = r.Student.Hostel.Name
                                        },

                                        CA = new CAViewModel
                                        {
                                            Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                            Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                            Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                        },
                                        ResultId = r.Id.Value,
                                        Session = r.SchoolSession.SessionName,
                                        ClassAverage = r.ClassAverage,
                                        Term = r.SchoolSession.Term.ToString(),
                                        Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                        Position = r.Position,
                                        TermTotal = r.TermTotal
                                    }).ToListAsync();
        }

        /// <summary>
        /// Return a ResultViewModel when a student's name is 
        /// given as a parameter to this method
        /// </summary>
        /// <param name="name">string of student's first or complete name</param>
        /// <returns>ResultViewModel</returns>
        public async Task<List<ResultViewModel>> GetAllResultsByNameAsync(string name)
        {
            return await _db.Results
                            .Include(r => r.Student)
                            .Include(r => r.Subject)
                            .Include(r => r.SchoolSession)
                            .Where(r => r.Student.FullName.Contains(name))
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    Hostel = r.Student.Hostel.Name
                                },
                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                },
                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }

        public async Task<ResultViewModel> GetAllResultsByIdAsync(int id)
        {
            return await _db.Results
                                    .Include(r => r.Student)
                                    .Include(s => s.Student.Class)
                                    .Include(r => r.Subject)
                                    .Include(r => r.ContinuousAssessments)
                                    .Include(r => r.SchoolSession)
                                    .Select(r => new ResultViewModel
                                    {
                                        Student = new StudentViewModel
                                        {
                                            AdmissionDate = r.Student.AdmissionDate,
                                            AdmissionNumber = r.Student.AdmissionNumber,
                                            Class = r.Student.Class.ClassName +
                                                  r.Student.Class.Level + r.Student.Class.Section,
                                            FirstName = r.Student.FirstName,
                                            LastName = r.Student.LastName,

                                            OtherName = r.Student.OtherName,
                                            Hostel = r.Student.Hostel.Name
                                        },
                                        CA = new CAViewModel
                                        {
                                            Id = r.ContinuousAssessments.FirstOrDefault().Id.Value,
                                            Name = r.ContinuousAssessments.FirstOrDefault().Name,
                                            Score = r.ContinuousAssessments.FirstOrDefault().Score
                                        },
                                        ResultId = r.Id.Value,
                                        Session = r.SchoolSession.SessionName,
                                        ClassAverage = r.ClassAverage,
                                        Term = r.SchoolSession.Term.ToString(),
                                        Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                        Position = r.Position,
                                        TermTotal = r.TermTotal,
                                        Subject = new SimpleSubjectViewModel
                                        {
                                            Name = r.Subject.Name,
                                            SubjectCode = r.Subject.SubjectCode
                                        }
                                    }).FirstOrDefaultAsync();
        }

        public async Task<List<ResultViewModel>> GetAllResultsBySessionAsync(string sessionname)
        {

            return await _db.Results

                                    .Include(r => r.Student)
                                    .Include(s => s.Student.Class)
                                    .Include(r => r.Subject)
                                    .Include(r => r.ContinuousAssessments)
                                    .Include(r => r.SchoolSession)
                            .Where(r => r.SchoolSession.SessionName.Contains(sessionname))
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    Hostel = r.Student.Hostel.Name
                                },

                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                },
                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }


        /// <summary>
        /// Searches and returns a Single result based on a students name
        /// </summary>
        /// <param name="name">Full Name or partial name of student</param>
        /// <returns>Task of ResultViewModel</returns>
        public async Task<ResultViewModel> GetSingleResultByStudentNameAsync(string name)
        {
                return await _db.Results
                                    .Include(r => r.Student)
                                    .Include(s => s.Student.Class)
                                    .Include(r => r.Subject)
                                    .Include(r => r.ContinuousAssessments)
                                    .Include(r => r.SchoolSession)
                                    .Where(r => r.Student.FullName.Contains(name))
                                    .Select(r => new ResultViewModel
                                    {
                                        Student = new StudentViewModel
                                        {
                                            AdmissionDate = r.Student.AdmissionDate,
                                            AdmissionNumber = r.Student.AdmissionNumber,
                                            Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                            FirstName = r.Student.FirstName,
                                            LastName = r.Student.LastName,
                                            Hostel = r.Student.Hostel.Name
                                        },
                                        CA = new CAViewModel
                                        {
                                            Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                            Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                            Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                        },
                                        ResultId = r.Id.Value,
                                        Session = r.SchoolSession.SessionName,
                                        ClassAverage = r.ClassAverage,
                                        Term = r.SchoolSession.Term.ToString(),
                                        Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                        Position = r.Position,
                                        TermTotal = r.TermTotal
                                    }).SingleOrDefaultAsync();

        }

        public async Task<List<ResultViewModel>> GetResultsByTermNameAsync(string termname)
        {
            return await _db.Results
                            .Include(r => r.Student)
                            .Include(r => r.Subject)
                            .Include(r => r.SchoolSession)
                            .Where(r => r.SchoolSession.Term.ToString().Contains(termname))
                            .Take(20)
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    Hostel = r.Student.Hostel.Name
                                },

                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                },
                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }

        public async Task<List<ResultViewModel>> GetResultStatusAsync(string studentname)
        {
            return await _db.Results
                            .Include(r => r.Student)
                            .Include(s => s.Student.Class)
                            .Include(r => r.Subject)
                            .Include(r => r.SchoolSession)
                            .Include(r => r.ContinuousAssessments)
                            .Where(r => r.Student.FullName.Contains(studentname))
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    Hostel = r.Student.Hostel.Name
                                },

                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                },
                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }


        public async Task<List<StudentResultCAViewModel>> GetCABySingleStudent(string caname)
        {
            return await _db.Results
                              .Include(r => r.Student)
                              .Include(r => r.Subject)
                              .Include(r => r.ContinuousAssessments)
                              .Where(r => r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name == caname)
                              .OrderBy(r => r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name)
                              .Take(10)
                              .Select(r => new StudentResultCAViewModel
                              {
                                  StudentName = r.Student.FullName,
                                  StudentAdmissionNumber = r.Student.AdmissionNumber,
                                  Score = r.TermTotal,
                                  CAName = r.ContinuousAssessments.SingleOrDefault().Name,
                                  Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                              }).ToListAsync();
        }


        public async Task<List<ResultViewModel>> BestFivePerformingStudent(int id)
        {

            var query = await _db.Results
                                 .Include(r => r.Student)
                                 .Include(s => s.Student.Class)
                                 .Include(r => r.Subject)
                                 .Include(r => r.SchoolSession)
                                 .Include(r => r.ContinuousAssessments)
                                 .Where(r => r.Id == id)
                                 .OrderBy(r => r.TermTotal)
                                 .Take(5).ToListAsync();
            return query.Select(r => new ResultViewModel
            {
                Student = new StudentViewModel
                {
                    AdmissionDate = r.Student.AdmissionDate,
                    AdmissionNumber = r.Student.AdmissionNumber,
                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Hostel = r.Student.Hostel.Name
                },
                CA = new CAViewModel
                {
                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                },
                ResultId = r.Id.Value,
                Session = r.SchoolSession.SessionName,
                ClassAverage = r.ClassAverage,
                Term = r.SchoolSession.Term.ToString(),
                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                Position = r.Position,
                TermTotal = r.TermTotal
            }).ToList();
        }


        public async Task<List<ResultViewModel>> WorstFivePerformingStudent(int id)
        {
            var query = await _db.Results.Include(r => r.Student)
                                   .Include(s => s.Student.Class)
                                   .Include(r => r.SchoolSession)
                                   .Include(r => r.Subject)
                                   .Include(r => r.ContinuousAssessments)
                                   .Where(r => r.Id == id)
                                   .OrderByDescending(r => r.TermTotal)
                                   .Take(5).ToListAsync();
            return query.Select(r => new ResultViewModel
            {
                Student = new StudentViewModel
                {
                    AdmissionDate = r.Student.AdmissionDate,
                    AdmissionNumber = r.Student.AdmissionNumber,
                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Hostel = r.Student.Hostel.Name
                },
                CA = new CAViewModel
                {
                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                },
                ResultId = r.Id.Value,
                Session = r.SchoolSession.SessionName,
                ClassAverage = r.ClassAverage,
                Term = r.SchoolSession.Term.ToString(),
                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                Position = r.Position,
                TermTotal = r.TermTotal
            }).ToList();
        }


        public async Task<List<ResultViewModel>> GetAllResultsDescendingAsync()
        {
            var results = await GetAllResultsAsync();
            return results.OrderByDescending(x => x.Student.FirstName).ToList();
        }

        public async Task<List<ResultViewModel>> GetResultsByDateCreatedAsync()
        {
            return await _db.Results
                            .Include(r => r.Student)
                            .Include(s => s.Student.Class)
                            .Include(r => r.Subject)
                            .Include(r => r.SchoolSession)
                            .Include(r => r.ContinuousAssessments)
                            .OrderBy(r => r.UpdatedAt)
                            .Take(20)
                            .Select(r => new ResultViewModel
                            {
                                Student = new StudentViewModel
                                {
                                    AdmissionDate = r.Student.AdmissionDate,
                                    AdmissionNumber = r.Student.AdmissionNumber,
                                    Class = r.Student.Class.ClassName +
                                          r.Student.Class.Level + r.Student.Class.Section,
                                    FirstName = r.Student.FirstName,
                                    LastName = r.Student.LastName,
                                    OtherName = r.Student.OtherName,
                                    Hostel = r.Student.Hostel.Name
                                },
                                Subject = new SimpleSubjectViewModel
                                {
                                    Name = r.Subject.Name,
                                    SubjectCode = r.Subject.SubjectCode
                                },
                                CA = new CAViewModel
                                {
                                    Id = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Id.Value,
                                    Name = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Name,
                                    Score = r.ContinuousAssessments.Where(x => x.ResultId.Value == r.Id.Value).FirstOrDefault().Score
                                },
                                ResultId = r.Id.Value,
                                Session = r.SchoolSession.SessionName,
                                ClassAverage = r.ClassAverage,
                                Term = r.SchoolSession.Term.ToString(),
                                Grade = r.Subject.ScoreGrade.Grade.RatingGrade,
                                Position = r.Position,
                                TermTotal = r.TermTotal
                            }).ToListAsync();
        }

        public double CalculateCumilativeResult(double firsttermtotal, double secondtermtotal, double thirdtermtotal)
        {
            return firsttermtotal + secondtermtotal + thirdtermtotal / 3;
        }

        public async Task<double> CalucaluteCumilativeScorePerSubject(string subjectName, string className,
            string studentname)
        {
            var results = await _db.Results.Include(r => r.Subject)
                                     .Include(r => r.Student)
                                     .Include(r => r.Student.Class)
                                     .Include(r => r.SchoolSession)
                                     .Where(r => r.Subject.Name == subjectName && r.Student.Class.ClassName.Contains(className)
                                     && r.Student.Class.Section.Contains(className) && r.Student.Class.Level.Contains(className)
                                     && r.Student.FullName.Contains(studentname))
                                     .ToListAsync();

            var firsttermtotal = results.FirstOrDefault(x => x.SchoolSession.Term == Entities.Term.First).TermTotal;
            var secondtermtotal = results.FirstOrDefault(x => x.SchoolSession.Term == Entities.Term.Second).TermTotal;
            var thirdtermtotal = results.FirstOrDefault(x => x.SchoolSession.Term == Entities.Term.Third).TermTotal;
            return firsttermtotal + secondtermtotal + thirdtermtotal / 3;
        }

        public double CalculateFirstTermTotalPerStudent(List<Entities.Result> results, string studentname)
        {
            double termTotal = 0.0;

            if(results.All(x => x.SchoolSession.Term == Entities.Term.First) 
                && results.All(x => x.Student.FullName.Contains(studentname)))
            {
                foreach(var result in results)
                {
                    termTotal += result.TermTotal;
                }
                return termTotal;
            }
            throw new ArgumentException("Either the results passed isn't valid or a student name was not supplied!");
        }

        public async Task<double> CalculateClassHighestPerSubject(string classname, string subjectname, string term)
        {
            var result = await _db.Results.Include(r => r.Subject)
                                          .Include(r => r.SchoolSession)
                                          .Include(r => r.ContinuousAssessments)
                                          .Include(r => r.Student)
                                          .Include(s => s.Student.Class)
                                          .Where(r => r.Student.Class.ClassName.Contains(classname) &&
                                          r.Student.Class.Level.Contains(classname) &&
                                          r.Student.Class.Section.Contains(classname) &&
                                          r.Subject.Name == subjectname &&
                                          r.SchoolSession.Term.ToString() == term)
                                          .Skip(0)
                                          .Take(1).SingleOrDefaultAsync();
            return result.ContinuousAssessments.SingleOrDefault().Score;
        }

        public async Task<double> CalculateClassLowestPerSubject(string classname, string subjectname, string term)
        {
            var result = await _db.Results.Include(r => r.Subject)
                                          .Include(r => r.SchoolSession)
                                          .Include(r => r.ContinuousAssessments)
                                          .Include(r => r.Student)
                                          .Include(s => s.Student.Class)
                                          .Where(r => r.Student.Class.ClassName.Contains(classname) &&
                                          r.Student.Class.Level.Contains(classname) &&
                                          r.Student.Class.Section.Contains(classname) &&
                                          r.Subject.Name == subjectname &&
                                          r.SchoolSession.Term.ToString() == term)
                                          .OrderByDescending(r => r.ContinuousAssessments.FirstOrDefault().Score)
                                          .Skip(0)
                                          .Take(1).SingleOrDefaultAsync();
            return result.ContinuousAssessments.SingleOrDefault().Score;
        }

        public async Task<int> CountNumberOfResultsAsync()
        {
            return await _db.Results.CountAsync();
        }

    } 
}
 