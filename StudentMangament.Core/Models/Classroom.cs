using System.ComponentModel.DataAnnotations;

namespace StudentMangament.Core.Models
{
    public class Classroom
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
