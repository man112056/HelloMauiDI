using Microsoft.Extensions.Logging;
using DotNet.Meteor.HotReload.Plugin;

namespace HelloMauiDI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
#if DEBUG
			.EnableHotReload()
#endif
			.RegisterAppServices()//for DI
			.RegisterViewModels()//for DI
            .RegisterViews()//for DI

			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
	
	 public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
		// Register Services
		builder.Services.AddSingleton<IAuthService, AuthService>();
		builder.Services.AddSingleton<AppShell>();
        return builder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        // Register ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        return builder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        // Register Views
        builder.Services.AddTransient<MainPage>();
        return builder;
    }
}
