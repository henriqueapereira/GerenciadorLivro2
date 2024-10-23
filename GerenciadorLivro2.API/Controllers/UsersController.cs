using GerenciadorLivro2.API.Entities;
using GerenciadorLivro2.API.Models;
using GerenciadorLivro2.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro2.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly GerenciadorLivroDbContext _context;

    public UsersController(GerenciadorLivroDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users;

        var model = users.Select(UserViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        var model = UserViewModel.FromEntity(user);

        return Ok(model);

    }

    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var user = new User(model.Nome, model.Email);

        _context.Add(user);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateUserInputModel updateUserInputModel)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        user.UpdateUser(updateUserInputModel.Nome, updateUserInputModel.Email);
        _context.SaveChanges();

        var model = UserViewModel.FromEntity(user);

        return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        _context.Remove(user);
        _context.SaveChanges();

        return NoContent();

    }

}
