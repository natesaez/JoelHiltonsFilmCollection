using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoelHiltonsFilmCollection.Models;

public class NewMovie
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "Category is required.")]
    public int? CategoryId { get; set; }
    public Categories? Category { get; set; }

    [Required(ErrorMessage = "A title is required")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Year must be 1888 or later.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; } = 0;

    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required(ErrorMessage = "Edited field is required")]
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    [Required(ErrorMessage = "Copied to Plex field is required")]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}