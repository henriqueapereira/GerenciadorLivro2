namespace GerenciadorLivro2.API.Models;

public class CreateBookInputModel
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Isbn { get; set; }
    public int AnoPublicacao { get; set; }
}
