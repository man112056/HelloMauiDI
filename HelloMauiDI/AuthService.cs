namespace HelloMauiDI;

public class AuthService : IAuthService
{
    public bool Login(string userName, string pwd)
    {
        return userName == "admin" && pwd == "admin";
    }
}