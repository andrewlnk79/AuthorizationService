using System.Security.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private Ilogger _logger;
    private IUserRepository _userRepository;

    public UserController(Ilogger logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public User GetUser()
    {
        return new User
        {
            Id = Ulid.NewUlid(),
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
            Id = Ulid.NewUlid(),
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@gmail.com",
            Password = "11111122222qq",
            Login = "ivanov"
        };
        var userViewModel = _mapper.Map<UserViewModel>(user);


        return userViewModel;
    }

    [HttpPost]
    [Route("authenticate")]
    public UserViewModel Authenticate(string login, string password)
    {
        if (string.IsNullOrEmpty(login) ||
            string.IsNullOrEmpty(password))
            throw new ArgumentNullException("Запрос не корректен");

        var user = _userRepository.GetByLogin(login);
        if (user is null)
            throw new AuthenticationException("Пользователь на найден");

        if (user.Password != password)
            throw new AuthenticationException("Введенный пароль не корректен");
        return _mapper.Map<UserViewModel>(user);
    }
}