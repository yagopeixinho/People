using People.People.Core.Entities;

namespace People.People.Web.ViewModel;

public class UserViewModel
{
    public Id Id { get; set; }
    public Name Name { get; set; }
    public Picture Picture { get; set; }
    public string Email { get; set; }

    public static UserViewModel FromUser(User user)
    {
        return new UserViewModel
        {
            Name = new Name
            {
                First = user.Name,
                Last = user.Name
            },
            Email = user.Email,
            Id = new Id { Value = user.Id },
            Picture = new Picture { Large = user.Picture }
        };
    }
}

public class Id
{
    public string Value { get; set; }
}


public class Name
{
    public string First { get; set; }
    public string Last { get; set; }
}

public class Picture
{
    public string Large { get; set; }
}
