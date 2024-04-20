using System.ComponentModel.DataAnnotations;

namespace StudentMangament.Core.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
