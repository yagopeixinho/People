using Microsoft.EntityFrameworkCore;
using People.People.Core.Entities;
using People.People.Infrastructure.Data.Context;
using People.People.Infrastructure.Data.Repositories.Interfaces;

namespace People.People.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PeopleContext _context;

    public UserRepository(PeopleContext context)
    {
        _context = context;
    }
    
    public async Task AddUserAsync(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        return await _context.User.FindAsync(id);
    }
    
    public async Task UpdateUserAsync(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }
}