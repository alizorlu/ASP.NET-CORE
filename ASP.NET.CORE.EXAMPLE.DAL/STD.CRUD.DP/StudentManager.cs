using ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Context;
using ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.CORE.EXAMPLE.DAL.STD.CRUD.DP
{

    public interface IStudentDal
    {
        List<Student> GetStudents();
        bool Delete(Guid guid);
        Student Add(Student student);
    }
    public class EFStudentDal : IStudentDal
    {
        private SchoolContext _context;
        public EFStudentDal(SchoolContext context)
        {
            _context = context;
        }
        public bool Delete(Guid guid)
        {
            Student finded = _context.Students.Find(guid);
            _context.Entry(finded).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }
        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
    }
    public class StudentManager
    {
        private IStudentDal _studentdal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentdal = studentDal;
        }
        public List<Student> GetStudents() => _studentdal.GetStudents();
        public Student AddStudent(Student student) {
            return _studentdal.Add(student);
        }
        public void Delete(Guid id)
        {
            _studentdal.Delete(id);
        }
    }
}
