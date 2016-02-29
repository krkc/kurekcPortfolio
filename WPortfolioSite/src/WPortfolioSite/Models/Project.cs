using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPortfolioSite.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Project Title must be between 1 and 50 characters in length.")]
        [Display(Name = "Project Name")]
        public string Title { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Project Description must be between 1 and 100 characters in length.")]
        [Display(Name = "Project Description")]
        public string Description { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Project Language must be between 1 and 20 characters in length.")]
        [Display(Name = "Language Used in Project")]
        public string Language { get; set; }
        [StringLength(50, ErrorMessage = "Project Subtopic must be less than 50 characters in length.")]
        [Display(Name = "Project Subtopic (if any)")]
        public string Subtopic { get; set; }

        public List<ProjectFile> ProjectFiles { get; set; }
    }
}
