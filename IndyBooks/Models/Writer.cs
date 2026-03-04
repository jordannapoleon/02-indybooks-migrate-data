
using System.ComponentModel.DataAnnotations;

namespace IndyBooks.Models;
public class Writer
{
    //TODO : Add the Writer Entity properties including the navigation property
    public long Id { get; set; }

    [Required(ErrorMessage = "author's Name please")]
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; }
}