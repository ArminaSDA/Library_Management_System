using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class AuthorBook : BaseEntity
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}
