namespace AH.Integration.Auth0.ServiceAgent;

public interface IServiceAgentFactory
{
    IAuth0Resource GetAuth0Resource();
}