using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP.NET.CORE.EXAMPLE.DAL.EntityFramework.Tables
{
    [Table("TABLE.STUDENTS")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameSurname { get; set; }
        public byte Sex { get; set; }
        public string ProfileAvatar { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
