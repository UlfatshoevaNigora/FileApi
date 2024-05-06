using System.ComponentModel.DataAnnotations.Schema;

namespace FilesAPI.Models.Entities;

public class City
{
    public int Id { get; set; }
    public string NameOfCity { get; set; }
    // public virtual Country Country { get; set; }
    [ForeignKey("Country")] 
    public int CountryId { get; set; }
}
