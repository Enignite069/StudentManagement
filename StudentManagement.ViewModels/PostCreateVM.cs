using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class PostCreateVM
    {
        [Required(ErrorMessage = " Please enter a post title")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Publish the post?")]
        public bool Published { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }
    }
}

