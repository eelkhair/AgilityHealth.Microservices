namespace AH.User.Domain.Entities;

public class ApplicationUser : BaseAuditableEntity
{
    public string FirstName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    public string LastName { get; set; } = null!;
    public string AvatarUrl { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string LinkedIn { get; set; } = null!;
    public string TimeZoneInfoId { get; set; } = null!;

    public ICollection<ApplicationUserClaim> UserClaims { get; set; } = new List<ApplicationUserClaim>();
}