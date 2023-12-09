using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TecnologicoApp.Service;
using TecnologicoApp.Service.Interface;
using TecnologicoApp.ViewModels;
using TecnologicoApp.Views;

namespace TecnologicoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<ISignupSigninService, SignupSigninService>();
            return builder.Build();
        }
    }
}