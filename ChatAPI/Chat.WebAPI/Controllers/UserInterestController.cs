using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.ViewModels.UserInterest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserInterestController : ControllerBase
    {
        private readonly IUserInterestService _userInterestService;

        public UserInterestController(IUserInterestService userInterestService)
        {
            _userInterestService = userInterestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserInterests()
        {
            return Ok(await _userInterestService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInterestById(Guid id)
        {
            return Ok(await _userInterestService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUserInterest([FromBody] UserInterestCreateViewModel newUserInterest)
        {
            var addedUserInterest = await _userInterestService.Add(newUserInterest);
            return CreatedAtAction(nameof(GetUserInterestById), new { id = addedUserInterest.Id }, addedUserInterest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInterest([FromBody] UserInterestUpdateViewModel updateUserInterest)
        {
            var updatedUserInterest = await _userInterestService.Update(updateUserInterest);
            if (updatedUserInterest == null)
            {
                return BadRequest("An Interest with the given Id does not exist");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInterest(Guid id)
        {
            var deletedUserInterest = await _userInterestService.Remove(id);
            if (deletedUserInterest == null)
            {
                return BadRequest("An Interest with the given Id does not exist");
            }

            return NoContent();
        }
    }
}
