using System.Security.Claims;
using AH.Metadata.Application.Dtos;

namespace AH.Metadata.Api.MessageSenders.Interfaces;

/// <summary>
/// Interface for sending messages related to master tag categories
/// </summary>
public interface IMasterTagCategoriesMessageSender
{
    /// <summary>
    /// Send a message to create a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to create</param>
    /// <returns></returns>
    Task SendCreateMasterTagCategoryMessageAsync(ClaimsPrincipal user, MasterTagCategoryDto masterTagCategory);
    
    /// <summary>
    /// Send a message to update a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to update</param>
    /// <returns></returns>
    Task SendUpdateMasterTagCategoryMessageAsync(ClaimsPrincipal user, MasterTagCategoryDto masterTagCategory);
    
    /// <summary>
    /// Send a message to delete a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to delete</param>
    /// <returns></returns>
    Task SendDeleteMasterTagCategoryMessageAsync(ClaimsPrincipal user, MasterTagCategoryDto masterTagCategory);
}