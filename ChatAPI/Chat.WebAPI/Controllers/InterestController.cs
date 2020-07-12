using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.ViewModels.Interest;
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
    [Authorize]
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;

        public InterestController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            return Ok(await _interestService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterestById(Guid id)
        {
            return Ok(await _interestService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInterest([FromBody] InterestCreateViewModel newInterest)
        {
            var addedInterest = await _interestService.Add(newInterest);
            return CreatedAtAction(nameof(GetInterestById), new { id = addedInterest.Id }, addedInterest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInterest([FromBody] InterestUpdateViewModel updateInterest)
        {
            var updatedInterest = await _interestService.Update(updateInterest);
            if (updateInterest == null)
            {
                return BadRequest("An Interest with the given Id does not exist");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(Guid id)
        {
            var deletedInterest = await _interestService.Remove(id);
            if (deletedInterest == null)
            {
                return BadRequest("An Interest with the given Id does not exist");
            }

            return NoContent();
        }
    }
}
