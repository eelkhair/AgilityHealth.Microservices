namespace AH.Shared.Application.Interfaces;

public interface ICorrelationId
{
    string Get();
    void Set(string correlationId);
}