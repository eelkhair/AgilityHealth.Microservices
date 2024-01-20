namespace AH.User.Domain.Entities;


public class ApplicationUserClaim: BaseAuditableEntity
{
    public int UserId { get; set; }
    public string ClaimType { get; set; } = null!;
    public string ClaimValue { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}
