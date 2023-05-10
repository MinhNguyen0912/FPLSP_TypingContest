using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : Controller
    {
        private readonly IOrganizerServices _organizerServices;

        public OrganizersController(IOrganizerServices organizerServices)
        {
            _organizerServices = organizerServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] OrganizerCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _organizerServices.AddAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _organizerServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _organizerServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _organizerServices.GetByIdAsync(id);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}/{idUser}")]
        public async Task<IActionResult> RemoveAsync(Guid id, Guid idUser)
        {
            var objDelete = await _organizerServices.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _organizerServices.RemoveAsync(id, idUser);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] OrganizerUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _organizerServices.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
