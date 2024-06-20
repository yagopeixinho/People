using People.People.Core.Entities;
namespace People.People.Core.Services.Interfaces;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(string id);
    Task UpdateUserAsync(User user);
}