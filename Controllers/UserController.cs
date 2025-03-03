using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private Ilogger _logger;

    public UserController(Ilogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public User GetUser()
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Oleg",
            LastName = "Orlov",
            Email = "orlov@gmail.com",
            Password = "123456",
            Login = "orlov"
        };
    }
}