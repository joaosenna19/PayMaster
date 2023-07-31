using Microsoft.Extensions.Logging;
using PayMaster;
using PayMaster.Data;

namespace PayMaster;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "employees.db");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<HourlyEmployeeRepository>(s, dbPath));
        return builder.Build();
    }
}