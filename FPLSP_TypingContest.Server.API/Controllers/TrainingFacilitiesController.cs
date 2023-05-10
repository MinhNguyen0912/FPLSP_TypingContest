using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingFacilitiesController : ControllerBase
    {
        private readonly ITrainingFacilityServices _trainingFacilityServices;
        public TrainingFacilitiesController(ITrainingFacilityServices trainingFacilityServices)
        {
            _trainingFacilityServices = trainingFacilityServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TrainingFacilityCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _trainingFacilityServices.AddAsync(request);

            return Ok(result);
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _trainingFacilityServices.GetAllAsync();

            return Ok(objCollection);
        }
        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _trainingFacilityServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _trainingFacilityServices.GetByIdAsync(id);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}/{idUser}")]
        public async Task<IActionResult> RemoveAsync(Guid id,Guid idUser)
        {
            var objDelete = await _trainingFacilityServices.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _trainingFacilityServices.RemoveAsync(id, idUser);

            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id,[FromBody] TrainingFacilityUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _trainingFacilityServices.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
