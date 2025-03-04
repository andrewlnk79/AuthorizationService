namespace AuthorizationService;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users.Add(new User
        {
            Id = Ulid.NewUlid(),
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@gmail.com",
            Password = "11111122222qq",
            Login = "ivanov"
        });

        _users.Add(new User
        {
            Id = Ulid.NewUlid(),
            FirstName = "Максим",
            LastName = "Максимов",
            Email = "maksim@gmail.com",
            Password = "10001qq",
            Login = "maxim"
        });

        _users.Add(new User
        {
            Id = Ulid.NewUlid(),
            FirstName = "Антон",
            LastName = "Антонов",
            Email = "anton@gmail.com",
            Password = "111zzxc1",
            Login = "anton"
        });
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User GetByLogin(string login)
    {
        return _users.FirstOrDefault(v => v.Login == login);
    }
}