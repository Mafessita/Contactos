using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;  // Asegúrate de importar el paquete de la Community Toolkit

namespace telefono
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Configura la aplicación MAUI
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()  // Inicializa el MAUI Community Toolkit
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Configura el registro de depuración solo en modo DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
