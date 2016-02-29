using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPortfolioSite.Models
{
    public class ProjectFile
    {
        [Key]
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Filename must be less than 20 characters in length")]
        [Display(Name = "Filename for the file")]
        public string Filename { get; set; }
    }
}
