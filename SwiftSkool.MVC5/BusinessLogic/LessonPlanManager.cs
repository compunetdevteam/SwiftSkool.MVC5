using SwiftSkool.Abstractions;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftSkool.MVC5.BusinessLogic
{
    public class LessonPlanManager //: ILessonPlanManager
    {
        private readonly SchoolDb db;

        public LessonPlanManager(SchoolDb dbd)
        {
            db = dbd;
        }

        //// deleting an existing lesson plan
        public void Delete(LessonPlanViewModel plan)
        {
            var deleteplan = db.LessonPlans.Find((int)plan.LessonPlanId);
            db.LessonPlans.Remove(deleteplan);
            db.SaveChanges();
        }

        public async Task<LessonPlanViewModel> SearchLessonPlanBySubjectId(int id)
        {
            return await GetLessonPlanBySubjectId(id);
        }

        //// searching for lesson plan by Week 
        public async Task<List<LessonPlanViewModel>> SearchLessonPlanByWeekNumber(int weeknumber)
        {
            return await GetLessonPlanByWeek(weeknumber);
        }

        //// searching for lesson plan by Teacher id
        public async Task<LessonPlanViewModel> SearchLessonPlanByTeacherId(int teacherid)
        {
            return await GetLessonPlanByTeacherId(teacherid);
        }

        //// searching for lesson plan by class
        public async Task<List<LessonPlanClassViewModel>> SearchLessonPlanByClassName(string classname)
        {
            return await GetLessonPlanByClassName(classname); // (corrected)this returns something other than lessonPlanViewModel, which should be your return type from the method
        }

        ////searching for lesson plan by subject name
        public async Task<LessonPlanClassViewModel> SearchLessonPlanBySubjectName(string subjectname)
        {
            return await GetLessonPlanBySubjectName(subjectname);//return type difference -- corrected
        }

        ////searching for lesson plan by teacher name
        public async Task<List<LessonPlanViewModel>> SearchLessonPlanByTeacherName(string teachername)
        {
            return await GetLessonPlanByTeacherName(teachername); //return type difference -- corrected
        }

        //// searching for lesson plan by term
        public async Task<List<LessonPlanSessionViewModel>> SearchLessonPlanByTerm(string term)
        {
            return await GetLessonPlanByTerm(term); //return type difference -- added a lessonplansessionviewmodel
        }

        //// searching for lesson plan by session name
        public async Task<List<LessonPlanSessionViewModel>> SearchLessonPlanBySessionName(string sessionname)
        {
            return await GetLessonPlanBySessionName(sessionname); //return type difference
        }

        ///** Implementing the Lesson Plan Query Repository
        // * possible queries for deleting lesson plans
        // * Deleting a lesson plan by Teacher Id
        // **/
        public void DeleteLessonPlanByTeacherId(int teacherid) // Sir pls check if it's neccessary to do theses various deletes.
        {
            var deletet_id = db.LessonPlans.Find(teacherid);
            db.LessonPlans.Remove(deletet_id); //here you use _db to do a delete.
            db.SaveChanges();
        }

        public async Task<LessonPlanViewModel> GetLessonPlanBySubjectId(int id)
        {
            return await db.LessonPlans
                                    .Select(s => new LessonPlanViewModel
                                    {
                                        LessonPlanId = s.Id.Value,
                                        PlanDescription = s.PlanDescription,
                                        SubjectName = s.Subject.Name,
                                        TeacherName = s.Teacher.FirstName+" "+s.Teacher.LastName,
                                        Week = s.Week
                                    }).SingleOrDefaultAsync();
        }

        public async Task<List<LessonPlanViewModel>> GetLessonPlanByWeek(int weeknumber)
        {
            return await db.LessonPlans
                           .Include(l => l.Subject)
                           .Where(l => l.Week == weeknumber)
                           .OrderBy(l => l.Week)
                           .Skip(0)
                           .Take(10)
                           .Select(s => new LessonPlanViewModel
                            {
                                TeacherName = s.Teacher.FirstName + " " + s.Teacher.LastName,
                                SubjectName = s.Subject.Name,
                                PlanDescription = s.PlanDescription,
                                Week = s.Week,
                                LessonPlanId = s.Id.Value
                            }).ToListAsync();
        }

        public async Task<LessonPlanViewModel> GetLessonPlanByTeacherId(int teacherid)
        {
            return await db.LessonPlans
                           .Include(l => l.Teacher)
                           .Include(l => l.Subject)
                           .Where(l => l.TeacherId == teacherid)
                           .Skip(0)
                           .Take(10)
                           .Select(s => new LessonPlanViewModel
                            {
                                TeacherName = s.Teacher.FirstName + " " + s.Teacher.LastName,
                                SubjectName = s.Subject.Name,
                                PlanDescription = s.PlanDescription,
                                Week = s.Week,
                                LessonPlanId = s.Id.Value
                            }).SingleOrDefaultAsync();
        }

        public async Task<List<LessonPlanClassViewModel>> GetLessonPlanByClassName(string classname)
        {
            return await db.LessonPlans
                           .Include(l => l.Session)
                           .Where(l => l.Class.Contains(classname))
                           .OrderBy(l => l.Class + l.ClassLevel)
                           .Skip(0)
                           .Take(10)
                           .Select(s => new LessonPlanClassViewModel
                            {
                                TeacherName = s.Teacher.FirstName + " " + s.Teacher.LastName,
                                SubjectName = s.Subject.Name,
                                Week = s.Week,
                                ClassName = s.Class + s.ClassLevel,
                                PlanDescription = s.PlanDescription,
                                TeacherId = s.TeacherId
                            }).ToListAsync();
        }


        public async Task<LessonPlanClassViewModel> GetLessonPlanBySubjectName(string name)
        {
            return await db.LessonPlans
                           .Include(l => l.Subject)
                           .Where(l => l.Subject.Name.Contains(name) || l.Subject.Name == name)
                           .Select(p => new LessonPlanClassViewModel
                            {
                                ClassName = p.Class,
                                PlanDescription = p.PlanDescription,
                                SubjectName = p.Subject.Name,
                                Week = p.Week,
                                TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                                TeacherId = p.TeacherId
                            }).SingleOrDefaultAsync();
        }


        public async Task<List<LessonPlanViewModel>> GetLessonPlanByTeacherName(string teachername)
        {
            return await db.LessonPlans
                           .Include(l => l.Subject)
                           .Where(l => l.Teacher.FirstName.Contains(teachername))
                           .Select(p => new LessonPlanViewModel
                            {
                                LessonPlanId = p.Id.Value,
                                PlanDescription = p.PlanDescription,
                                SubjectName = p.Subject.Name,
                                TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                                Week = p.Week
                            }).OrderBy(x => x.Week).ToListAsync();
        }


        public async Task<List<LessonPlanSessionViewModel>> GetLessonPlanByTerm(string termname)
        {
            return await db.LessonPlans
                     .Include(l => l.Session)
                     .Include(l => l.Subject)
                     .Where(l => l.Session.Term.ToString().Contains(termname))
                     .Select(p => new LessonPlanSessionViewModel
                     {
                         PlanDescription = p.PlanDescription,
                         TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                         Session = p.Session.SessionName,
                         SubjectName = p.Subject.Name,
                         Term = p.Session.Term.ToString(),
                         Week = p.Week
                     }).ToListAsync();
        }

        public async Task<List<LessonPlanSessionViewModel>> GetLessonPlanBySessionName(string session)
        {
            return await db.LessonPlans
                     .Include(l => l.Session)
                     .Include(l => l.Subject)
                     .Where(l => l.Session.SessionName.Contains(session))
                     .Select(p => new LessonPlanSessionViewModel
                    {
                        PlanDescription = p.PlanDescription,
                        TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                        Session = p.Session.SessionName,
                        SubjectName = p.Subject.Name,
                        Term = p.Session.Term.ToString(),
                        Week = p.Week
                    }).ToListAsync();
        }

        public async Task<List<LessonPlanViewModel>> GetAllLessonPlans()
        {
            return await db.LessonPlans
                           .Select(l => new LessonPlanViewModel
                           {
                               Discussions = l.Discussions,
                               SubjectName = l.Subject.Name,
                               Evaluations = l.Evaluations,
                               PlanDescription = l.PlanDescription,
                               TeacherName = l.Teacher.FirstName + " " + l.Teacher.LastName,
                               Topic = l.Topic,
                               Week = l.Week,
                               LessonPlanId = l.Id.Value
                           }).ToListAsync();
        }
    }
}
