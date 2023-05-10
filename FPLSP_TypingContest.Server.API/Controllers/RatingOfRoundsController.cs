using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingOfRoundsController : ControllerBase
    {
        private readonly IRatingOfRoundServices _ratingOfRoundServices;

        public RatingOfRoundsController(IRatingOfRoundServices ratingOfRoundServices)
        {
            _ratingOfRoundServices = ratingOfRoundServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]RatingOfRoundCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _ratingOfRoundServices.AddAsync(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _ratingOfRoundServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _ratingOfRoundServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{idParticipant}")]
        public async Task<IActionResult> GetByIdAsync(Guid idParticipant)
        {
            var objVM = await _ratingOfRoundServices.GetByIdAsync(idParticipant);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{idParticipant}")]
        public async Task<IActionResult> RemoveAsync(Guid idParticipant)
        {
            var objDelete = await _ratingOfRoundServices.GetByIdAsync(idParticipant);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _ratingOfRoundServices.RemoveAsync(idParticipant);

            return Ok(result);
        }

        [HttpPut]
        [Route("{idParticipant}")]
        public async Task<IActionResult> UpdateAsync(Guid idParticipant, [FromBody] RatingOfRoundUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _ratingOfRoundServices.UpdateAsync(idParticipant, request);

            return Ok(result);
        }
    }
}
