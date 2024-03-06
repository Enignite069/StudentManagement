using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
    }
}
