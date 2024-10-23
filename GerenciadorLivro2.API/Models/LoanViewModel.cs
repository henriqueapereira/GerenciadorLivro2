using GerenciadorLivro2.API.Entities;

namespace GerenciadorLivro2.API.Models;

public class LoanViewModel
{
    public LoanViewModel(int id, int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        Id = id;
        IdUsuario = idUsuario;
        IdLivro = idLivro;
        DataEmprestimo = dataEmprestimo;
        DataDevolucao = dataDevolucao;
    }

    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public int IdLivro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; private set; }

    public static LoanViewModel FromEntity(Loan loan) => new LoanViewModel
        (loan.Id, loan.IdUsuario, loan.IdLivro, loan.DataEmprestimo, loan.DataDevolucao);
}
