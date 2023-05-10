using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPLSP_TypingContest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextTemplateController : ControllerBase
    {
        private readonly ITextTemplateServices _templateServices;
        public TextTemplateController(ITextTemplateServices templateServices)
        {
            _templateServices = templateServices;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<TextTemplateVM> lst = await _templateServices.GetAllAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("alloflevel/{levelId}")]
        public async Task<IActionResult> GetAllByLevelIdAsync([FromRoute]Guid levelId)
        {
            List<TextTemplateVM> lst = await _templateServices.GetAllByLevelIdAsync(levelId);
            return Ok(lst);
        }

        [HttpGet]
        [Route("allactive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            List<TextTemplateVM> lst = await _templateServices.GetAllActiveAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("getbyid/{TextTemplateId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid TextTemplateId)
        {
            TextTemplateVM obj = await _templateServices.GetByIdAsync(TextTemplateId);
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TextTemplateCreateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _templateServices.AddAsync(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("update/{TextTemplateId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid TextTemplateId, [FromBody] TextTemplateUpdateVM request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var result = await _templateServices.UpdateAsync(TextTemplateId, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{TextTemplateId}/{DeleteBy}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid TextTemplateId, Guid DeleteBy)
        {
            var obj = await _templateServices.GetByIdAsync(TextTemplateId);
            if (obj != null)
            {
                var result = await _templateServices.RemoveAsync(TextTemplateId, DeleteBy);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
