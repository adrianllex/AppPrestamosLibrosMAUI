using AppPrestamosLibrosMAUI.Services;
using AppPrestamosLibrosMAUI.Views; // <-- Asegúrate de incluir esta línea

namespace AppPrestamosLibrosMAUI;

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

        // ✅ Ruta de la base de datos (archivo local)
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "prestamos.db3");

        // ✅ Registrar la base de datos como servicio singleton
        builder.Services.AddSingleton(new DatabaseService(dbPath));

        // ✅ Registrar las páginas que usan DI
        builder.Services.AddSingleton<LibrosPage>();
        builder.Services.AddSingleton<UsuariosPage>();
        builder.Services.AddSingleton<UsuariosListaPage>();
        builder.Services.AddSingleton<LibrosListaPage>();
        builder.Services.AddSingleton<PrestamosPage>();
        builder.Services.AddSingleton<PrestamosListaPage>(); // 👈 Esta es la que agregamos ahora

        return builder.Build();
    }
}
