using System.Net.Mail;

namespace AuthorizationService;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        Id = user.Id;

        FullName = GetFullName(user.FirstName, user.LastName);
        FromRussia = GetFromRussiaValue(user.Email);
    }

    public Ulid Id { get; set; }
    public string FullName { get; set; }
    public bool FromRussia { get; set; }

    public string GetFullName(string firstName, string lastName)
    {
        return string.Concat(firstName + " " + lastName);
    }

    public bool GetFromRussiaValue(string email)
    {
        var mailAddress = new MailAddress(email);

        if (mailAddress.Host.Contains(".ru"))
            return true;
        return false;
    }
}