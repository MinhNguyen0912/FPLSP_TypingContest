using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServices _userRoleServices;

        public UserRoleController(IUserRoleServices userRoleServices)
        {
            _userRoleServices = userRoleServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]UserRoleCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _userRoleServices.AddAsync(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _userRoleServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _userRoleServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{RoleId}/{UserId}")]
        public async Task<IActionResult> GetByIdAsync(Guid RoleId, Guid UserId)
        {
            var objVM = await _userRoleServices.GetByIdAsync(RoleId, UserId);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{RoleId}/{UserId}/{idUserdelete}")]
        public async Task<IActionResult> RemoveAsync(Guid RoleId, Guid UserId, Guid idUserdelete)
        {
            var objDelete = await _userRoleServices.GetByIdAsync(RoleId, UserId);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _userRoleServices.RemoveAsync(RoleId, UserId, idUserdelete);

            return Ok(result);
        }

        [HttpPut]
        [Route("{RoleId}/{UserId}")]
        public async Task<IActionResult> UpdateAsync(Guid RoleId, Guid UserId, [FromBody]UserRoleUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _userRoleServices.UpdateAsync(RoleId, UserId, request);

            return Ok(result);
        }
    }
}
