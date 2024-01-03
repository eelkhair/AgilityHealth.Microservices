namespace AH.Company.Application.Dtos;

public class CompanyDto
{
    public Guid UId{ get; set; }
    public string Name { get; set; } = string.Empty;
    public string DomainName { get; set; } = string.Empty;
}