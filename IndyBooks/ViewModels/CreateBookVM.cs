
using System.ComponentModel.DataAnnotations;
using IndyBooks.Models;

namespace IndyBooks.ViewModels;
public class CreateBookVM
{
    //TODO: Add Properties for all of the data shown in the CreateBook View (see Fig.3)
    // Be sure to add Data Annotations for Validation and Error Messages as shown
    public long BookId { get; set; }

   [Required(ErrorMessage = "book title please")]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "just make it up")]
    public string SKU { get; set; }

    [Required(ErrorMessage = "the value is invalid")]
    public decimal Price { get; set; }

    [Display(Name = "AuthorName")]
    public Writer Author { get; set; }
    

}