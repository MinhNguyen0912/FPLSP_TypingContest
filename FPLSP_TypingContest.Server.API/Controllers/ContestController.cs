using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private readonly IContestService _contestService;

        public ContestController(IContestService contestService)
        {
            _contestService = contestService;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contestService.GetAllAsync());
        }
        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _contestService.GetAllActiveAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _contestService.GetByIdAsync(id));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ContestCreateVM contest)
        {
            return Ok(await _contestService.AddAsync(contest));
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ContestUpdateVM contestUpdate)
        {
            if (contestUpdate == null) return BadRequest();
            else
                return Ok(await _contestService.UpdateAsync(id, contestUpdate));
        }
        [HttpDelete("Delete/{id}/{IdDeleteBy}")]
        public async Task<IActionResult> Remove(Guid id, Guid IdDeleteBy)
        {
            var contestNow =await _contestService.GetByIdAsync(id);
            if (contestNow == null)
            {
                return BadRequest();
            }
            else
                return Ok(await _contestService.RemoveAsync(id, IdDeleteBy));
        }
    }
}
