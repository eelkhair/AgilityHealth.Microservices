using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Models.Responses;


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class BaseResponse

{
    public Guid UId { get; set; }
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public abstract class BaseAuditableResponse : BaseResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string UpdatedBy { get; set; } = string.Empty; 
    public string RecordStatus { get; set; } = "Active";
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member