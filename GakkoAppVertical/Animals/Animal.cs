using System.ComponentModel.DataAnnotations;

namespace GakkoAppVertical.Animals;

public class AnimalProperties
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(200)]
    public string Category { get; set; }

    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
}

public class Animal : AnimalProperties
{
    [Required]
    public int? IdAnimal { get; set; }
}
