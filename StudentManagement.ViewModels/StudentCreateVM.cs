using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels
{
    public class StudentCreateVM
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public enum GenderChoice { Male, Female }

        [Required]
        public GenderChoice Gender { get; set; }

        public string Phone {  get; set; }

        [Required]
        [Display(Name = "Classroom")]
        public int ClassroomId { get; set; }
    }
}