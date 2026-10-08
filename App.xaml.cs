using Microsoft.Extensions.DependencyInjection;

namespace GestionLibrosApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Registro global de rutas para Shell
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}