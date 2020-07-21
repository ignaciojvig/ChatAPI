using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "AdminClaim, UsersManagement")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] UserCreateViewModel newUser)
        {
            var addedUser = await _userService.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.Id }, addedUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateViewModel updateUser)
        {
            var updatedUser = await _userService.Update(updateUser);
            if (updatedUser == null)
            {
                return BadRequest("An User with the given Id does not exist");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deletedUser = await _userService.Remove(id);
            if (deletedUser == null)
            {
                return BadRequest("An User with the given Id does not exist");
            }

            return NoContent();
        }
    }
}
