using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class StatusDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "This fieled is required")]
        public string Name { get; set; }
    }
}
