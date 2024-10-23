using GerenciadorLivro2.API.Entities;
using GerenciadorLivro2.API.Models;
using GerenciadorLivro2.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro2.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    
    private readonly GerenciadorLivroDbContext _context;
    public BooksController(GerenciadorLivroDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _context.Books;

        var model = books.Select(BookViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        var model = BookViewModel.FromEntity(book);
        
        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateBookInputModel model)
    {
        var book = new Book(model.Titulo, model.Autor, model.Isbn, model.AnoPublicacao);

        _context.Add(book);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateBookInputModel model)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.UpdateBook(model.Titulo, model.Autor, model.Isbn, model.AnoPublicacao);
        _context.SaveChanges();

        var modelView = BookViewModel.FromEntity(book);

        return Ok(modelView);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Remove(book);
        _context.SaveChanges();

        return NoContent();
    }

}
