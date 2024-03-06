using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DoB { get; set;}

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
