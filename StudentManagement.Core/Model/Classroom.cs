using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Model
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Teacher> Classrooms { get; set; } = new List<Teacher>();
    }
}
