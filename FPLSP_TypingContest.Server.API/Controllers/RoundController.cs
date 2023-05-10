using FPLSP_TypingContest.Server.BLL.Services.Implements;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModel.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _roundService;
        public RoundController(IRoundService roundService)
        {
            _roundService = roundService;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roundService.GetAllAsync());
        }
        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _roundService.GetAllActiveAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _roundService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RoundCreateVM contest)
        {
            return Ok(await _roundService.AddAsync(contest));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoundUpdateVM contestUpdate)
        {
            if (contestUpdate == null) return BadRequest();
            else
                return Ok(await _roundService.UpdateAsync(id, contestUpdate));
        }
        [HttpDelete("Delete/{id}/{IdDeleteBy}")]
        public async Task<IActionResult> Remove(Guid id,Guid IdDeleteBy)
        {
            var contestNow =await _roundService.GetByIdAsync(id);
            if (contestNow == null)
            {
                return BadRequest();
            }
            else
                return Ok(await _roundService.RemoveAsync(id, IdDeleteBy));
        }
    }
}
