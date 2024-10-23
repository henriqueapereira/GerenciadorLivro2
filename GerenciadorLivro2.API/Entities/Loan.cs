using GerenciadorLivro2.API.Enums;

namespace GerenciadorLivro2.API.Entities;

public class Loan : BaseEntity
{
    public Loan() { }

    public Loan(int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        IdUsuario = idUsuario;
        IdLivro = idLivro;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
        Status = LoanStatusEnum.Disponivel;
    }

    public int IdUsuario { get; private set; }
    public User Usuario { get; private set; }
    public int IdLivro { get; private set; }
    public Book Livro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; set; }
    public LoanStatusEnum Status { get; private set; }

    public void Update(int idLivro, int idUsuario)
    {
        IdLivro = idLivro;
        IdUsuario = IdUsuario;
    }

    public void Emprestar()
    {
        if(Status == LoanStatusEnum.Disponivel)
        {
            Status = LoanStatusEnum.Emprestado;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(7);
        }
    }

    public void Retornar()
    {
        if(Status == LoanStatusEnum.Emprestado)
        {
            Status = LoanStatusEnum.Devolvido;
        }
    }

    public void Indisponivel()
    {
        if(Status == LoanStatusEnum.Nenhum || Status == LoanStatusEnum.Indisponivel)
        {
            Status = LoanStatusEnum.Indisponivel;
        }
    }
}
