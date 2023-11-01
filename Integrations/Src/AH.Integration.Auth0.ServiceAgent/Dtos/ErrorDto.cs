namespace AH.Integration.Auth0.ServiceAgent.Dtos;

public class ErrorDto
{
    public ErrorDto(string statusCode, string error, string message)
    {
        StatusCode = statusCode;
        Error = error;
        Message = message;
    }

    public string StatusCode {get; }
    public string Error {get;}
    public string Message{get;}
}