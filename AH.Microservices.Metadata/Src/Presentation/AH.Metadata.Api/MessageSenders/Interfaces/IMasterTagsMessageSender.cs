using System.Security.Claims;
using AH.Metadata.Application.Dtos;

namespace AH.Metadata.Api.MessageSenders.Interfaces;

/// <summary>
/// Interface for sending messages related to master tags
/// </summary>
public interface IMasterTagsMessageSender
{
    /// <summary>
    /// Send a message to create a master tags
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag to create</param>
    /// <returns></returns>
    Task SendCreateMasterTagMessageAsync(ClaimsPrincipal user, MasterTagDto masterTag);
    
    /// <summary>
    /// Send a message to update a master tag
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag to update</param>
    /// <returns></returns>
    Task SendUpdateMasterTagMessageAsync(ClaimsPrincipal user, MasterTagDto masterTag);
    
    /// <summary>
    /// Send a message to delete a master tag
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag to delete</param>
    /// <returns></returns>
    Task SendDeleteMasterTagMessageAsync(ClaimsPrincipal user, MasterTagDto masterTag);
}