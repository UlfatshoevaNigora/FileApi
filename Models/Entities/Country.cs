namespace FilesAPI.Models.Entities;

public class Country
{
    public int id { get; set; }
    public string NameOfCountry { get; set; }
    public string Description { get; set; }
    public virtual List<City> Cities { get; set; }
}
