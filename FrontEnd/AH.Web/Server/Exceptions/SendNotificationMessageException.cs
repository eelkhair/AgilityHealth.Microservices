namespace AH.Web.Server.Exceptions;

public class SendNotificationMessageException : ApplicationException
{
    public SendNotificationMessageException()
    {
        
    }
    // ReSharper disable once UnusedMember.Global
    public SendNotificationMessageException(string message) : base(message) { }
    public SendNotificationMessageException(string message, Exception innerException) : base(message, innerException) { }
}
