using Microsoft.AspNetCore.Mvc;
using People.People.Infrastructure.External.Interfaces;

namespace People.People.Web.Controllers;

public class RandomUserController : Controller
{
    private readonly IRandomUserGeneratorService _randomUserGeneratorService;

    /// <summary>
    /// Initializes a new instance of the <see cref="RandomUserController"/> class.
    /// </summary>
    /// <param name="randomUserGeneratorService">Service for generating random users.</param>
    public RandomUserController(IRandomUserGeneratorService randomUserGeneratorService)
    {
        _randomUserGeneratorService = randomUserGeneratorService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var randomUserList = await _randomUserGeneratorService.GetRandomUserListAsync(12);
            return View(randomUserList);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Ocorreu um erro ao buscar usuários externos.";
            return View("Error");
        }
    }
}