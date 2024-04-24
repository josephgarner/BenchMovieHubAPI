using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubAPI.Database.Entities;

public class Cinema
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public Cinema(string name, string location)
    {
        Name = name;
        Location = location;
    }
}