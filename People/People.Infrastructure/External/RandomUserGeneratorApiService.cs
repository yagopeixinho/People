

using People.People.Infrastructure.External.ApiResponse;
using People.People.Infrastructure.External.Interfaces;
using People.People.Web.ViewModel;

namespace People.People.Infrastructure.External;

public class RandomUserGeneratorApiService : IRandomUserGeneratorService
{
    private readonly HttpClient _httpClient;

    public RandomUserGeneratorApiService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<UserViewModel>> GetRandomUserListAsync(int count)
    {
        try
        {
            //  Estou ciente da problemática de não utilizarmos variáveis de ambiente para links :( Mas foi por causa
            // da falta de tempo
            var response = await _httpClient.GetAsync($"https://randomuser.me/api/?results={count}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<RandomUserGeneratorApiResponse>();
            return result?.Results ?? new List<UserViewModel>();
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro inesperado ao obter a lista de usuários aleatórios", ex);
        }
    }
}
