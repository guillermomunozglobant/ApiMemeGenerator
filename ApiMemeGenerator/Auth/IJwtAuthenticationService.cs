using ApiMemeGenerator.Context;

namespace ApiMemeGenerator.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
        void SetContext(AppDBContext context);
    }
}
