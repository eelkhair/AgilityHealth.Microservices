using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AH.Metadata.Persistence;

public static class Seeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SurveyType>().HasData(
            new SurveyType { Id = 1, Name = "Team" , CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new SurveyType { Id = 2, Name = "Multi-Team", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new SurveyType { Id = 3, Name = "Individual", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new SurveyType { Id = 4, Name = "Organizational", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new SurveyType { Id = 5, Name = "Facilitator", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );
        
        modelBuilder.Entity<GrowthPlanStatus>().HasData(
            new GrowthPlanStatus
            {
                Id = 1, Status = "Archive", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 2, Status = "Cancelled", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 3, Status = "Committed", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 4, Status = "Done", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 5, Status = "In Progress", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 6, Status = "Not Started", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new GrowthPlanStatus
            {
                Id = 7, Status = "On Hold", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        
        modelBuilder.Entity<Industry>().HasData(
            new Industry
            {
                Id = 1, Name = "Agile Consulting", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 2, Name = "Agriculture and Forestry", IsDefault = false, CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 3, Name = "Computer/Network Services", IsDefault = false, CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 4, Name = "Consulting", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 5, Name = "Defense/Military", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 6, Name = "E-Commerce", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 7, Name = "Education", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 8, Name = "Engineering & Construction", IsDefault = false, CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 9, Name = "Entertainment", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 10, Name = "Finance", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 11, Name = "Government", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 12, Name = "Healthcare", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 13, Name = "Insurance", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 14, Name = "Manufacturing", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 15, Name = "Marketing", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 16, Name = "Mining, Oil and Gas", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 17, Name = "Other", IsDefault = true, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 18, Name = "Real Estate", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 19, Name = "Retail", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 20, Name = "Software Development", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 21, Name = "Staffing", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 22, Name = "Telecommunications", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 23, Name = "Transportation", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 24, Name = "Travel & Tourism", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 25, Name = "Utilities", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 26, Name = "Wholesale [Trade]", IsDefault = false, CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            }
        );
        

        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1, Name = "Afghanistan", Code = "AF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 2, Name = "Åland Islands", Code = "AX", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 3, Name = "Albania", Code = "AL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 4, Name = "Algeria", Code = "DZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 5, Name = "American Samoa", Code = "AS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 6, Name = "Andorra", Code = "AD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 7, Name = "Angola", Code = "AO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 8, Name = "Anguilla", Code = "AI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 9, Name = "Antarctica", Code = "AQ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 10, Name = "Antigua and Barbuda", Code = "AG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 11, Name = "Argentina", Code = "AR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 12, Name = "Armenia", Code = "AM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 13, Name = "Aruba", Code = "AW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 14, Name = "Australia", Code = "AU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 15, Name = "Austria", Code = "AT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 16, Name = "Azerbaijan", Code = "AZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 17, Name = "Bahamas", Code = "BS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 18, Name = "Bahrain", Code = "BH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 19, Name = "Bangladesh", Code = "BD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 20, Name = "Barbados", Code = "BB", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 21, Name = "Belarus", Code = "BY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 22, Name = "Belgium", Code = "BE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 23, Name = "Belize", Code = "BZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 24, Name = "Benin", Code = "BJ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 25, Name = "Bermuda", Code = "BM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 26, Name = "Bhutan", Code = "BT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 27, Name = "Bolivia, Plurinational State of", Code = "BO", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 28, Name = "Bonaire, Sint Eustatius and Saba", Code = "BQ", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 29, Name = "Bosnia and Herzegovina", Code = "BA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 30, Name = "Botswana", Code = "BW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 31, Name = "Brazil", Code = "BR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 32, Name = "British Indian Ocean Territory", Code = "IO", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 33, Name = "Brunei Darussalam", Code = "BN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 34, Name = "Bulgaria", Code = "BG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 35, Name = "Burkina Faso", Code = "BF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 36, Name = "Burundi", Code = "BI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 37, Name = "Cambodia", Code = "KH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 38, Name = "Cameroon", Code = "CM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 39, Name = "Canada", Code = "CA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 40, Name = "Cape Verde", Code = "CV", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 41, Name = "Cayman Islands", Code = "KY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 42, Name = "Central African Republic", Code = "CF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 43, Name = "Chad", Code = "TD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 44, Name = "Chile", Code = "CL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 45, Name = "China", Code = "CN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 46, Name = "Christmas Island", Code = "CX", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 47, Name = "Cocos (Keeling) Islands", Code = "CC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 48, Name = "Colombia", Code = "CO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 49, Name = "Comoros", Code = "KM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 50, Name = "Congo", Code = "CG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 51, Name = "Congo, The Democratic Republic of the", Code = "CD", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 52, Name = "Cook Islands", Code = "CK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 53, Name = "Costa Rica", Code = "CR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 54, Name = "Côte d Ivoire", Code = "CI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 55, Name = "Croatia", Code = "HR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 56, Name = "Cuba", Code = "CU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 57, Name = "Curaçao", Code = "CW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 58, Name = "Cyprus", Code = "CY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 59, Name = "Czech Republic", Code = "CZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 60, Name = "Denmark", Code = "DK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 61, Name = "Djibouti", Code = "DJ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 62, Name = "Dominica", Code = "DM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 63, Name = "Dominican Republic", Code = "DO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 64, Name = "Ecuador", Code = "EC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 65, Name = "Egypt", Code = "EG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 66, Name = "El Salvador", Code = "SV", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 67, Name = "Equatorial Guinea", Code = "GQ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 68, Name = "Eritrea", Code = "ER", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 69, Name = "Estonia", Code = "EE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 70, Name = "Ethiopia", Code = "ET", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 71, Name = "Falkland Islands (Malvinas)", Code = "FK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 72, Name = "Faroe Islands", Code = "FO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 73, Name = "Fiji", Code = "FJ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 74, Name = "Finland", Code = "FI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 75, Name = "France", Code = "FR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 76, Name = "French Guiana", Code = "GF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 77, Name = "French Polynesia", Code = "PF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 78, Name = "French Southern Territories", Code = "TF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 79, Name = "Gabon", Code = "GA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 80, Name = "Gambia", Code = "GM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 81, Name = "Georgia", Code = "GE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 82, Name = "Germany", Code = "DE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 83, Name = "Ghana", Code = "GH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 84, Name = "Gibraltar", Code = "GI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 85, Name = "Greece", Code = "GR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 86, Name = "Greenland", Code = "GL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 87, Name = "Grenada", Code = "GD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 88, Name = "Guadeloupe", Code = "GP", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 89, Name = "Guam", Code = "GU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 90, Name = "Guatemala", Code = "GT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 91, Name = "Guernsey", Code = "GG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 92, Name = "Guinea", Code = "GN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 93, Name = "Guinea-Bissau", Code = "GW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 94, Name = "Guyana", Code = "GY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 95, Name = "Haiti", Code = "HT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 96, Name = "Heard Island and McDonald Islands", Code = "HM", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 97, Name = "Holy See Vatican City State)", Code = "VA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 98, Name = "Honduras", Code = "HN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 99, Name = "Hong Kong ", Code = "HK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 100, Name = "Hungary", Code = "HU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 101, Name = "Iceland", Code = "IS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 102, Name = "India", Code = "IN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 103, Name = "Indonesia", Code = "ID", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 104, Name = "Installations in International Waters", Code = "XZ", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 105, Name = "Iran, Islamic Republic of", Code = "IR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 106, Name = "Iraq", Code = "IQ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 107, Name = "Ireland", Code = "IE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 108, Name = "Isle of Man", Code = "IM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 109, Name = "Israel", Code = "IL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 110, Name = "Italy", Code = "IT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 111, Name = "Jamaica", Code = "JM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 112, Name = "Japan", Code = "JP", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 113, Name = "Jersey", Code = "JE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 114, Name = "Jordan", Code = "JO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 115, Name = "Kazakhstan", Code = "KZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 116, Name = "Kenya", Code = "KE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 117, Name = "Kiribati", Code = "KI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 118, Name = "Korea, Democratic People's Republic of", Code = "KP", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 119, Name = "Korea, Republic of", Code = "KR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 120, Name = "Kuwait", Code = "KW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 121, Name = "Kyrgyzstan", Code = "KG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 122, Name = "Lao People's Democratic Republic", Code = "LA", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 123, Name = "Latvia", Code = "LV", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 124, Name = "Lebanon", Code = "LB", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 125, Name = "Lesotho", Code = "LS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 126, Name = "Liberia", Code = "LR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 127, Name = "Libya", Code = "LY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 128, Name = "Liechtenstein", Code = "LI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 129, Name = "Lithuania", Code = "LT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 130, Name = "Luxembourg", Code = "LU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 131, Name = "Macao", Code = "MO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 132, Name = "Macedonia, The former Yugoslav Republic of", Code = "MK", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 133, Name = "Madagascar", Code = "MG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 134, Name = "Malawi", Code = "MW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 135, Name = "Malaysia", Code = "MY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 136, Name = "Maldives", Code = "MV", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 137, Name = "Mali", Code = "ML", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 138, Name = "Malta", Code = "MT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 139, Name = "Marshall Islands", Code = "MH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 140, Name = "Martinique", Code = "MQ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 141, Name = "Mauritania", Code = "MR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 142, Name = "Mauritius", Code = "MU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 143, Name = "Mayotte", Code = "YT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 144, Name = "Mexico", Code = "MX", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 145, Name = "Micronesia, Federated States of", Code = "FM", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 146, Name = "Moldova, Republic of", Code = "MD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 147, Name = "Monaco", Code = "MC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 148, Name = "Mongolia", Code = "MN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 149, Name = "Montenegro", Code = "ME", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 150, Name = "Montserrat", Code = "MS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 151, Name = "Morocco", Code = "MA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 152, Name = "Mozambique", Code = "MZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 153, Name = "Myanmar", Code = "MM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 154, Name = "Namibia", Code = "NA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 155, Name = "Nauru", Code = "NR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 156, Name = "Nepal", Code = "NP", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 157, Name = "Netherlands", Code = "NL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 158, Name = "New Caledonia", Code = "NC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 159, Name = "New Zealand", Code = "NZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 160, Name = "Nicaragua", Code = "NI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 161, Name = "Niger", Code = "NE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 162, Name = "Nigeria", Code = "NG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 163, Name = "Niue", Code = "NU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 164, Name = "Norfolk Island", Code = "NF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 165, Name = "Northern Mariana Islands", Code = "MP", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 166, Name = "Norway", Code = "NO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 167, Name = "Oman", Code = "OM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 168, Name = "Pakistan", Code = "PK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 169, Name = "Palau", Code = "PW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 170, Name = "Palestine, State of", Code = "PS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 171, Name = "Panama", Code = "PA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 172, Name = "Papua New Guinea", Code = "PG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 173, Name = "Paraguay", Code = "PY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 174, Name = "Peru", Code = "PE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 175, Name = "Philippines", Code = "PH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 176, Name = "Pitcairn", Code = "PN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 177, Name = "Poland", Code = "PL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 178, Name = "Portugal", Code = "PT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 179, Name = "Puerto Rico", Code = "PR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 180, Name = "Qatar", Code = "QA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 181, Name = "Réunion", Code = "RE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 182, Name = "Romania", Code = "RO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 183, Name = "Russian Federation", Code = "RU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 184, Name = "Rwanda", Code = "RW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 185, Name = "Saint Barthélemy", Code = "BL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 186, Name = "Saint Helena, Ascension and Tristan Da Cunha", Code = "SH", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 187, Name = "Saint Kitts and Nevis", Code = "KN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 188, Name = "Saint Lucia", Code = "LC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 189, Name = "Saint Martin (French Part)", Code = "MF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 190, Name = "Saint Pierre and Miquelon", Code = "PM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 191, Name = "Saint Vincent and the Grenadines", Code = "VC", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 192, Name = "Samoa", Code = "WS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 193, Name = "San Marino", Code = "SM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 194, Name = "Sao Tome and Principe", Code = "ST", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 195, Name = "Saudi Arabia", Code = "SA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 196, Name = "Senegal", Code = "SN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 197, Name = "Serbia", Code = "RS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 198, Name = "Seychelles", Code = "SC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 199, Name = "Sierra Leone", Code = "SL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 200, Name = "Singapore", Code = "SG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 201, Name = "Sint Maarten (Dutch Part)", Code = "SX", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 202, Name = "Slovakia", Code = "SK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 203, Name = "Slovenia", Code = "SI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 204, Name = "Solomon Islands", Code = "SB", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 205, Name = "Somalia", Code = "SO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 206, Name = "South Africa", Code = "ZA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 207, Name = "South Georgia and the South Sandwich Islands", Code = "GS", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 208, Name = "South Sudan", Code = "SS", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 209, Name = "Spain", Code = "ES", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 210, Name = "Sri Lanka", Code = "LK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 211, Name = "Sudan", Code = "SD", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 212, Name = "Suriname", Code = "SR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 213, Name = "Svalbard and Jan Mayen", Code = "SJ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 214, Name = "Swaziland", Code = "SZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 215, Name = "Sweden", Code = "SE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 216, Name = "Switzerland", Code = "CH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 217, Name = "Syrian Arab Republic", Code = "SY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 218, Name = "Taiwan, Province of China", Code = "TW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 219, Name = "Tajikistan", Code = "TJ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 220, Name = "Tanzania, United Republic of", Code = "TZ", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 221, Name = "Thailand", Code = "TH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 222, Name = "Timor-Leste", Code = "TL", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 223, Name = "Togo", Code = "TG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 224, Name = "Tokelau", Code = "TK", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 225, Name = "Tonga", Code = "TO", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 226, Name = "Trinidad and Tobago", Code = "TT", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 227, Name = "Tunisia", Code = "TN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 228, Name = "Turkey", Code = "TR", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 229, Name = "Turkmenistan", Code = "TM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 230, Name = "Turks and Caicos Islands", Code = "TC", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 231, Name = "Tuvalu", Code = "TV", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 232, Name = "Uganda", Code = "UG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 233, Name = "Ukraine", Code = "UA", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 234, Name = "United Arab Emirates", Code = "AE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 235, Name = "United Kingdom", Code = "GB", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 236, Name = "United States", Code = "US", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 237, Name = "United States Minor Outlying Islands", Code = "UM", CreatedBy = "System",
                UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 238, Name = "Uruguay", Code = "UY", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 239, Name = "Uzbekistan", Code = "UZ", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 240, Name = "Vanuatu", Code = "VU", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 241, Name = "Venezuela", Code = "VE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 242, Name = "Viet Nam", Code = "VN", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 243, Name = "Virgin Islands, British", Code = "VG", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 244, Name = "Virgin Islands, U.S.", Code = "VI", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 245, Name = "Wallis and Futuna", Code = "WF", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 246, Name = "Western Sahara", Code = "EH", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 247, Name = "Yemen", Code = "YE", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 248, Name = "Zambia", Code = "ZM", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            },
            new Country
            {
                Id = 249, Name = "Zimbabwe", Code = "ZW", CreatedBy = "System", UpdatedBy = "System",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            });
        
        
        
    }
}