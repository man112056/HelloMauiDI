using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloMauiDI;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    [ObservableProperty]
    private String userName = "";

    [ObservableProperty]
    private String pwd = "";

    [ObservableProperty]
    private String status = "";

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [RelayCommand]
    private void Login()
    {
        bool result = _authService.Login(UserName, Pwd);
        if (result)
        {
            Status = "success";
        }
        else
        {
            Status = "Failed";
        }
    }
}