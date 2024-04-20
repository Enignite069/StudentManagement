using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " Please enter a post title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string ShortDescription { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }
    }
}
