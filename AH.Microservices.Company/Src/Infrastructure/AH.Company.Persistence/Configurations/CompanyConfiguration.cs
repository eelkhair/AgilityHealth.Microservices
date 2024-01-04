using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AH.Company.Persistence.Configurations;

public class CompanyConfiguration :IEntityTypeConfiguration<Domain.Entities.Company>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Company> builder)
    {
        builder.ToTable("Company", c=> c.HasComment(""));
        builder.ConfigureBaseAuditableEntity();
        builder.Property(e => e.AccountManagerEmail).HasMaxLength(256);
        builder.Property(e => e.AccountManagerFirstName).HasMaxLength(256);
        builder.Property(e => e.AccountManagerLastName).HasMaxLength(256);
        builder.Property(e => e.AccountManagerPhone).HasMaxLength(50);
        builder.Property(e => e.Address).HasMaxLength(255);
        builder.Property(e => e.AuditTrailRetentionPeriod).HasDefaultValueSql("((2))");
        builder.Property(e => e.City).HasMaxLength(255);
        builder.Property(e => e.ContractEndDate).HasColumnType("datetime2");
        builder.Property(e => e.Country).HasMaxLength(255);
        builder.Property(e => e.CompanyNotes);
        builder.Property(e => e.CompanyPartnerReferral);
        builder.Property(e => e.IndividualPartnerReferral);
        builder.Property(e => e.CompanyType).HasMaxLength(256);
        builder.Property(e => e.DateContractSigned).HasColumnType("datetime2");
        builder.Property(e => e.Industry).HasMaxLength(255);
        builder.Property(e => e.IsoLanguageCode).HasMaxLength(10);
        builder.Property(e => e.Logourl).HasMaxLength(255);
        builder.Property(e => e.LogoutUrl).HasMaxLength(500);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
        builder.Property(e => e.PhoneNumber).HasMaxLength(10);
        builder.Property(e => e.PhotoPath).HasMaxLength(255);
        builder.Property(e => e.Size).HasMaxLength(13);
        builder.Property(e => e.State).HasMaxLength(255);
        builder.Property(x=>x.SubscriptionType).HasMaxLength(255);
        builder.Property(x=>x.SubscriptionHistory).HasMaxLength(4000);
        builder.Property(e => e.TimeZoneInfoId).HasMaxLength(50);
        builder.Property(e => e.ZipCode).HasMaxLength(11);
        
        builder.HasMany(e => e.CompanySkillCategories)
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(e => e.CompanyStakeholderCategories)
            .WithOne(c=> c.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(e=> e.CompanyTeamCategories)
            .WithOne(c=>c.Company)
            .HasForeignKey(e=>e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(e=> e.CompanyTeamMemberCategories)
            .WithOne(c=>c.Company)
            .HasForeignKey(e=>e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}