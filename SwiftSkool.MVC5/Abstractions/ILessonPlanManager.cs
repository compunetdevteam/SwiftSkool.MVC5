using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.Abstractions
{
    public interface ILessonPlanManager
    {
        Task<int> Create(LessonPlanInputModel plan);
        Task<bool> Delete(LessonPlanViewModel plan);
        Task<bool> DeleteLessonPlanBySessionName(string sessionname);
        Task<bool> DeleteLessonPlanBySubjectId(int subjectid);
        Task<bool> DeleteLessonPlanBySubjectName(string subjectname);
        Task<bool> DeleteLessonPlanByTeacherId(int teacherid);
        Task<bool> DeleteLessonPlanByTeacherName(string teachername);
        Task<bool> DeleteLessonPlanByTerm(string term);
        Task<List<LessonPlanViewModel>> GetAllLessonPlans();
        Task<List<LessonPlanClassViewModel>> GetLessonPlanByClassName(string classname);
        Task<List<LessonPlanSessionViewModel>> GetLessonPlanBySessionName(string session);
        Task<LessonPlanViewModel> GetLessonPlanBySubjectId(int id);
        Task<LessonPlanClassViewModel> GetLessonPlanBySubjectName(string name);
        Task<LessonPlanViewModel> GetLessonPlanByTeacherId(int teacherid);
        Task<List<LessonPlanViewModel>> GetLessonPlanByTeacherName(string teachername);
        Task<List<LessonPlanSessionViewModel>> GetLessonPlanByTerm(string termname);
        Task<List<LessonPlanViewModel>> GetLessonPlanByWeek(int weeknumber);
        Task<LessonPlanViewModel> SearchByLessonPlanId(int id);
        Task<List<LessonPlanClassViewModel>> SearchLessonPlanByClassName(string classname);
        Task<List<LessonPlanSessionViewModel>> SearchLessonPlanBySessionName(string sessionname);
        Task<LessonPlanViewModel> SearchLessonPlanBySubjectId(int id);
        Task<LessonPlanClassViewModel> SearchLessonPlanBySubjectName(string subjectname);
        Task<LessonPlanViewModel> SearchLessonPlanByTeacherId(int teacherid);
        Task<List<LessonPlanViewModel>> SearchLessonPlanByTeacherName(string teachername);
        Task<List<LessonPlanSessionViewModel>> SearchLessonPlanByTerm(string term);
        Task<List<LessonPlanViewModel>> SearchLessonPlanByWeekNumber(int weeknumber);
        Task<int> Update(LessonPlanInputModel plan);
    }
}