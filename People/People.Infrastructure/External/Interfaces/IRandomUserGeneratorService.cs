using People.People.Web.ViewModel;

namespace People.People.Infrastructure.External.Interfaces;

public interface IRandomUserGeneratorService
{
    Task<List<UserViewModel>> GetRandomUserListAsync(int count);
}