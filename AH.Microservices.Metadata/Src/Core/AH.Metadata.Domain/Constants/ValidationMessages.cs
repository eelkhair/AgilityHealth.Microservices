namespace AH.Metadata.Domain.Constants;

public struct ValidationMessages
{
    public const string DomainNameNotEmpty = "Name cannot be empty";
    public const string DomainNameMaxLength = "Name cannot exceed 250 characters";
    public const string DomainUIdNotEmpty = "UId cannot be empty";
    public const string DomainUIdDoesNotExist = "UId doesn't exist";
    public const string CompanyNameNotEmpty = "Name cannot be empty";
    public const string CompanyNameMaxLength = "Name cannot exceed 250 characters";
    public const string CompanyDomainUIdNotEmpty = "Domain UId cannot be empty";
    public const string CompanyDomainUIdNotFound = "Domain UId doesn't exist";
    public const string CompanyUIdDoesNotExist = "UId doesn't exist";
    public const string CompanyUIdNotEmpty = "UId cannot be empty";
    public const string ListTypeNotEmpty = "no list types provided";
    public const string MasterTagCategoryNameRequired = "Name cannot be empty";
    public const string MasterTagCategoryNameMaxLength = "Name cannot exceed 250 characters";
    public const string MasterTagCategoryClassNameRequired = "ClassName cannot be empty";
    public const string MasterTagCategoryTypeRequired = "Type cannot be empty";
    public const string MasterTagCategoryClassNameInvalid = "ClassName is invalid";
    public const string MasterTagCategoryTypeInvalid = "Type is invalid";
    public const string MasterTagCategoryUIdDoesNotExist = "UId doesn't exist";
    public const string MasterTagCategoryUIdNotEmpty = "UId cannot be empty";
}