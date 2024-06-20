using People.People.Core.Entities;

namespace People.People.Infrastructure.Data.Repositories.Interfaces;

public interface IUserRepository
{
     Task AddUserAsync(User user);
     Task<List<User>> GetAllUsersAsync();
     Task<User> GetUserByIdAsync(string id);
     Task UpdateUserAsync(User user);

}