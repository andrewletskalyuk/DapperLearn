using DapperLearn.Models;
using DapperLearn.Repo;
using Microsoft.AspNetCore.Mvc;

namespace DapperLearn.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_repo.GetUsers());
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _repo.Get(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        _repo.Create(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        user.Id = id;
        _repo.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }
}
