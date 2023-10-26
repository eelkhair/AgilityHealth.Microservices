using AH.Shared.Application.Interfaces;

namespace AH.Shared.Application.Logging;

public class CorrelationId : ICorrelationId

{
    private string _correlationId = Guid.NewGuid().ToString();

    public string Get() => _correlationId;

    public void Set(string correlationId) { 
        _correlationId = correlationId;
    }
}