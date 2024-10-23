using GerenciadorLivro2.API.Entities;

namespace GerenciadorLivro2.API.Models;

public class BookViewModel
{
    public BookViewModel(int id, string titulo, string autor, string isbn, int anoPublicacao)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
        AnoPublicacao = anoPublicacao;
    }

    public int Id { get; private set; } 
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Isbn { get; private set; }
    public int AnoPublicacao { get; private set; }

    public static BookViewModel FromEntity(Book book) => new BookViewModel
        (book.Id, book.Titulo, book.Autor, book.Isbn, book.AnoPublicacao);
}
