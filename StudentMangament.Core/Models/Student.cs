using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMangament.Core.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateofBirth { get; set; }

        public enum GenderChoice { Male, Female }

        public GenderChoice Gender { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
