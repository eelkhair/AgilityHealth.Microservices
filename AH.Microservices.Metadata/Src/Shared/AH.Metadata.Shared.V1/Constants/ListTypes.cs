using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Constants;


/// <summary>
/// The list of items that can be used for querying.
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public class ListTypes
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string Countries = "countries";
    public const string SurveyTypes = "survey-types";
    public const string Industries= "industries";
    public const string GrowthPlanStatuses = "growth-plan-statuses";
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member