//using System.Threading.Tasks;
//using SwiftSkools.Entities;
//using SwiftSkools.Repositories.CommandRepository;
//using SwiftSkools.Repositories.QueryRepository;
//using SchoolPortal.ViewModels;
//using System.Collections.Generic;
//using static SchoolPortal.ViewModels.TeacherViewModel;
//using SwiftSkool.Abstractions;

//namespace SwiftSkool.BusinessLogic
//{
//    public class TeacherManager : ITeacherManager
//    {
//        private readonly IUsersCommandRepository<Teacher> _db;
//        private readonly IQueryRepository _qdb;
//        private readonly TeacherQueryRepository _dbquery;


//        public TeacherManager(IUsersCommandRepository<Teacher> teacher,
//            IQueryRepository qdb)
//        {
//            _db = teacher;
//            _qdb = qdb;
//        }


//        // method to create a new student
//        public async Task<int> CreateTeacher(TeacherInputModel teacher)
//        {
//            var newteacher = new Teacher();
//            if (teacher != null)
//            {
//                 teacher.FirstName = newteacher.FirstName;
//                 teacher.LastName = newteacher.LastName;
//                  teacher.DateOfBirth = newteacher.DateOfBirth;
//                  teacher.Gender = newteacher.Gender;
//                 teacher.ResidentialAddress = newteacher.ResidentialAddress;
//                teacher.TeacherPassport = newteacher.TeacherPassport;
//                 //teacher.Country = newteacher.Country;
//                 teacher.EmailAddress = newteacher.Email;
//                 teacher.StateOfOrigin = newteacher.StateOfOrigin;
//                _db.Add(newteacher);
//            }
//            return await _db.SaveAsync();
//        }
//        //Method to delete a Teacher
//        public async Task<bool> DeleteTeacher(string teacher)
//        {
//            var deleteteacher = await _db.FindByIdAsync(teacher);
//            return _db.Delete(deleteteacher);
//        }
//        //method to update a teacher
//        public async Task<int> Update(TeacherInputModel teacher)
//        {
//            var updateteacher = await _db.FindByIdAsync(teacher.TeacherId);
//             teacher.FirstName = updateteacher.FirstName;
//              teacher.LastName = updateteacher.LastName;
//              teacher.DateOfBirth = updateteacher.DateOfBirth;
//              teacher.Gender = updateteacher.Gender;
//             teacher.ResidentialAddress = updateteacher.ResidentialAddress;
//             teacher.TeacherPassport = updateteacher.TeacherPassport;
//              teacher.EmailAddress = updateteacher.Email;
//             //teacher.Country = updateteacher.Country;
//             teacher.StateOfOrigin = updateteacher.StateOfOrigin;
//            _db.Update(updateteacher);
//            return await _db.SaveAsync();
//        }

//        //method to assign a teacher to a subject
//        public void AssignTeacherASubject(TeacherToSubjectInputModel teacherSubject)
//        {
//            //select an existing teacher
//            Teacher AssignTeacherToSubject = _db.FindById(teacherSubject.TeacherID);

//             //teacherSubject.SubjectID = AssignTeacherToSubject.Id; //logic is wrong
//            _db.Add(AssignTeacherToSubject);

//        }
//        //searching teacher based on subject thought
//        public async Task<List<TeacherSubjectViewModel>> SearchTeacherBySubjectTaught(string subject)
//        {
//            var searchteacherbysubject = _dbquery.GetTeacherBySubjectTaught(subject);
//            return await searchteacherbysubject;
//        }

//THIS METHOD BELONGS IN THE TEACHER MANAGER CLASS
////Method for teacher to input the students scores
//public async Task<TermWorkType> EnterStudentSubjectScore(StudentScoreInputModel studentScore)
//{
//   TermWorkType selectStudent = _dbqueryTermWork.FindById(studentScore.StudentID);
//     studentScore.SubjectID = selectStudent.TermWork.SubjectId; //am right now working here
//     studentScore.Score = selectStudent.TermWork.Score;
//    _dbqueryTermWork.Add(selectStudent);
//    await _dbqueryTermWork.SaveAsync();
//    return selectStudent;
//
//    //want to save the studentwork object to the database

//    //what you are passing in is termworktype not student. So look carefully at the

//    //implementation of Add in the command repository and understand. So CommandRepo

//    //is made for Student being that we passed it student at constructor level.
//    /*
//     this method is yet to be completed

//    */

//}
//    }
// }
