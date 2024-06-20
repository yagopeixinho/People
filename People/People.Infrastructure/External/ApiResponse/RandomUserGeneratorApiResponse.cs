using People.People.Web.ViewModel;

namespace People.People.Infrastructure.External.ApiResponse;

public class RandomUserGeneratorApiResponse
{
    public List<UserViewModel> Results { get; set; }
}