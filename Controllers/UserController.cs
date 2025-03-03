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

    [HttpGet]
    [Route("viewmodel")]
    public UserViewModel GetUserViewModel()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@gmail.com",
            Password = "11111122222qq",
            Login = "ivanov"
        };

        var userViewModel = new UserViewModel(user);

        return userViewModel;
    }
}