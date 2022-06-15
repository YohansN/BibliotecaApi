namespace Biblioteca.Models;

public class BibliotecaData
{
    public BibliotecaData(string id, string titulo, string autor, bool disponibilidade)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Disponibilidade = disponibilidade;
    }
    public string Id { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public bool Disponibilidade { get; set; }
}
