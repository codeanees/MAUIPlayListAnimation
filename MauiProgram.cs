using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MAUIPlayListAnimation;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCompatibility()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Rubik-Bold.ttf", "RubikBold");
                fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                fonts.AddFont("Rubik-Medium.ttf", "RubikMedium");
                fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
            });
        //Register Services
        RegisterAppServices(builder.Services);

        return builder.Build();
	}
    private static void RegisterAppServices(IServiceCollection services)
    {
        //Add Platform specific Dependencies
        services.AddSingleton<IConnectivity>(Connectivity.Current);

        //Register View Models
        services.AddSingleton<MainPage>();
        services.AddSingleton<MainPageViewModel>();
    }
}
