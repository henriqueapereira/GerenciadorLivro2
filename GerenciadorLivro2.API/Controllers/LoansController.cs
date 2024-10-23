using GerenciadorLivro2.API.Entities;
using GerenciadorLivro2.API.Models;
using GerenciadorLivro2.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro2.API.Controllers;

[ApiController]
[Route("api/loans")]
public class LoansController : ControllerBase
{
    private readonly GerenciadorLivroDbContext _context;

    public LoansController(GerenciadorLivroDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var loans = _context.Loans;

        var model = loans.Select(LoanViewModel.FromEntity).ToList();    

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var loan = _context.Loans.FirstOrDefault(l => l.Id == id);

        if (loan is null)
        {
            return NotFound();
        }

        var model = LoanViewModel.FromEntity(loan);

        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateLoanInputModel model)
    {
        var loan = new Loan(model.IdLivro, model.IdUsuario, model.DataEmprestimo, model.DataDevolucao);
        _context.Add(loan);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateLoanInputModel model) 
    {
        var loan = _context.Loans.FirstOrDefault(l => l.Id == id);

        if (loan is null)
        {
            return NotFound();
        }

        loan.Update(model.IdLivro, model.IdUsuario);
        _context.SaveChanges();

        var modelView = LoanViewModel.FromEntity(loan);

        return Ok(modelView);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var loan = _context.Loans.FirstOrDefault(l => l.Id == id);

        if (loan is null)
        {
            return NotFound();
        }

        _context.Remove(loan);
        _context.SaveChanges();

        return NoContent();
    }
}
