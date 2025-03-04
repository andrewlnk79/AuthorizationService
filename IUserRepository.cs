namespace AuthorizationService;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetByLogin(string login);
}