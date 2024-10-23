using GerenciadorLivro2.API.Entities;

namespace GerenciadorLivro2.API.Models;

public class UserViewModel
{
    public UserViewModel(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public static UserViewModel FromEntity(User user) => new UserViewModel(user.Id,user.Nome, user.Email);
    

    
}
