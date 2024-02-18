using System.ComponentModel.DataAnnotations;

namespace musicstore.Models;

public class AlbumViewModel
{
    [Display(Name = "AlbumName")]
    [Required(ErrorMessage = "{0} is a required field")] 
    public string AlbumName { get; set; }

    [Display(Name = "ArtistName")]
    [Required(ErrorMessage = "{0} is a required field")] 
    public string ArtistName { get; set; }
    
    [Display(Name = "Description")]
    [Required(ErrorMessage = "{0} is a required field")] 
    public string Description { get; set; }

    [Display(Name = "Price")]
    [Range(0, 19.00, ErrorMessage = "{0} must be a number between {1} and {2}")] 
    public decimal Price { get; set; }
}