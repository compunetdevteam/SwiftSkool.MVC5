//using SwiftSkools.Abstractions;
//using SwiftSkools.Domain.Abstractions;
//using SwiftSkools.Entities;
//using SwiftSkools.Repositories.CommandRepository;
//using SchoolPortal.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SwiftSkool.MVC5.BusinessLogic
//{
//    public class AdminManager
//    {
//        private readonly ICommandRepository<Class> _db;
//        private readonly IUsersCommandRepository<Teacher> _dbquery;
//        private readonly IQueryRepository qdb;


//        public AdminManager(ICommandRepository<Class> db,
//            IUsersCommandRepository<Teacher> dbq, IQueryRepository _qdb)
//        {
//            _db = db;
//            _dbquery = dbq;
//            qdb = _qdb;
//        }
//        /// <summary>
//        /// Method to creat new Class
//        /// </summary>
//        /// <param name="createClass"></param>
//        /// <returns></returns>
//        public void CreateClass(ClassInputModel createClass)
//        {
//            var newClass = new Class();
//            createClass.Name = newClass.ClassName;
//            createClass.Section = newClass.Section;
//            _db.Add(newClass);
//        }
//        //update a class infomation
//        public async Task<Class> UpdateClassInfo(Class updateClass, ClassInputModel classInfo)
//        {
//            classInfo.Name = updateClass.ClassName;
//            classInfo.Section = updateClass.Section;
//            await _db.SaveAsync();
//            return updateClass;
//        }
//        //view class to delete
//        public async Task<Class> ViewClassToDelete(int ClassId)
//        {
//            var viewClass = await _db.FindByIdAsync(ClassId);
//            return viewClass;
//        }
//        //method to delete a class 
//        public Class DeleteClass(int ClassID)
//        {
//            var deleteClass = _db.FindById(ClassID);
//            _db.Delete(deleteClass);
//            return deleteClass;
//        }
//        /// select a teacher and a class
//        public void ViewTeacherNClass(string teacherId, int  classId)
//        {
//            var findClass = _db.FindById(classId);
//            var findTeacher = _dbquery.FindById(teacherId);
//        }
        
//    }
//}