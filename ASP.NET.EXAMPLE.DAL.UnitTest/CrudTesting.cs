using ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ASP.NET.CORE.EXAMPLE.DAL.STD.CRUD.DP;

namespace ASP.NET.EXAMPLE.DAL.UnitTest
{
    [TestClass]
    public class CrudTesting
    {
        private readonly SchoolContext _context;
        private StudentManager _student;
        private EFStudentDal _studentDal;
        public CrudTesting()
        {
            _context = new DesignTimeDbContextFactory().CreateDbContext(null);            
            _studentDal = new EFStudentDal(_context);
            _student = new StudentManager(_studentDal);
        }
        [TestMethod]
        public void ListTest()
        {
            var result = _student.GetStudents();
            if (result == null)
            {
                throw new Exception("Listeleme işlemi null olmaz");
            }
        }
       
       
        [TestMethod]
        public void AddTest()
        {
           var result=
                _student.AddStudent(new CORE.EXAMPLE.DAL.EntityFramework.Tables.Student()
            {
                AddedTime = DateTime.Now,
                NameSurname = "Unit Test",
                Sex = 21,
                ProfileAvatar = "Test"
            });
            if (result == null)
            {
                throw new Exception("Ekleme hatası");
            }
            
        }
    }
}
