using System.ComponentModel.DataAnnotations;

namespace StudentMangament.Core.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        public enum GenderChoice { Male, Female }
        public GenderChoice Gender { get; set; }
       
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
