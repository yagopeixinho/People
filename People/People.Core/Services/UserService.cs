using People.People.Core.Entities;
using People.People.Core.Services.Interfaces;
using People.People.Infrastructure.Data.Repositories.Interfaces;

namespace People.People.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            return await _userRepository.GetAllUsersAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter todos os usuários");
            throw; 
        }
    }
        
    public async Task AddUserAsync(User user)
    {
        try
        {
            await _userRepository.AddUserAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao adicionar usuário");
            throw; 
        }
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        try
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao obter usuário com ID {id}");
            throw; 
        }
    }
        
    public async Task UpdateUserAsync(User user)
    {
        try
        {
            await _userRepository.UpdateUserAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao atualizar usuário com ID {user.Id}");
            throw; // Relança a exceção para camadas superiores tratarem, se necessário
        }
    }
}

