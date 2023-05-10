using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaticipantsController : Controller
    {
        private readonly IParticipantServices _participantServices;

        public PaticipantsController(IParticipantServices participantServices)
        {
            _participantServices = participantServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ParticipantCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _participantServices.AddAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _participantServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _participantServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _participantServices.GetByIdAsync(id);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}/{idUser}")]
        public async Task<IActionResult> RemoveAsync(Guid id, Guid idUser)
        {
            var objDelete = await _participantServices.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _participantServices.RemoveAsync(id, idUser);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ParticipantUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _participantServices.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
