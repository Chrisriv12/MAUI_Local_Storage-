using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MAUI_Local_Storage
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register any services or dependencies here if needed
            // builder.Services.AddSingleton<PersonData>();

            return builder.Build();
        }
    }
}