using Microsoft.AspNetCore.Mvc;
using People.People.Core.Entities;
using People.People.Core.Services.Interfaces;
using People.People.Web.ViewModel;

namespace People.People.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="userService">Service for generating random users.</param>
    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var randomUserList = await _userService.GetAllUsersAsync();
            var userViewModels = randomUserList.Select(user => UserViewModel.FromUser(user)).ToList();
            return View(userViewModels);
        }
        catch (Exception ex)
        {
            // Log the exception
            ViewBag.ErrorMessage = "Ocorreu um erro ao buscar usuários externos.";
            return RedirectToAction(nameof(Error));
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserViewModel newUserModel)
    {
        try
        {
            var newUser = new User
            {
                Name = $"{newUserModel.Name.First} {newUserModel.Name.Last}",
                Email = newUserModel.Email,
                Id = newUserModel.Id?.Value,
                Picture = newUserModel.Picture?.Large
            };

            await _userService.AddUserAsync(newUser);

            return RedirectToAction(nameof(Index));
        }
        catch (ArgumentException ex)
        {
            ViewBag.ErrorMessage = $"Erro ao adicionar usuário: {ex.Message}";
            return BadRequest($"Erro ao adicionar usuário: {ex.Message}");
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Erro ao adicionar usuário: ocorreu um erro inesperado.";
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Error()
    {
        return View("Error");
    }

    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = UserViewModel.FromUser(user);
            return View(userViewModel);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Ocorreu um erro ao carregar os dados para edição.";
            return RedirectToAction(nameof(Error));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UserViewModel updatedUserModel)
    {
        try
        {
            var userToUpdate = await _userService.GetUserByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Name = $"{updatedUserModel.Name.First} {updatedUserModel.Name.Last}";
            userToUpdate.Email = updatedUserModel.Email;

            await _userService.UpdateUserAsync(userToUpdate);

            return Ok(userToUpdate);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Erro ao atualizar usuário: {ex.Message}";
            return StatusCode(500, "Erro interno ao atualizar usuário");
        }
    }
}
