namespace GerenciadorLivro2.API.Entities;

public class User : BaseEntity
{
    public User()
    {
    }

    public User(string nome, string email)
    {
        Nome = nome;
        Email = email;
        
        //Loans = [];
    }

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public List<Loan> Loans { get; private set; }

    public void UpdateUser(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}
