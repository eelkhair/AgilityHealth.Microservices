﻿namespace AH.Metadata.Shared.V1.Models.Responses.Lists;

/// <summary>
/// Represents an Industry.
/// </summary>
public class IndustryResponse : BaseResponse
{
    /// <summary>
    /// Industry Name
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Is this the default industry?
    /// </summary>
    public bool IsDefault { get; set; }
}