namespace JWTKDSB20240903.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
