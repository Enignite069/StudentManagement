using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels
{
    public class TeacherCreateVM
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        public enum GenderChoice { Male, Female }

        [Required]
        public GenderChoice Gender { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public List<int> SubjectId { get; set; }

        [Required]
        [Display(Name = "Teaching Classroom")]
        public List<int> ClassroomId { get; set; }
    }
}
