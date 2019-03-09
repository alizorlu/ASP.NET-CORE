using ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Context;
using ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Tables;
using ASP.NET.CORE.EXAMPLE.DAL.STD.CRUD.DP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET.CORE.EXAMPLE.Pages
{
    public class StudentModel : PageModel
    {
        private SchoolContext _context;
        EFStudentDal studentDal;
        StudentManager student;
        public StudentModel(SchoolContext context)
        {
            _context = context;
            studentDal = new EFStudentDal(_context);
            student = new StudentManager(studentDal);
        }
        [BindProperty]
        public Student Student { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Student.AddedTime = DateTime.Now;
            student.AddStudent(Student);
            return Page();
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null || Guid.Empty == id) return Page();
            else
            {
                student.Delete(id);
            }
            return Page();
        }
       
        public List<Student> GetStudents()
        {
          
            return student.GetStudents();
        }
        public Student Add(string name,int sex)
        {
            return student.AddStudent(new Student()
            {
                Id = Guid.NewGuid(),
                AddedTime = DateTime.Now,
                NameSurname = name.ToUpper(),
                Sex = (byte)sex,
                ProfileAvatar = "https://gravatar.com/avatar/dba6bae8c566f9d4041fb9cd9ada7721?d=identicon&f=y"

            });
        }
        

    }
}