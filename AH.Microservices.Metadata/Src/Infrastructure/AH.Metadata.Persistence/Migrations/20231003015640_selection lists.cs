using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AH.Metadata.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class selectionlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Country",
                columns: new[] { "CountryId", "CountryCode", "CreatedAt", "CreatedBy", "CountryName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "AF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1842), "System", "Afghanistan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1842), "System" },
                    { 2, "AX", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1843), "System", "Åland Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1844), "System" },
                    { 3, "AL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1845), "System", "Albania", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1845), "System" },
                    { 4, "DZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1846), "System", "Algeria", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1846), "System" },
                    { 5, "AS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1847), "System", "American Samoa", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1847), "System" },
                    { 6, "AD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1848), "System", "Andorra", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1849), "System" },
                    { 7, "AO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1850), "System", "Angola", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1850), "System" },
                    { 8, "AI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1851), "System", "Anguilla", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1851), "System" },
                    { 9, "AQ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1852), "System", "Antarctica", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1853), "System" },
                    { 10, "AG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1854), "System", "Antigua and Barbuda", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1854), "System" },
                    { 11, "AR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1855), "System", "Argentina", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1855), "System" },
                    { 12, "AM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1856), "System", "Armenia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1856), "System" },
                    { 13, "AW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1857), "System", "Aruba", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1858), "System" },
                    { 14, "AU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1860), "System", "Australia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1860), "System" },
                    { 15, "AT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1861), "System", "Austria", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1861), "System" },
                    { 16, "AZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1862), "System", "Azerbaijan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1862), "System" },
                    { 17, "BS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1863), "System", "Bahamas", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1863), "System" },
                    { 18, "BH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1864), "System", "Bahrain", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1865), "System" },
                    { 19, "BD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1866), "System", "Bangladesh", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1866), "System" },
                    { 20, "BB", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1867), "System", "Barbados", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1867), "System" },
                    { 21, "BY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1868), "System", "Belarus", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1868), "System" },
                    { 22, "BE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1869), "System", "Belgium", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1869), "System" },
                    { 23, "BZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1870), "System", "Belize", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1871), "System" },
                    { 24, "BJ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1872), "System", "Benin", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1872), "System" },
                    { 25, "BM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1873), "System", "Bermuda", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1873), "System" },
                    { 26, "BT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1874), "System", "Bhutan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1874), "System" },
                    { 27, "BO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1875), "System", "Bolivia, Plurinational State of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1875), "System" },
                    { 28, "BQ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1876), "System", "Bonaire, Sint Eustatius and Saba", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1877), "System" },
                    { 29, "BA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1878), "System", "Bosnia and Herzegovina", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1878), "System" },
                    { 30, "BW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1879), "System", "Botswana", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1879), "System" },
                    { 31, "BR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1880), "System", "Brazil", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1880), "System" },
                    { 32, "IO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1881), "System", "British Indian Ocean Territory", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1881), "System" },
                    { 33, "BN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1882), "System", "Brunei Darussalam", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1883), "System" },
                    { 34, "BG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1884), "System", "Bulgaria", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1884), "System" },
                    { 35, "BF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1885), "System", "Burkina Faso", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1885), "System" },
                    { 36, "BI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1886), "System", "Burundi", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1886), "System" },
                    { 37, "KH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1887), "System", "Cambodia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1887), "System" },
                    { 38, "CM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1888), "System", "Cameroon", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1889), "System" },
                    { 39, "CA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1890), "System", "Canada", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1890), "System" },
                    { 40, "CV", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1891), "System", "Cape Verde", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1891), "System" },
                    { 41, "KY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1892), "System", "Cayman Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1892), "System" },
                    { 42, "CF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1893), "System", "Central African Republic", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1893), "System" },
                    { 43, "TD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1894), "System", "Chad", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1895), "System" },
                    { 44, "CL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1896), "System", "Chile", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1896), "System" },
                    { 45, "CN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1897), "System", "China", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1897), "System" },
                    { 46, "CX", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1898), "System", "Christmas Island", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1898), "System" },
                    { 47, "CC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1899), "System", "Cocos (Keeling) Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1900), "System" },
                    { 48, "CO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1900), "System", "Colombia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1901), "System" },
                    { 49, "KM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1902), "System", "Comoros", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1903), "System" },
                    { 50, "CG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1904), "System", "Congo", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1904), "System" },
                    { 51, "CD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1905), "System", "Congo, The Democratic Republic of the", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1905), "System" },
                    { 52, "CK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1906), "System", "Cook Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1906), "System" },
                    { 53, "CR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1907), "System", "Costa Rica", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1908), "System" },
                    { 54, "CI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1909), "System", "Côte d Ivoire", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1909), "System" },
                    { 55, "HR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1910), "System", "Croatia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1910), "System" },
                    { 56, "CU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1911), "System", "Cuba", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1911), "System" },
                    { 57, "CW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1912), "System", "Curaçao", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1912), "System" },
                    { 58, "CY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1913), "System", "Cyprus", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1914), "System" },
                    { 59, "CZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1915), "System", "Czech Republic", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1915), "System" },
                    { 60, "DK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1916), "System", "Denmark", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1916), "System" },
                    { 61, "DJ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1917), "System", "Djibouti", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1917), "System" },
                    { 62, "DM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1918), "System", "Dominica", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1919), "System" },
                    { 63, "DO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1920), "System", "Dominican Republic", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1920), "System" },
                    { 64, "EC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1921), "System", "Ecuador", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1921), "System" },
                    { 65, "EG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1922), "System", "Egypt", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1922), "System" },
                    { 66, "SV", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1923), "System", "El Salvador", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1923), "System" },
                    { 67, "GQ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1924), "System", "Equatorial Guinea", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1925), "System" },
                    { 68, "ER", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1926), "System", "Eritrea", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1926), "System" },
                    { 69, "EE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1927), "System", "Estonia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1927), "System" },
                    { 70, "ET", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1928), "System", "Ethiopia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1928), "System" },
                    { 71, "FK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1929), "System", "Falkland Islands (Malvinas)", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1930), "System" },
                    { 72, "FO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1931), "System", "Faroe Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1931), "System" },
                    { 73, "FJ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1932), "System", "Fiji", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1932), "System" },
                    { 74, "FI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1933), "System", "Finland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1933), "System" },
                    { 75, "FR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1934), "System", "France", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1935), "System" },
                    { 76, "GF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1936), "System", "French Guiana", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1936), "System" },
                    { 77, "PF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1937), "System", "French Polynesia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1937), "System" },
                    { 78, "TF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1956), "System", "French Southern Territories", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1956), "System" },
                    { 79, "GA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1957), "System", "Gabon", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1957), "System" },
                    { 80, "GM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1958), "System", "Gambia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1959), "System" },
                    { 81, "GE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1960), "System", "Georgia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1960), "System" },
                    { 82, "DE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1961), "System", "Germany", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1961), "System" },
                    { 83, "GH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1962), "System", "Ghana", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1962), "System" },
                    { 84, "GI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1963), "System", "Gibraltar", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1964), "System" },
                    { 85, "GR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1966), "System", "Greece", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1966), "System" },
                    { 86, "GL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1967), "System", "Greenland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1967), "System" },
                    { 87, "GD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1968), "System", "Grenada", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1968), "System" },
                    { 88, "GP", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1969), "System", "Guadeloupe", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1970), "System" },
                    { 89, "GU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1970), "System", "Guam", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1971), "System" },
                    { 90, "GT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1972), "System", "Guatemala", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1972), "System" },
                    { 91, "GG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1973), "System", "Guernsey", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1973), "System" },
                    { 92, "GN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1974), "System", "Guinea", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1974), "System" },
                    { 93, "GW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1975), "System", "Guinea-Bissau", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1976), "System" },
                    { 94, "GY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1977), "System", "Guyana", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1977), "System" },
                    { 95, "HT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1978), "System", "Haiti", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1978), "System" },
                    { 96, "HM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1979), "System", "Heard Island and McDonald Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1979), "System" },
                    { 97, "VA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1980), "System", "Holy See Vatican City State)", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1981), "System" },
                    { 98, "HN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1982), "System", "Honduras", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1982), "System" },
                    { 99, "HK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1983), "System", "Hong Kong ", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1983), "System" },
                    { 100, "HU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1984), "System", "Hungary", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1984), "System" },
                    { 101, "IS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1985), "System", "Iceland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1986), "System" },
                    { 102, "IN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1986), "System", "India", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1987), "System" },
                    { 103, "ID", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1988), "System", "Indonesia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1988), "System" },
                    { 104, "XZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1989), "System", "Installations in International Waters", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1989), "System" },
                    { 105, "IR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1990), "System", "Iran, Islamic Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1990), "System" },
                    { 106, "IQ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1991), "System", "Iraq", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1992), "System" },
                    { 107, "IE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1992), "System", "Ireland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1993), "System" },
                    { 108, "IM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1994), "System", "Isle of Man", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1994), "System" },
                    { 109, "IL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1997), "System", "Israel", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1997), "System" },
                    { 110, "IT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1998), "System", "Italy", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1998), "System" },
                    { 111, "JM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1999), "System", "Jamaica", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1999), "System" },
                    { 112, "JP", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2000), "System", "Japan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2000), "System" },
                    { 113, "JE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2001), "System", "Jersey", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2002), "System" },
                    { 114, "JO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2003), "System", "Jordan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2003), "System" },
                    { 115, "KZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2004), "System", "Kazakhstan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2004), "System" },
                    { 116, "KE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2005), "System", "Kenya", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2005), "System" },
                    { 117, "KI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2006), "System", "Kiribati", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2006), "System" },
                    { 118, "KP", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2007), "System", "Korea, Democratic People's Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2008), "System" },
                    { 119, "KR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2009), "System", "Korea, Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2009), "System" },
                    { 120, "KW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2010), "System", "Kuwait", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2010), "System" },
                    { 121, "KG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2012), "System", "Kyrgyzstan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2012), "System" },
                    { 122, "LA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2013), "System", "Lao People's Democratic Republic", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2013), "System" },
                    { 123, "LV", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2014), "System", "Latvia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2014), "System" },
                    { 124, "LB", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2015), "System", "Lebanon", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2016), "System" },
                    { 125, "LS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2017), "System", "Lesotho", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2017), "System" },
                    { 126, "LR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2018), "System", "Liberia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2018), "System" },
                    { 127, "LY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2019), "System", "Libya", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2019), "System" },
                    { 128, "LI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2020), "System", "Liechtenstein", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2021), "System" },
                    { 129, "LT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2021), "System", "Lithuania", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2022), "System" },
                    { 130, "LU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2023), "System", "Luxembourg", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2023), "System" },
                    { 131, "MO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2024), "System", "Macao", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2024), "System" },
                    { 132, "MK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2025), "System", "Macedonia, The former Yugoslav Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2025), "System" },
                    { 133, "MG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2026), "System", "Madagascar", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2027), "System" },
                    { 134, "MW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2028), "System", "Malawi", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2028), "System" },
                    { 135, "MY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2029), "System", "Malaysia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2029), "System" },
                    { 136, "MV", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2030), "System", "Maldives", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2030), "System" },
                    { 137, "ML", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2031), "System", "Mali", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2031), "System" },
                    { 138, "MT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2032), "System", "Malta", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2033), "System" },
                    { 139, "MH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2034), "System", "Marshall Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2034), "System" },
                    { 140, "MQ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2035), "System", "Martinique", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2035), "System" },
                    { 141, "MR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2036), "System", "Mauritania", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2036), "System" },
                    { 142, "MU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2037), "System", "Mauritius", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2037), "System" },
                    { 143, "YT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2039), "System", "Mayotte", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2039), "System" },
                    { 144, "MX", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2040), "System", "Mexico", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2040), "System" },
                    { 145, "FM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2041), "System", "Micronesia, Federated States of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2041), "System" },
                    { 146, "MD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2042), "System", "Moldova, Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2043), "System" },
                    { 147, "MC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2043), "System", "Monaco", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2044), "System" },
                    { 148, "MN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2045), "System", "Mongolia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2045), "System" },
                    { 149, "ME", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2046), "System", "Montenegro", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2046), "System" },
                    { 150, "MS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2047), "System", "Montserrat", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2047), "System" },
                    { 151, "MA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2048), "System", "Morocco", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2049), "System" },
                    { 152, "MZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2049), "System", "Mozambique", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2050), "System" },
                    { 153, "MM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2051), "System", "Myanmar", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2051), "System" },
                    { 154, "NA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2052), "System", "Namibia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2052), "System" },
                    { 155, "NR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2053), "System", "Nauru", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2053), "System" },
                    { 156, "NP", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2072), "System", "Nepal", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2073), "System" },
                    { 157, "NL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2074), "System", "Netherlands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2074), "System" },
                    { 158, "NC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2075), "System", "New Caledonia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2075), "System" },
                    { 159, "NZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2076), "System", "New Zealand", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2076), "System" },
                    { 160, "NI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2077), "System", "Nicaragua", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2078), "System" },
                    { 161, "NE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2078), "System", "Niger", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2079), "System" },
                    { 162, "NG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2080), "System", "Nigeria", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2080), "System" },
                    { 163, "NU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2081), "System", "Niue", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2081), "System" },
                    { 164, "NF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2082), "System", "Norfolk Island", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2082), "System" },
                    { 165, "MP", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2083), "System", "Northern Mariana Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2084), "System" },
                    { 166, "NO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2084), "System", "Norway", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2085), "System" },
                    { 167, "OM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2086), "System", "Oman", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2086), "System" },
                    { 168, "PK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2087), "System", "Pakistan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2087), "System" },
                    { 169, "PW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2089), "System", "Palau", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2089), "System" },
                    { 170, "PS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2090), "System", "Palestine, State of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2091), "System" },
                    { 171, "PA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2091), "System", "Panama", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2092), "System" },
                    { 172, "PG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2093), "System", "Papua New Guinea", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2093), "System" },
                    { 173, "PY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2094), "System", "Paraguay", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2094), "System" },
                    { 174, "PE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2095), "System", "Peru", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2095), "System" },
                    { 175, "PH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2096), "System", "Philippines", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2096), "System" },
                    { 176, "PN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2097), "System", "Pitcairn", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2098), "System" },
                    { 177, "PL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2099), "System", "Poland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2099), "System" },
                    { 178, "PT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2100), "System", "Portugal", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2100), "System" },
                    { 179, "PR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2101), "System", "Puerto Rico", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2101), "System" },
                    { 180, "QA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2102), "System", "Qatar", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2105), "System" },
                    { 181, "RE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2106), "System", "Réunion", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2106), "System" },
                    { 182, "RO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2107), "System", "Romania", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2108), "System" },
                    { 183, "RU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2109), "System", "Russian Federation", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2109), "System" },
                    { 184, "RW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2110), "System", "Rwanda", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2110), "System" },
                    { 185, "BL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2111), "System", "Saint Barthélemy", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2111), "System" },
                    { 186, "SH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2112), "System", "Saint Helena, Ascension and Tristan Da Cunha", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2112), "System" },
                    { 187, "KN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2113), "System", "Saint Kitts and Nevis", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2114), "System" },
                    { 188, "LC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2115), "System", "Saint Lucia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2115), "System" },
                    { 189, "MF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2116), "System", "Saint Martin (French Part)", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2116), "System" },
                    { 190, "PM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2117), "System", "Saint Pierre and Miquelon", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2117), "System" },
                    { 191, "VC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2118), "System", "Saint Vincent and the Grenadines", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2119), "System" },
                    { 192, "WS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2119), "System", "Samoa", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2120), "System" },
                    { 193, "SM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2121), "System", "San Marino", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2121), "System" },
                    { 194, "ST", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2122), "System", "Sao Tome and Principe", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2122), "System" },
                    { 195, "SA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2123), "System", "Saudi Arabia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2123), "System" },
                    { 196, "SN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2124), "System", "Senegal", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2125), "System" },
                    { 197, "RS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2125), "System", "Serbia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2126), "System" },
                    { 198, "SC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2127), "System", "Seychelles", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2127), "System" },
                    { 199, "SL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2128), "System", "Sierra Leone", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2128), "System" },
                    { 200, "SG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2129), "System", "Singapore", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2129), "System" },
                    { 201, "SX", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2130), "System", "Sint Maarten (Dutch Part)", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2131), "System" },
                    { 202, "SK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2131), "System", "Slovakia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2132), "System" },
                    { 203, "SI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2133), "System", "Slovenia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2133), "System" },
                    { 204, "SB", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2135), "System", "Solomon Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2136), "System" },
                    { 205, "SO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2137), "System", "Somalia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2137), "System" },
                    { 206, "ZA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2138), "System", "South Africa", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2138), "System" },
                    { 207, "GS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2139), "System", "South Georgia and the South Sandwich Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2139), "System" },
                    { 208, "SS", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2140), "System", "South Sudan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2140), "System" },
                    { 209, "ES", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2141), "System", "Spain", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2142), "System" },
                    { 210, "LK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2143), "System", "Sri Lanka", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2143), "System" },
                    { 211, "SD", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2144), "System", "Sudan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2144), "System" },
                    { 212, "SR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2145), "System", "Suriname", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2145), "System" },
                    { 213, "SJ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2146), "System", "Svalbard and Jan Mayen", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2146), "System" },
                    { 214, "SZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2147), "System", "Swaziland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2148), "System" },
                    { 215, "SE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2148), "System", "Sweden", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2149), "System" },
                    { 216, "CH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2151), "System", "Switzerland", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2151), "System" },
                    { 217, "SY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2152), "System", "Syrian Arab Republic", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2152), "System" },
                    { 218, "TW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2153), "System", "Taiwan, Province of China", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2153), "System" },
                    { 219, "TJ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2154), "System", "Tajikistan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2155), "System" },
                    { 220, "TZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2155), "System", "Tanzania, United Republic of", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2156), "System" },
                    { 221, "TH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2157), "System", "Thailand", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2157), "System" },
                    { 222, "TL", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2158), "System", "Timor-Leste", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2158), "System" },
                    { 223, "TG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2159), "System", "Togo", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2159), "System" },
                    { 224, "TK", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2160), "System", "Tokelau", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2160), "System" },
                    { 225, "TO", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2161), "System", "Tonga", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2162), "System" },
                    { 226, "TT", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2163), "System", "Trinidad and Tobago", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2163), "System" },
                    { 227, "TN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2164), "System", "Tunisia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2164), "System" },
                    { 228, "TR", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2166), "System", "Turkey", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2166), "System" },
                    { 229, "TM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2167), "System", "Turkmenistan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2167), "System" },
                    { 230, "TC", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2168), "System", "Turks and Caicos Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2169), "System" },
                    { 231, "TV", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2169), "System", "Tuvalu", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2170), "System" },
                    { 232, "UG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2171), "System", "Uganda", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2171), "System" },
                    { 233, "UA", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2172), "System", "Ukraine", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2172), "System" },
                    { 234, "AE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2173), "System", "United Arab Emirates", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2173), "System" },
                    { 235, "GB", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2203), "System", "United Kingdom", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2203), "System" },
                    { 236, "US", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2204), "System", "United States", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2204), "System" },
                    { 237, "UM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2205), "System", "United States Minor Outlying Islands", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2206), "System" },
                    { 238, "UY", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2207), "System", "Uruguay", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2207), "System" },
                    { 239, "UZ", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2208), "System", "Uzbekistan", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2208), "System" },
                    { 240, "VU", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2210), "System", "Vanuatu", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2210), "System" },
                    { 241, "VE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2211), "System", "Venezuela", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2212), "System" },
                    { 242, "VN", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2213), "System", "Viet Nam", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2213), "System" },
                    { 243, "VG", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2214), "System", "Virgin Islands, British", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2214), "System" },
                    { 244, "VI", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2215), "System", "Virgin Islands, U.S.", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2215), "System" },
                    { 245, "WF", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2216), "System", "Wallis and Futuna", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2217), "System" },
                    { 246, "EH", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2217), "System", "Western Sahara", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2218), "System" },
                    { 247, "YE", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2219), "System", "Yemen", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2219), "System" },
                    { 248, "ZM", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2220), "System", "Zambia", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2220), "System" },
                    { 249, "ZW", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2221), "System", "Zimbabwe", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(2221), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                columns: new[] { "GrowthPlanStatusId", "CreatedAt", "CreatedBy", "RecordStatus", "GrowthPlanStatusName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1761), "System", "Active", "Archive", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1762), "System" },
                    { 2, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1763), "System", "Active", "Cancelled", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1763), "System" },
                    { 3, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1764), "System", "Active", "Committed", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1765), "System" },
                    { 4, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1765), "System", "Active", "Done", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1766), "System" },
                    { 5, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1767), "System", "Active", "In Progress", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1767), "System" },
                    { 6, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1768), "System", "Active", "Not Started", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1768), "System" },
                    { 7, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1769), "System", "Active", "On Hold", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1769), "System" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Industry",
                columns: new[] { "IndustryId", "CreatedAt", "CreatedBy", "IsDefault", "IndustryName", "RecordStatus", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1779), "System", false, "Agile Consulting", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1780), "System" },
                    { 2, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1781), "System", false, "Agriculture and Forestry", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1781), "System" },
                    { 3, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1782), "System", false, "Computer/Network Services", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1782), "System" },
                    { 4, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1783), "System", false, "Consulting", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1784), "System" },
                    { 5, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1785), "System", false, "Defense/Military", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1785), "System" },
                    { 6, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1786), "System", false, "E-Commerce", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1786), "System" },
                    { 7, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1787), "System", false, "Education", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1787), "System" },
                    { 8, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1788), "System", false, "Engineering & Construction", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1789), "System" },
                    { 9, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1790), "System", false, "Entertainment", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1790), "System" },
                    { 10, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1791), "System", false, "Finance", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1791), "System" },
                    { 11, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1792), "System", false, "Government", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1792), "System" },
                    { 12, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1793), "System", false, "Healthcare", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1794), "System" },
                    { 13, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1795), "System", false, "Insurance", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1795), "System" },
                    { 14, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1796), "System", false, "Manufacturing", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1796), "System" },
                    { 15, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1797), "System", false, "Marketing", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1797), "System" },
                    { 16, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1799), "System", false, "Mining, Oil and Gas", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1799), "System" },
                    { 17, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1800), "System", true, "Other", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1800), "System" },
                    { 18, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1801), "System", false, "Real Estate", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1801), "System" },
                    { 19, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1802), "System", false, "Retail", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1803), "System" },
                    { 20, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1804), "System", false, "Software Development", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1804), "System" },
                    { 21, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1805), "System", false, "Staffing", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1805), "System" },
                    { 22, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1806), "System", false, "Telecommunications", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1806), "System" },
                    { 23, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1807), "System", false, "Transportation", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1807), "System" },
                    { 24, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1808), "System", false, "Travel & Tourism", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1809), "System" },
                    { 25, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1810), "System", false, "Utilities", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1810), "System" },
                    { 26, new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1811), "System", false, "Wholesale [Trade]", "Active", new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1811), "System" }
                });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1686), new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1687) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1691), new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1691) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1693), new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1693) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1694), new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1695) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1696), new DateTime(2023, 10, 3, 1, 56, 40, 90, DateTimeKind.Utc).AddTicks(1696) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 228);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 229);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 230);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 231);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 232);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 233);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 234);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 235);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 236);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 237);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 238);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 239);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 240);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 241);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 242);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 243);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 244);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 245);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 246);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 247);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 248);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 249);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "GrowthPlanStatus",
                keyColumn: "GrowthPlanStatusId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Metadata",
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 26);

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1849), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1850) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1854), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1856), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1856) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1857), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1858) });

            migrationBuilder.UpdateData(
                schema: "Metadata",
                table: "SurveyType",
                keyColumn: "SurveyTypeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1859), new DateTime(2023, 10, 1, 2, 42, 2, 339, DateTimeKind.Utc).AddTicks(1859) });
        }
    }
}
