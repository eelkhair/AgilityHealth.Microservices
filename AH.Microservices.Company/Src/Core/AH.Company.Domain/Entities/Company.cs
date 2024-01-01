using AH.Shared.Domain.Entities;

namespace AH.Company.Domain.Entities;

public class Company : BaseAuditableEntity
{
    public Company()
    {
        CompanySkillCategories = new List<CompanySkillCategory>();
        CompanyStakeholderCategories = new List<CompanyStakeholderCategory>();
        CompanyTeamCategories = new List<CompanyTeamCategory>();
        CompanyTeamMemberCategories = new List<CompanyTeamMemberCategory>();
    }

    public string Name { get; set; } = null!;
    public DateTime? ContractEndDate { get; set; }
    public DateTime? DateContractSigned { get; set; }
    public bool IsDraft { get; set; }
    public bool ManagedSubscription { get; set; }
    public bool RequireSecurityQuestions { get; set; }
    public bool TwoFactorAuthentication { get; set; }
    public bool TwoFactorBuAdmin { get; set; }
    public bool TwoFactorCompanyAdmin { get; set; }
    public bool TwoFactorIndividuals { get; set; }
    public bool TwoFactorOrgLeader { get; set; }
    public bool TwoFactorTeamAdmin { get; set; }
    public bool WatchList { get; set; }
    public int AssessmentsLimit { get; set; }
    
    public int ForcePasswordUpdate { get; set; }
    public int MaxSessionLength { get; set; }
    public int SessionTimeout { get; set; }
    public int TeamsLimit { get; set; }
    public int? AuditTrailRetentionPeriod { get; set; }
    public int? IndustryId { get; set; }
    
    public string? AccountManagerEmail { get; set; }
    public string? AccountManagerFirstName { get; set; }
    public string? AccountManagerLastName { get; set; }
    public string? AccountManagerPhone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? CompanyNotes { get; set; }
    public string? CompanyPartnerReferral { get; set; }
    public string? CompanyType { get; set; }
    public string? Country { get; set; }
    public string? IndividualPartnerReferral { get; set; }
    public string? Industry { get; set; }
    public string? IsoLanguageCode { get; set; }
    public string? LifeCycleStage { get; set; }
    public string? Logourl { get; set; }
    public string? LogoutUrl { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhotoPath { get; set; }
    public string? PricingTier { get; set; }
    public string? ReferralType { get; set; }
    public string? Size { get; set; }
    public string? State { get; set; }
    public string? SubscriptionHistory { get; set; }
    public string? SubscriptionType { get; set; }
    public string? TimeZoneInfoId { get; set; }
    public string? ZipCode { get; set; }
    public ICollection<CompanySkillCategory> CompanySkillCategories { get; set; }
    public ICollection<CompanyStakeholderCategory> CompanyStakeholderCategories { get; set; }
    public ICollection<CompanyTeamCategory> CompanyTeamCategories { get; set; }
    public ICollection<CompanyTeamMemberCategory> CompanyTeamMemberCategories { get; set; }
}
