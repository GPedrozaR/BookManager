using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers(string query)
        {
            var users = _userService.GetAll(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult RegisterNewUser([FromBody] NewUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetUserById), new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            var user = _userService.GetById(id);

            if (user is null)
                return NotFound();

            _userService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var user = _userService.GetById(id);

            if (user is null)
                return NotFound();

            _userService.Delete(id);

            return NoContent();
        }
    }
}
