using System.ComponentModel.DataAnnotations;

namespace People.People.Core.Entities;

public class User
{
    [Key]
    public string Id { get; set; }

    [Required]
    [StringLength(100)] 
    public string Name { get;  set; }

    [Required]
    [EmailAddress] 
    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(300)] 
    public string Picture { get;  set; }
}