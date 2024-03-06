
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [Key]
    //public string Id { get; set; } = null!;

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;
    //public string Email { get; set; } = null!;
 

    public string? Bio { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public string SecurityKey { get; set; } = null!;

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

}
