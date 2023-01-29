using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Author Name")]
        public string Name { get; set; }
        public DateTime? BirthYear { get; set; }

    }
}
