namespace GerenciadorLivro2.API.Entities;

public class Book : BaseEntity
{
    public Book() { }
    public Book(string titulo, string autor, string isbn, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
        AnoPublicacao = anoPublicacao;

        //Books = [];
    }

    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Isbn { get; private set; }
    public int AnoPublicacao { get; private set; }
    //public int IdLoan { get; private set; }
    //public Loan Loans { get; private set; }
    public List<Loan> Loans { get; private set; }

    public void UpdateBook(string titulo, string autor, string isbn, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
        AnoPublicacao = anoPublicacao;
    }
}
