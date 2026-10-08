namespace GestionLibrosApp;

[QueryProperty(nameof(SelectedLibro), "SelectedLibro")]
public partial class DetailPage : ContentPage
{
    private Libro? _selectedLibro;

    public Libro? SelectedLibro
    {
        get => _selectedLibro;
        set
        {
            _selectedLibro = value;
            OnPropertyChanged();
            BindingContext = _selectedLibro;
        }
    }

    public DetailPage()
    {
        InitializeComponent();
    }
}