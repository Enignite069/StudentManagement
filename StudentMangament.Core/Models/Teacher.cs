using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DoB {  get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
    }
}
