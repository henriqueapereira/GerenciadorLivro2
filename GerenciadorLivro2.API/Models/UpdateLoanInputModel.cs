namespace GerenciadorLivro2.API.Models;

public class UpdateLoanInputModel
{
    //public int IdLoan { get; set; }
    public int IdUsuario { get; set; }
    public int IdLivro { get; set; }
    //public DateTime DataEmprestimo { get; set; } = DateTime.Now.Date;
    //public DateTime DataDevolucao { get; set; } = DateTime.Now.Date.AddDays(7);
}
