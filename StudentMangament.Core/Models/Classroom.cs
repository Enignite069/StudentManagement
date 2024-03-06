using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
    }
}
