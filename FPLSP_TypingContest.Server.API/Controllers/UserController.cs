using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _userServices.AddAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _userServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _userServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _userServices.GetByIdAsync(id);


            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id, Guid idUserdelete)
        {
            var objDelete = await _userServices.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _userServices.RemoveAsync(id, idUserdelete);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UserUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _userServices.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
