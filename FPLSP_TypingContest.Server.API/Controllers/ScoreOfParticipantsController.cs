using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreOfParticipantsController : ControllerBase
    {
        private readonly IScoreOfParticipantServices _Services;
        public ScoreOfParticipantsController(IScoreOfParticipantServices Services)
        {
            _Services = Services;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ScoreOfParticipantCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _Services.AddAsync(request);

            return Ok(result);
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _Services.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _Services.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _Services.GetByIdAsync(id);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}/{idUser}")]
        public async Task<IActionResult> RemoveAsync(Guid id, Guid idUser)
        {
            var objDelete = await _Services.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _Services.RemoveAsync(id, idUser);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ScoreOfParticipantUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _Services.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
