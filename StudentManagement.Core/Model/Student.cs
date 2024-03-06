using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Model
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }


        public string StudentEmail { get; set;}
        public DateTime StudentDoB {  get; set; }
        public string StudentAddress { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
