using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelServices _levelServices;
        public LevelsController(ILevelServices levelServices) 
        { 
            _levelServices = levelServices;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync() 
        { 
            List<LevelVM> lst = await _levelServices.GetAllAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            List<LevelVM> lst = await _levelServices.GetAllActiveAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("getbyid/{levelId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid levelId)
        {
            LevelVM obj = await _levelServices.GetByIdAsync(levelId);
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]LevelCreateVM request)
        {
            if (request==null)
            {
                return BadRequest();
            }
            var result = await _levelServices.AddAsync(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("update/{levelId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid levelId,[FromBody] LevelUpdateVM request)
        {
            if (request==null)
            {
                return BadRequest();
            }
            var result = await _levelServices.UpdateAsync(levelId, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{levelId}/{DeleteBy}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid levelId, Guid DeleteBy)
        {
            var obj = await _levelServices.GetByIdAsync(levelId);
            if (obj!=null)
            {
                var result = await _levelServices.RemoveAsync(levelId, DeleteBy);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
