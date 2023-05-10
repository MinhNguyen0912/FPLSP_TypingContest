using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]RoleCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _roleServices.AddAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var objCollection = await _roleServices.GetAllAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var objCollection = await _roleServices.GetAllActiveAsync();

            return Ok(objCollection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _roleServices.GetByIdAsync(id);

            return Ok(objVM);
        }

        [HttpDelete]
        [Route("{id}/{idUserdelete}")]
        public async Task<IActionResult> RemoveAsync(Guid id,Guid idUserdelete)
        {
            var objDelete = await _roleServices.GetByIdAsync(id);
            if (objDelete == null)
            {
                return NotFound();
            }

            var result = await _roleServices.RemoveAsync(id, idUserdelete);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]RoleUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _roleServices.UpdateAsync(id, request);

            return Ok(result);
        }
    }
}
