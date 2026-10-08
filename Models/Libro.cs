namespace GestionLibrosApp;

public class Libro
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Sinopsis { get; set; } = string.Empty;
    public bool Disponible { get; set; }
}