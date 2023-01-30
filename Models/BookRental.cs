using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models;

public class BookRental : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime StartRentDate { get; set; }
    public DateTime EndRentDate { get; set; }

}
