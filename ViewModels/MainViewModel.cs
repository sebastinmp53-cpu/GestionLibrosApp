using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GestionLibrosApp;

public partial class MainViewModel : ObservableObject
{
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public ObservableCollection<Libro> Libros { get; } = new();

    public MainViewModel()
    {
        CargarLibros();
    }

    private void CargarLibros()
    {
        Libros.Add(new Libro 
        { 
            Titulo = "Cien años de soledad", 
            Autor = "Gabriel García Márquez", 
            Categoria = "Novela / Realismo Mágico", 
            Sinopsis = "La historia de la familia Buendía en el pueblo ficticio de Macondo.", 
            Disponible = true 
        });

        Libros.Add(new Libro 
        { 
            Titulo = "1984", 
            Autor = "George Orwell", 
            Categoria = "Distopía / Ficción", 
            Sinopsis = "Una novela sobre la vigilancia gubernamental totalitaria y el control social.", 
            Disponible = false 
        });

        Libros.Add(new Libro 
        { 
            Titulo = "Don Quijote de la Mancha", 
            Autor = "Miguel de Cervantes", 
            Categoria = "Clásico", 
            Sinopsis = "Las aventuras de un hidalgo español que pierde el juicio y decide hacerse caballero andante.", 
            Disponible = true 
        });
    }

    [RelayCommand]
    private async Task CargarCatalogoAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true; // Requisito 6: Activa ActivityIndicator
            await Task.Delay(1500); // Simulación de proceso asíncrono
        }
        catch (Exception ex)
        {
            // Requisito 6: Manejo de errores visible con DisplayAlert
            if (Shell.Current != null)
            {
                await Shell.Current.DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SeleccionarLibroAsync(Libro libro)
    {
        if (libro == null) return;

        try
        {
            IsBusy = true; // Activa el ActivityIndicator mientras navega

            // Requisito 1 y 2: Navegación con paso de parámetros
            var parametros = new Dictionary<string, object>
            {
                { "SelectedLibro", libro }
            };

            // Navegación asíncrona usando Shell
            await Shell.Current.GoToAsync(nameof(DetailPage), parametros);
        }
        catch (Exception ex)
        {
            // Requisito 6: Manejo de errores visible al usuario
            if (Shell.Current != null)
            {
                await Shell.Current.DisplayAlertAsync("Error de Navegación", $"No se pudo abrir la pantalla: {ex.Message}", "OK");
            }
        }
        finally
        {
            IsBusy = false; // Desactiva el ActivityIndicator
        }
    }
}