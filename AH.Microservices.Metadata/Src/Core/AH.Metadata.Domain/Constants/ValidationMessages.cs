namespace AH.Metadata.Domain.Constants;

public struct ValidationMessages
{
    #region Domain
    public const string DomainNameNotEmpty = "Name cannot be empty";
    public const string DomainNameMaxLength = "Name cannot exceed 250 characters";
    public const string DomainUIdNotEmpty = "UId cannot be empty";
    public const string DomainUIdDoesNotExist = "UId doesn't exist";
    #endregion
    
    #region Company
    public const string CompanyNameNotEmpty = "Name cannot be empty";
    public const string CompanyNameMaxLength = "Name cannot exceed 250 characters";
    public const string CompanyDomainUIdNotEmpty = "Domain UId cannot be empty";
    public const string CompanyDomainUIdNotFound = "Domain UId doesn't exist";
    public const string CompanyUIdDoesNotExist = "UId doesn't exist";
    public const string CompanyUIdNotEmpty = "UId cannot be empty";
    #endregion
    
    #region Lists
    public const string ListTypeNotEmpty = "no list types provided";
    #endregion
    
    #region MasterTagCategory
    public const string MasterTagCategoryNameRequired = "Name cannot be empty";
    public const string MasterTagCategoryNameMaxLength = "Name cannot exceed 250 characters";
    public const string MasterTagCategoryClassNameRequired = "ClassName cannot be empty";
    public const string MasterTagCategoryTypeRequired = "Type cannot be empty";
    public const string MasterTagCategoryClassNameInvalid = "ClassName is invalid";
    public const string MasterTagCategoryTypeInvalid = "Type is invalid";
    public const string MasterTagCategoryUIdDoesNotExist = "UId doesn't exist";
    public const string MasterTagCategoryUIdNotEmpty = "UId cannot be empty";
    #endregion
    
    #region MasterTag
    public const string MasterTagNameRequired = "Name cannot be empty";
    public const string MasterTagNameMaxLength = "Name cannot exceed 250 characters";
    public const string MasterTagClassNameRequired = "ClassName cannot be empty";
    public const string MasterTagCategoryRequired = "MasterTagCategoryUId cannot be empty";
    public const string MasterTagCategoryNotFound = "MasterTagCategoryUId doesn't exist";
    public const string MasterTagParentMasterTagNotFound = "ParentMasterTagUId doesn't exist";
    public const string MasterTagUIdDoesNotExist = "UId doesn't exist"; 
    public const string MasterTagUIdNotEmpty = "UId cannot be empty";
    #endregion

   
}